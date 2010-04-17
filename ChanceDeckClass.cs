using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySim
{
	public class ChanceDeckClass
	{

		private string[,] csChanceCard = new string[16, 2];
		private string[,] csChanceDeck = new string[16, 2];
		private string[,] csChanceDiscard = new string[16, 2];
		private bool cbGetOutOfJailInDeck = true;
		
		public string ChanceDeck(int fiCard, int fiAttrib) {
			// Picks any card from the deck.
			return csChanceDeck[fiCard, fiAttrib];
		}
		
		public ChanceDeckClass()
		{
			// Constructor which loads card array, copies them to the deck and shuffles.
			ResetDeck();
		}
		
		public string DrawCard() {
			for (int i = 0; i <= 15; i++) {
				if (csChanceDeck[i, 0] != "") {
					// Find the first remaining card in the deck
					if (csChanceDeck[i, 0] == "GET OUT OF JAIL FREE.") {
						cbGetOutOfJailInDeck = false;
					}
					string csTempCardText;
					csTempCardText = csChanceDeck[i,0];
					DiscardCard(i);
					return csTempCardText;
				}
			}
			// If there are no more free cards, reset the deck and recall function.
			ResetDeck();
			return DrawCard();
		}
		
		public void DiscardCard(int fiCardToDiscard) {
			// Set card's statistics to null as to make it so it is hidden
			csChanceDeck[fiCardToDiscard, 0] = "";
			csChanceDeck[fiCardToDiscard, 1] = "";
		}
		
		public void ReinsertGetOutOfJailFree() {
			// Reinsert Get Out of Jail Free card into deck. Next Reset, card will be present.
			cbGetOutOfJailInDeck = true;
		}
		
		public void ShuffleDeck()
		{
			// Shuffle deck by picking two random numbers and swapping the cards at those positions.
			string temp0, temp1, temp2, temp3;
			int index1, index2;
			Random Random = new Random();
			for (int i = 0; i <= 250; i++)
			{
				index1 = Random.Next(0, 16);
				index2 = Random.Next(0, 16);
				if (index1 != index2) {
					temp0 = csChanceDeck[index1, 0]; temp1 = csChanceDeck[index1, 1];
					temp2 = csChanceDeck[index2, 0]; temp3 = csChanceDeck[index2, 1];
					csChanceDeck[index1, 0] = temp2; csChanceDeck[index1, 1] = temp3;
					csChanceDeck[index2, 0] = temp0; csChanceDeck[index2, 1] = temp1;
				}
				else
				{
					i--;
					continue;
				}
			}
		}


		public void ResetDeck()
		{
			GenerateCards();
			PopulateDeck();
			ShuffleDeck();
		}
		
		private void PopulateDeck() {
			// Copies Card List into Deck.
			csChanceDeck = csChanceCard;
		}

		private void GenerateCards() {
			// Creats card array based on official Monopoly Community Chest cards.
			if (cbGetOutOfJailInDeck == true) {
				csChanceCard[0,0] = "GET OUT OF JAIL FREE.";
				csChanceCard[0,1] = "This card may be kept until needed or traded.";
			} else {
				csChanceCard[0, 0] = "";
				csChanceCard[0, 1] = "";			
			}
			csChanceCard[1,0] = "ADVANCE TO ST. CHARLES PLACE. IF YOU PASS \"GO\" COLLECT $200.";
			csChanceCard[1,1] = "";
			csChanceCard[2,0] = "BANK PAYS YOU DIVIDEND OF $50.";
			csChanceCard[2,1] = "";
			csChanceCard[3,0] = "Your building loan matures. Collect $150.";
			csChanceCard[3,1] = "";
			csChanceCard[4,0] = "ADVANCE TO THE NEAREST RAILROAD.";
			csChanceCard[4,1] = "If UNOWNED, you may buy it from the Bank. If OWNED, pay owner twice the rental to which they are otherwise entitled.";
			csChanceCard[5,0] = "ADVANCE TO THE NEAREST RAILROAD.";
			csChanceCard[5,1] = "If UNOWNED, you may buy it from the Bank. If OWNED, pay owner twice the rental to which they are otherwise entitled.";
			csChanceCard[6,0] = "YOU HAVE BEEN ELECTED CHAIRMAN OF THE BOARD. PAY EACH PLAYER $50.";
			csChanceCard[6,1] = "";
			csChanceCard[7,0] = "MAKE GENERAL REPAIRS ON ALL YOUR PROPERTY: FOR EACH HOUSE PAY $25, FOR EACH HOTEL PAY $100.";
			csChanceCard[7,1] = "";
			csChanceCard[8,0] = "GO BACK THREE SPACES.";
			csChanceCard[8,1] = "";
			csChanceCard[9,0] = "TAKE A TRIP TO READING RAILROAD. IF YOU PASS \"GO\" COLLECT $200.";
			csChanceCard[9,1] = "";
			csChanceCard[10,0] = "ADVANCE TO ILLINOIS AVENUE. IF YOU PASS \"GO\" COLLECT $200.";
			csChanceCard[10,1] = "";
			csChanceCard[11,0] = "ADVANCE TO \"GO\". (COLLECT $200)";
			csChanceCard[11,1] = "";
			csChanceCard[12,0] = "GO TO JAIL. GO DIRECTLY TO JAIL, DO NOT PASS \"GO\", DO NOT COLLECT $200.";
			csChanceCard[12,1] = "";
			csChanceCard[13,0] = "ADVANCE TO THE NEAREST UTILITY.";
			csChanceCard[13,1] = "If UNOWNED, you may buy it from the Bank. If OWNED, throw dice and pay owner a total 10 times amount thrown.";
			csChanceCard[14,0] = "SPEEDING FINE $15.";
			csChanceCard[14,1] = "";
			csChanceCard[15,0] = "ADVANCE TO BOARDWALK";
			csChanceCard[15,1] = "";

		}

	}
}
