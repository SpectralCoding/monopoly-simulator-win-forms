using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace MonopolySim
{
	public static class GameClass
	{
		public static BoardClass Board = new BoardClass();
		public static ConfigClass Config = new ConfigClass();
		public static PropertyClass[] Property = new PropertyClass[40];
		public static CommunityChestDeckClass CommunityChestDeck;
		public static ChanceDeckClass ChanceDeck;
		public static PlayerClass[] Player = new PlayerClass[4];
		public static int RandomDelay = 100;
		public static int RandomSeed;
		public static int PlayerTurn;
		public static int DoublesCount;
		public static int MoveNumber = -3;
		public static int TotalPlayers = 4;
		public static int FreeParkingCash = 0;
		private static int ciTempRentMultiplier = 1;
		private static bool ciTempSpecialRent = false;
		private static int ciDice1, ciDice2, ciTotal;
		
		public static void StartGame()
		{
			Board.GameLog = "Game Started: " + DateTime.Now.ToString();
			Board.GameLog = "-----------------------------------------------------------------";
			Board.GameLog = "Start Game Initiated";
			
			CommunityChestDeck = new CommunityChestDeckClass();
			Board.GameLog = "Community Chest Deck Created";
			
			ChanceDeck = new ChanceDeckClass();
			Board.GameLog = "Chance Deck Created";
			
			// Instantiate all 40 Properties and set their respective information
			for (int i = 0; i <= 39; i++) { Property[i] = new PropertyClass(); Property[i].SetProperty(i); }
			Board.GameLog = "Properties Instantiated";
			
			// Instantiate all 4 Players and set their respective information
			for (int i = 0; i < TotalPlayers; i++) { Player[i] = new PlayerClass(); Player[i].Number = i; }
			Board.GameLog = "Players Instantiated";
			Board.GameLog = "Moving all players to Go";
			MovePlayerToSpace(0, 0); MovePlayerToSpace(1, 0); MovePlayerToSpace(2, 0); MovePlayerToSpace(3, 0);
			Board.GameLog = "Player0's Turn:";
			PlayerTurn = 0;
			Random Random = new Random();
			RandomSeed = Random.Next(1, int.MaxValue);
			if (Config.FreeParking500 == true) {
				FreeParkingCash = 500;
			}
		}
		
		public static void MovePlayerToSpace(int fiPlayerNumber, int fiMoveTo)
		{
			if (fiMoveTo > 40) {
				Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " PASSES GO!";
				Board.GameLog = "      COLLECT $200";
				Player[fiPlayerNumber].Cash += 200;
			}
			fiMoveTo = fiMoveTo % 40;
			Property[Player[fiPlayerNumber].CurrentPosition].PlayerOffSpace(fiPlayerNumber);
			Player[fiPlayerNumber].CurrentPosition = fiMoveTo;
			Property[fiMoveTo].PlayerOnSpace(fiPlayerNumber);
			Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " MOVE TO " + Player[fiPlayerNumber].CurrentPosition.ToString() + " (" + Property[Player[fiPlayerNumber].CurrentPosition].Name + ")";
			if (fiMoveTo == 30) {
				Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " WENT TO JAIL!";
				Player[fiPlayerNumber].TurnInJail++;
			}
			PerformSpaceActions(fiPlayerNumber, fiMoveTo);
			GameClass.MoveNumber++;
		}
		
		public static void KickBrokePlayers() {
			for (int i = 0; i <= 3; i++) {
				if (Player[i].Cash <= 0) {
					
				}
			}
		}
		
		public static void NextTurn()
		{
			KickBrokePlayers();
			Board.GameLog = "   Player" + PlayerTurn.ToString() + " STATUS: CASH=" + Player[PlayerTurn].Cash.ToString("C0") + " ASSETS=" + Player[PlayerTurn].Assets.ToString("C0");
			StrategyClass Strategy = new StrategyClass(Player[PlayerTurn]);
			Strategy.BuyPropertyCutOffPct = 25;
			// Evaluate if any preturn trades should be run.
			Strategy.RunPreturnOptions();
			Random Random = new Random(RandomSeed);
			//int ciDice1, ciDice2, ciTotal;
			ciDice1 = Random.Next(1, 7);
			ciDice2 = Random.Next(1, 7);
			ciTotal = ciDice1 + ciDice2;
			//
			//	PLAYER IN JAIL
			//
			if (Player[PlayerTurn].CurrentPosition == 30) {						// If Player is in Jail
				if (Player[PlayerTurn].TurnInJail < 3) {						// If player is not ready to get out
					if (ciDice1 == ciDice2) {
						Board.GameLog = "   Player" + PlayerTurn.ToString() + " ROLLED DOUBLES AND GOT OUT OF JAIL (TRY " + Player[PlayerTurn].TurnInJail.ToString() + ")!";
						Board.GameLog = "   Player" + PlayerTurn.ToString() + " ROLLED " + ciTotal.ToString() + " (" + ciDice1.ToString() + "+" + ciDice2.ToString() + ")";
						Player[PlayerTurn].TurnInJail = 0;
						Player[PlayerTurn].CurrentPosition = 10;
						Property[30].PlayerOffSpace(PlayerTurn);
						DoublesCount = 0;
						MovePlayerAhead(PlayerTurn, ciTotal);
					} else {													// Player fails at rolling doubles and stays for another turn.
						Board.GameLog = "Player" + PlayerTurn.ToString() + " FAILED TO ROLL DOUBLES (TRY " + Player[PlayerTurn].TurnInJail.ToString() + ")!";
						Player[PlayerTurn].TurnInJail++;
					}
				} else if (Player[PlayerTurn].TurnInJail == 3) {				// If player is ready to get out this turn
					if (ciDice1 == ciDice2) {															// Player rolls doubles to get out of jail
						Board.GameLog = "   Player" + PlayerTurn.ToString() + " ROLLED DOUBLES AND GOT OUT OF JAIL (TRY " + Player[PlayerTurn].TurnInJail.ToString() + ")!";
						DoublesCount = 0;
					} else {													// Player fails at rolling doubles and pays $50
						Board.GameLog = "   Player" + PlayerTurn.ToString() + " FAILED TO ROLL DOUBLES AND GOT OUT OF JAIL (TRY " + Player[PlayerTurn].TurnInJail.ToString() + ")!";
						Player[PlayerTurn].Cash -= 50;
						if (Config.FreeParking == true) {
							Board.GameLog = "      PAY $50 TO FREE PARKING";
							FreeParkingCash += 50;
						} else {
							Board.GameLog = "      PAY $50";
						}
					}
					Board.GameLog = "   Player" + PlayerTurn.ToString() + " ROLLED " + ciTotal.ToString() + " (" + ciDice1.ToString() + "+" + ciDice2.ToString() + ")";
					Player[PlayerTurn].TurnInJail = 0;
					Player[PlayerTurn].CurrentPosition = 10;
					Property[30].PlayerOffSpace(PlayerTurn);
					MovePlayerAhead(PlayerTurn, ciTotal);
				}
				if (PlayerTurn == 3) { PlayerTurn = 0; } else { PlayerTurn++; }	// Set Next Player's Turn
			//
			//	PLAYER NOT IN JAIL
			//
			} else {															// If Player is not in Jail
				if (ciDice1 == ciDice2) {										// If Player rolled doubles
					if (DoublesCount < 2) {										// If first or second time rolling doubles
						DoublesCount++;											// Increase Doubles Counter
						Board.GameLog = "   Player" + PlayerTurn.ToString() + " ROLLED " + ciTotal.ToString() + " (DOUBLE " + ciDice1.ToString() + "s, ROLL " + DoublesCount.ToString() + ")";
						MovePlayerAhead(PlayerTurn, ciTotal);					// Move Player Ahead
					} else if (DoublesCount == 2) {								// If third time rolling doubles
						DoublesCount++;
						Board.GameLog = "   Player" + PlayerTurn.ToString() + " ROLLED " + ciTotal.ToString() + " (DOUBLE " + ciDice1.ToString() + "s, ROLL " + DoublesCount.ToString() + ") GO TO JAIL";
						DoublesCount = 0;										// Reset DoubleCounter to 0
						MovePlayerToJail(PlayerTurn);							// Send Player to Jail
						if (PlayerTurn == 3) { PlayerTurn = 0; } else { PlayerTurn++; }		// Set Next Player's Turn
					}
				} else {														// If Player did not roll doubles
					Board.GameLog = "   Player" + PlayerTurn.ToString() + " ROLLED " + ciTotal.ToString() + " (" + ciDice1.ToString() + "+" + ciDice2.ToString() + ")";
					DoublesCount = 0;											// Reset Doubles count to 0
					MovePlayerAhead(PlayerTurn, ciTotal);						// Move Player Ahead
					if (PlayerTurn == 3) { PlayerTurn = 0; } else { PlayerTurn++; }			// Set Next Player's Turn
				}
			}
			RandomSeed = Random.Next(1, int.MaxValue);
			Board.GameLog = "Player" + PlayerTurn.ToString() + "'s Turn:";
		}
		
		public static void MovePlayerAhead(int fiPlayerNumber, int fiSpacesToMove)
		{
			MovePlayerToSpace(fiPlayerNumber, (Player[fiPlayerNumber].CurrentPosition + fiSpacesToMove));
		}
		
		public static void MovePlayerToJail(int fiPlayerNumber) {
			MovePlayerToSpace(fiPlayerNumber, 30);
		}

		public static void PlayerImprovesSpace(int fiPlayerNumber, int fiPropertyPosition) {
			Property[fiPropertyPosition].Improvements++;
			Player[fiPlayerNumber].Cash -= Property[fiPropertyPosition].HouseCost;
			Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " IMPROVES " + Property[fiPropertyPosition].Name + "!";
			Board.GameLog = "      ADD HOUSE TO " + Property[fiPropertyPosition].Name + " (" + Property[fiPropertyPosition].Improvements + "/5)";
			Board.GameLog = "      PAY " + Property[fiPropertyPosition].HouseCost.ToString("C0");
		}
		
		public static void PerformSpaceActions(int fiPlayerNumber, int fiPosition) {
			if (Property[fiPosition].ColorNum == -1) {							// If property is non-purchasable
				switch (Property[fiPosition].Name) {
					case "Go":
						Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " LANDS ON GO!";
						Board.GameLog = "      COLLECT $200";
						Player[fiPlayerNumber].Cash += 200;
						break;
					case "Community Chest":
						Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " LANDS ON COMMUNITY CHEST! DRAW CARD:";
						string fsCommunityChestCard;
						fsCommunityChestCard = CommunityChestDeck.DrawCard();
						Board.GameLog = "      " + fsCommunityChestCard;
						ExecuteCardDesc("Community Chest", fsCommunityChestCard, fiPlayerNumber);
						break;
					case "Income Tax":
						Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " LANDS ON INCOME TAX!";
						Player[fiPlayerNumber].Cash -= 200;
						if (Config.FreeParking == true) {
							Board.GameLog = "      PAY $200 TO FREE PARKING";
							FreeParkingCash += 200;
						} else {
							Board.GameLog = "      PAY $200";
						}
						break;
					case "Chance":
						Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " LANDS ON CHANCE! DRAW CARD:";
						string fsChanceCard;
						fsChanceCard = ChanceDeck.DrawCard();
						Board.GameLog = "      " + fsChanceCard;
						ExecuteCardDesc("Chance", fsChanceCard, fiPlayerNumber);
						break;
					case "Just Visiting":
						break;
					case "Free Parking":
						Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " LANDS ON FREE PARKING!";
						if (Config.FreeParking == true) {
							Board.GameLog = "      COLLECT " + FreeParkingCash.ToString("C0");
							Player[fiPlayerNumber].Cash += FreeParkingCash;
							if (Config.FreeParking500 == true) {
								FreeParkingCash = 500;
								Board.GameLog = "      FREE PARKING RESET TO $500";
							} else {
								FreeParkingCash = 0;
								Board.GameLog = "      FREE PARKING RESET TO $0";
							}
						}
						break;
					case "Luxury Tax":
						Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " LANDS ON LUXURY TAX!";
						Player[fiPlayerNumber].Cash -= 75;
						if (Config.FreeParking == true) {
							Board.GameLog = "      PAY $75 TO FREE PARKING";
							FreeParkingCash += 75;
						} else {
							Board.GameLog = "      PAY $75";
						}
						break;
				}
			} else {
				// If property is a purchasable type
				if (Property[fiPosition].Owner == -1) {
					// If Property is Unowned
					StrategyClass Strategy = new StrategyClass(Player[fiPlayerNumber]);
					if (Strategy.BuyProperty(fiPosition) == true) {
						PlayerBuysProperty(fiPlayerNumber, fiPosition);
					}
				} else {
					if (Property[fiPosition].Owner != fiPlayerNumber) {
						// If landed on someone else's property
						PlayerPaysRent(fiPlayerNumber, fiPosition);
					}
				}
			}
		}
		
		public static void PlayerPaysRent(int fiPlayerNumber, int fiPropertyPosition) {
			if (ciTempSpecialRent == false) {
				// If there is no special rent multiplier/case (Chance/Community Chest Cards cause this)
				if (Property[fiPropertyPosition].ColorNum != 9) {
					// If property is not a Utility
					Player[fiPlayerNumber].Cash -= Property[fiPropertyPosition].Rent;
					Player[Property[fiPropertyPosition].Owner].Cash += Property[fiPropertyPosition].Rent;
					Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " PAYS Player" + Property[fiPropertyPosition].Owner.ToString() + " " + Property[fiPropertyPosition].Rent.ToString("C0") + " RENT";
				} else {
					// If property is a Utility
					int iTempPayAmount;
					if (Property[fiPropertyPosition].MonopolyStatus == false) {
						// If both are not owned pay 4x dice roll
						iTempPayAmount = ciTotal * 4;
						Player[fiPlayerNumber].Cash -= iTempPayAmount;
						Player[Property[fiPropertyPosition].Owner].Cash += iTempPayAmount;
						Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " PAYS Player" + Property[fiPropertyPosition].Owner.ToString() + " " + iTempPayAmount.ToString("C0") + " (" + ciTotal.ToString() + "*4) RENT";
					} else {
						// If both are owned pay 10x dice roll
						iTempPayAmount = ciTotal * 10;
						Player[fiPlayerNumber].Cash -= iTempPayAmount;
						Player[Property[fiPropertyPosition].Owner].Cash += iTempPayAmount;
						Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " PAYS Player" + Property[fiPropertyPosition].Owner.ToString() + " " + iTempPayAmount.ToString("C0") + " (" + ciTotal.ToString() + "*10) RENT";
					}
				}
			} else {
				// If there is a special rent multiplier/case (Chance/Community Chest Cards cause this)
				int iTempPayAmount;
				if (Property[fiPropertyPosition].ColorNum == 9) {
					// If property is a Utility
					Random Random = new Random(RandomSeed);
					// Reroll per card text
					ciDice1 = Random.Next(1, 7);
					ciDice2 = Random.Next(1, 7);
					ciTotal = ciDice1 + ciDice2;
					iTempPayAmount = ciTotal * 10;
					Player[fiPlayerNumber].Cash -= iTempPayAmount;
					Player[Property[fiPropertyPosition].Owner].Cash += iTempPayAmount;
					Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " ROLLED " + ciTotal.ToString() + " (" + ciDice1.ToString() + "+" + ciDice2.ToString() + ")";
					Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " PAYS Player" + Property[fiPropertyPosition].Owner.ToString() + " " + iTempPayAmount.ToString("C0") + " (" + ciTotal.ToString() + "*10) RENT";
				} else if (Property[fiPropertyPosition].ColorNum == 8) {
					iTempPayAmount = Property[fiPropertyPosition].Rent * ciTempRentMultiplier;
					Player[fiPlayerNumber].Cash -= iTempPayAmount;
					Player[Property[fiPropertyPosition].Owner].Cash += iTempPayAmount;
					Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " PAYS Player" + Property[fiPropertyPosition].Owner.ToString() + " " + iTempPayAmount.ToString("C0") + " (" + Property[fiPropertyPosition].Rent.ToString() + "*" + ciTempRentMultiplier.ToString() + ") RENT";
				}
				ciTempRentMultiplier = 1;
				ciTempSpecialRent = false;
			}
		}
		
		public static void PlayerBuysProperty(int fiPlayerNumber, int fiPropertyPosition) {
			int iTempMonopolyProgress = 0;
			// Set New Owner
			Property[fiPropertyPosition].Owner = fiPlayerNumber;
			Board.GameLog = "   Player" + fiPlayerNumber.ToString() + " BUYS " + fiPropertyPosition.ToString() + " (" + Property[fiPropertyPosition].Name + ")";
			// Deducts Appropriate Cash
			Player[fiPlayerNumber].Cash -= Property[fiPropertyPosition].Cost;
			Board.GameLog = "      PAY " + Property[fiPropertyPosition].Cost.ToString("C0");
			// Adds Mortgage Value to Player's Assets
			Player[fiPlayerNumber].Assets += Property[fiPropertyPosition].MortgageValue;
			for (int i = 0; i <= 39; i++) {
				// For each property
				if (Property[i].Owner == Property[fiPropertyPosition].Owner) {
					// If the current Iteration's Property's Owner is the player who just purchased property
					if (Property[i].ColorNum == Property[fiPropertyPosition].ColorNum) {
						// If the colors match, increment monopoly progress
						iTempMonopolyProgress++;
					}
				}
			}
			// Update all owned color's monopoly progress (keeps them all in sync).
			for (int i = 0; i <= 39; i++) {
				if (Property[i].Owner == Property[fiPropertyPosition].Owner) {
					if (Property[i].ColorNum == Property[fiPropertyPosition].ColorNum) {
						Property[i].MonopolyProgress = iTempMonopolyProgress;
						Board.GameLog = "      INCREMENT " + i.ToString() + "'s MONOPOLY PROGRESS";
						Board.GameLog = "         Player" + fiPlayerNumber.ToString() + " CURRENT " + Property[i].ColorStr + " MONOPOLY PROGRESS: " + Property[i].MonopolyProgress.ToString();
						if (Property[i].ColorNum == 0 || Property[i].ColorNum == 7 || Property[i].ColorNum == 9) {
							// If Property is Brown, Dark Blue, or a Utility
							if (Property[i].MonopolyProgress == 2) {
								Property[i].MonopolyStatus = true;
								Property[i].Rent = Property[i].MonopolyRent;
								MessageBox.Show("Monopoly on " + Property[i].ColorStr);
								Board.GameLog = "      " + i.ToString() + "'s MONOPOLY STATUS: TRUE";
							} else {
								Property[i].MonopolyStatus = false;
								Property[i].Rent = Property[i].NormalRent;
								Board.GameLog = "      " + i.ToString() + "'s MONOPOLY STATUS: FALSE";
							}
						} else if (Property[i].ColorNum == 8) {
							// If property is a railroad
							if (Property[i].MonopolyProgress == 1) {
								Property[i].Rent = 25;
							} else if (Property[i].MonopolyProgress == 2) {
								Property[i].Rent = 50;
							} else if (Property[i].MonopolyProgress == 3) {
								Property[i].Rent = 100;
							} else if (Property[i].MonopolyProgress == 4) {
								Property[i].Rent = 200;
							}
						} else {
							if (Property[i].MonopolyProgress == 3) {
								Property[i].MonopolyStatus = true;
								Property[i].Rent = Property[i].MonopolyRent;
								MessageBox.Show("Monopoly on " + Property[i].ColorStr);
								Board.GameLog = "      " + i.ToString() + "'s MONOPOLY STATUS: TRUE";
							} else {
								Property[i].MonopolyStatus = false;
								Property[i].Rent = Property[i].NormalRent;
								Board.GameLog = "      " + i.ToString() + "'s MONOPOLY STATUS: FALSE";
							}
						}
					}
				}
			}
		}


		public static void ExecuteCardDesc(string fsCardType, string fsCardText, int fiPlayerNumber) {
			int fiTempSpacesToMove;
			if (fsCardType == "Chance") {
				switch (fsCardText) {
					case "GET OUT OF JAIL FREE.":
						Player[fiPlayerNumber].HasGetOutOfJailFree = true;
						Board.GameLog = "      RECIEVED \"GET OUT OF JAIL FREE\" CARD!";
						break;
					case "ADVANCE TO ST. CHARLES PLACE. IF YOU PASS \"GO\" COLLECT $200.":
						if (Player[fiPlayerNumber].CurrentPosition > 11) {
							// If player is past St. Charles Place figure out spaces to GO then add 11.
							fiTempSpacesToMove = (40 - Player[fiPlayerNumber].CurrentPosition) + 11;
						} else {
							// If player is before St. Charles Place figure out spaces to St. Charles Place
							fiTempSpacesToMove = (11 - Player[fiPlayerNumber].CurrentPosition);
						}
						MovePlayerAhead(fiPlayerNumber, fiTempSpacesToMove);
						break;
					case "BANK PAYS YOU DIVIDEND OF $50.":
						Player[fiPlayerNumber].Cash += 50;
						Board.GameLog = "      COLLECT $50";
						break;
					case "Your building loan matures. Collect $150.":
						Player[fiPlayerNumber].Cash += 150;
						Board.GameLog = "      COLLECT $150";
						break;
					case "ADVANCE TO THE NEAREST RAILROAD.":
						ciTempRentMultiplier = 2;
						ciTempSpecialRent = true;
						if (Player[fiPlayerNumber].CurrentPosition == 7) {
							MovePlayerAhead(fiPlayerNumber, 8);
						} else if (Player[fiPlayerNumber].CurrentPosition == 22) {
							MovePlayerAhead(fiPlayerNumber, 3);
						} else if (Player[fiPlayerNumber].CurrentPosition == 36) {
							MovePlayerAhead(fiPlayerNumber, 9);
						}
						break;
					case "YOU HAVE BEEN ELECTED CHAIRMAN OF THE BOARD. PAY EACH PLAYER $50.":
						for (int i = 0; i < TotalPlayers; i++) {
							if (i != fiPlayerNumber) {
								Player[fiPlayerNumber].Cash -= 50;
								Player[i].Cash += 50;
								Board.GameLog = "      PAY PLAYER" + i.ToString() + " $50";
							}
						}
						break;
					case "MAKE GENERAL REPAIRS ON ALL YOUR PROPERTY: FOR EACH HOUSE PAY $25, FOR EACH HOTEL PAY $100.":
						int iMoneyToPay = 0;
						for (int i = 0; i <= 39; i++) {
							if (Property[i].Owner == fiPlayerNumber) {
								if (Property[i].Improvements <= 4) {
									iMoneyToPay += Property[i].Improvements * 25;
								} else if (Property[i].Improvements == 5) {
									iMoneyToPay += Property[i].Improvements * 100;
								}
							}
						}
						Player[fiPlayerNumber].Cash -= iMoneyToPay;
						if (Config.FreeParking == true) {
							Board.GameLog = "      PAY " + iMoneyToPay.ToString("C0") + " TO FREE PARKING";
							FreeParkingCash += iMoneyToPay;
						} else {
							Board.GameLog = "      PAY " + iMoneyToPay.ToString("C0");
						}
						break;
					case "GO BACK THREE SPACES.":
						if (Player[fiPlayerNumber].CurrentPosition == 7) {
							MovePlayerToSpace(fiPlayerNumber, 4);
						} else if (Player[fiPlayerNumber].CurrentPosition == 22) {
							MovePlayerToSpace(fiPlayerNumber, 19);
						} else if (Player[fiPlayerNumber].CurrentPosition == 36) {
							MovePlayerToSpace(fiPlayerNumber, 33);
						}
						break;
					case "TAKE A TRIP TO READING RAILROAD. IF YOU PASS \"GO\" COLLECT $200.":
						if (Player[fiPlayerNumber].CurrentPosition > 5) {
							// If player is past Reading Railroad figure out spaces to GO then add 5.
							fiTempSpacesToMove = (40 - Player[fiPlayerNumber].CurrentPosition) + 5;
						} else {
							// If player is before Reading Railroad figure out spaces to Reading Railroad
							fiTempSpacesToMove = (5 - Player[fiPlayerNumber].CurrentPosition);
						}
						MovePlayerAhead(fiPlayerNumber, fiTempSpacesToMove);
						break;
					case "ADVANCE TO ILLINOIS AVENUE. IF YOU PASS \"GO\" COLLECT $200.":
						if (Player[fiPlayerNumber].CurrentPosition > 24) {
							// If player is past Illinois Avenue figure out spaces to GO then add 24.
							fiTempSpacesToMove = (40 - Player[fiPlayerNumber].CurrentPosition) + 24;
						} else {
							// If player is before Illinois Avenue figure out spaces to Illinois Avenue
							fiTempSpacesToMove = (24 - Player[fiPlayerNumber].CurrentPosition);
						}
						MovePlayerAhead(fiPlayerNumber, fiTempSpacesToMove);
						break;
					case "ADVANCE TO \"GO\". (COLLECT $200)":
						fiTempSpacesToMove = (40 - Player[fiPlayerNumber].CurrentPosition);
						MovePlayerAhead(fiPlayerNumber, fiTempSpacesToMove);
						break;
					case "GO TO JAIL. GO DIRECTLY TO JAIL, DO NOT PASS \"GO\", DO NOT COLLECT $200.":
						DoublesCount = 0;													// Reset DoubleCounter to 0
						MovePlayerToJail(fiPlayerNumber);
						if (PlayerTurn == 3) { PlayerTurn = 0; } else { PlayerTurn++; }		// Set Next Player's Turn
						break;
					case "ADVANCE TO THE NEAREST UTILITY.":
						ciTempRentMultiplier = 10;
						ciTempSpecialRent = true;
						if (Player[fiPlayerNumber].CurrentPosition == 7) {
							MovePlayerAhead(fiPlayerNumber, 5);
						} else if (Player[fiPlayerNumber].CurrentPosition == 22) {
							MovePlayerAhead(fiPlayerNumber, 6);
						} else if (Player[fiPlayerNumber].CurrentPosition == 36) {
							MovePlayerAhead(fiPlayerNumber, 16);
						}
						break;
					case "SPEEDING FINE $15.":
						Player[fiPlayerNumber].Cash -= 15;
						if (Config.FreeParking == true) {
							Board.GameLog = "      PAY $15 TO FREE PARKING";
							FreeParkingCash += 15;
						} else {
							Board.GameLog = "      PAY $15";
						}
						break;
					case "ADVANCE TO BOARDWALK":
						fiTempSpacesToMove = (39 - Player[fiPlayerNumber].CurrentPosition);
						MovePlayerAhead(fiPlayerNumber, fiTempSpacesToMove);
						break;
				}
			} else if (fsCardType == "Community Chest") {
				switch (fsCardText) {
					case "LIFE INSURANCE MATURES. COLLECT $100.":
						Player[fiPlayerNumber].Cash += 100;
						Board.GameLog = "      COLLECT $100";
						break;
					case "DOCTOR'S FEES. PAY $50.":
						Player[fiPlayerNumber].Cash -= 50;
						if (Config.FreeParking == true) {
							Board.GameLog = "      PAY $50 TO FREE PARKING";
							FreeParkingCash += 50;
						} else {
							Board.GameLog = "      PAY $50";
						}
						break;
					case "FROM SALE OF STOCK YOU GET $50.":
						Player[fiPlayerNumber].Cash += 50;
						Board.GameLog = "      COLLECT $50";
						break;
					case "IT IS YOUR BIRTHDAY. COLLECT $10 FROM EVERY PLAYER":
						for (int i = 0; i < TotalPlayers; i++)
						{
							if (i != fiPlayerNumber)
							{
								Player[fiPlayerNumber].Cash += 10;
								Player[i].Cash -= 10;
								Board.GameLog = "      COLLECT $10 FROM PLAYER" + i.ToString();
							}
						}
						break;
					case "PAY HOSPITAL FEES OF $100.":
						Player[fiPlayerNumber].Cash -= 100;
						if (Config.FreeParking == true) {
							Board.GameLog = "      PAY $100 TO FREE PARKING";
							FreeParkingCash += 100;
						} else {
							Board.GameLog = "      PAY $100";
						}
						break;
					case "BANK ERROR IN YOUR FAVOR. COLLECT $200.":
						Player[fiPlayerNumber].Cash += 200;
						Board.GameLog = "      COLLECT $200";
						break;
					case "YOU INHERIT $100.":
						Player[fiPlayerNumber].Cash += 100;
						Board.GameLog = "      COLLECT $100";
						break;
					case "YOU ARE ASSESSED FOR STREET REPAIRS: $40 PER HOUSE, $115 PER HOTEL.":
						int iMoneyToPay = 0;
						for (int i = 0; i <= 39; i++)
						{
							if (Property[i].Owner == fiPlayerNumber)
							{
								if (Property[i].Improvements <= 4)
								{
									iMoneyToPay += Property[i].Improvements * 40;
								}
								else if (Property[i].Improvements == 5)
								{
									iMoneyToPay += Property[i].Improvements * 115;
								}
							}
						}
						Player[fiPlayerNumber].Cash -= iMoneyToPay;
						if (Config.FreeParking == true) {
							Board.GameLog = "      PAY " + iMoneyToPay.ToString("C0") + " TO FREE PARKING";
							FreeParkingCash += iMoneyToPay;
						} else {
							Board.GameLog = "      PAY " + iMoneyToPay.ToString("C0");
						}
						break;
					case "GO TO JAIL. GO DIRECTLY TO JAIL, DO NOT PASS \"GO\", DO NOT COLLECT $200.":
						DoublesCount = 0;													// Reset DoubleCounter to 0
						MovePlayerToJail(fiPlayerNumber);
						if (PlayerTurn == 3) { PlayerTurn = 0; } else { PlayerTurn++; }		// Set Next Player's Turn
						break;
					case "GET OUT OF JAIL FREE.":
						Player[fiPlayerNumber].HasGetOutOfJailFree = true;
						Board.GameLog = "      RECIEVED \"GET OUT OF JAIL FREE\" CARD!";
						break;
					case "HOLIDAY FUND MATURES. RECEIVE $100.":
						Player[fiPlayerNumber].Cash += 100;
						Board.GameLog = "      COLLECT $100";					
						break;
					case "RECEIVE $25 CONSULTANCY FEE.":
						Player[fiPlayerNumber].Cash += 25;
						Board.GameLog = "      COLLECT $25";
						break;
					case "YOU HAVE WON SECON PRIZE IN A BEAUTY CONTEST. COLLECT $10.":
						Player[fiPlayerNumber].Cash += 10;
						Board.GameLog = "      COLLECT $10";
						break;
					case "ADVANCE TO GO. (COLLECT $200)":
						fiTempSpacesToMove = (40 - Player[fiPlayerNumber].CurrentPosition);
						MovePlayerAhead(fiPlayerNumber, fiTempSpacesToMove);					
						break;
					case "PAY SCHOOL FEES OF $50.":
						Player[fiPlayerNumber].Cash -= 50;
						if (Config.FreeParking == true) {
							Board.GameLog = "      PAY $50 TO FREE PARKING";
							FreeParkingCash += 50;
						} else {
							Board.GameLog = "      PAY $50";
						}
						break;
					case "INCOME TAX REFUND. COLLECT $20.":
						Player[fiPlayerNumber].Cash += 20;
						Board.GameLog = "      COLLECT $20";
						break;
				}
			}
		}
		
	}
}
