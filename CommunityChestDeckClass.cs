using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySim
{
	public class CommunityChestDeckClass
	{

		private string[,] csCommunityChestCard = new string[16, 2];
		private string[,] csCommunityChestDeck = new string[16, 2];
		private string[,] csCommunityChestDiscard = new string[16, 2];
		private bool cbGetOutOfJailInDeck = true;

		public CommunityChestDeckClass()
		{
			// Constructor which loads card array, copies them to the deck and shuffles.
			ResetDeck();
		}

		public string CommunityChestDeck(int fiCard, int fiAttrib)
		{
			// Picks any card from the deck.
			return csCommunityChestDeck[fiCard, fiAttrib];
		}

		public string DrawCard()
		{
			for (int i = 0; i <= 15; i++)
			{
				if (csCommunityChestDeck[i, 0] != "")
				{
					// Find the first remaining card in the deck
					if (csCommunityChestDeck[i, 0] == "GET OUT OF JAIL FREE.")
					{
						cbGetOutOfJailInDeck = false;
					}
					string csTempCardText;
					csTempCardText = csCommunityChestDeck[i, 0];
					DiscardCard(i);
					return csTempCardText;
				}
			}
			// If there are no more free cards, reset the deck and recall function.
			ResetDeck();
			return DrawCard();
		}

		public void DiscardCard(int fiCardToDiscard)
		{
			// Set card's statistics to null as to make it so it is hidden
			csCommunityChestDeck[fiCardToDiscard, 0] = "";
			csCommunityChestDeck[fiCardToDiscard, 1] = "";
		}

		public void ReinsertGetOutOfJailFree()
		{
			// Reinsert Get Out of Jail Free card into deck. Next Reset, card will be present.
			cbGetOutOfJailInDeck = true;
		}


		public void ResetDeck()
		{
			GenerateCards();
			PopulateDeck();
			ShuffleDeck();
		}

		public void ShuffleDeck()
		{
			// Shuffle deck by picking two random numbers and swapping the cards at those positions.
			string temp0, temp1, temp2, temp3;
			int index1, index2;
			Random Random = new Random();
			for (int i = 0; i <= 250; i++) {
				index1 = Random.Next(0, 16);
				index2 = Random.Next(0, 16);
				if (index1 != index2) {
					temp0 = csCommunityChestDeck[index1,0]; temp1 = csCommunityChestDeck[index1,1];
					temp2 = csCommunityChestDeck[index2,0]; temp3 = csCommunityChestDeck[index2,1];
					csCommunityChestDeck[index1,0] = temp2; csCommunityChestDeck[index1,1] = temp3;
					csCommunityChestDeck[index2,0] = temp0; csCommunityChestDeck[index2,1] = temp1;
				} else {
					i--;
					continue;
				}
			}
		}

		private void PopulateDeck()
		{
			// Copies Card List into Deck.
			csCommunityChestDeck = csCommunityChestCard;
		}

		private void GenerateCards() {
			// Creats card array based on official Monopoly Community Chest cards.
			csCommunityChestCard[0,0] = "LIFE INSURANCE MATURES. COLLECT $100.";
			csCommunityChestCard[0,1] = "";
			csCommunityChestCard[1,0] = "DOCTOR'S FEES. PAY $50.";
			csCommunityChestCard[1,1] = "";
			csCommunityChestCard[2,0] = "FROM SALE OF STOCK YOU GET $50.";
			csCommunityChestCard[2,1] = "";
			csCommunityChestCard[3,0] = "IT IS YOUR BIRTHDAY. COLLECT $10 FROM EVERY PLAYER";
			csCommunityChestCard[3,1] = "";
			csCommunityChestCard[4,0] = "PAY HOSPITAL FEES OF $100.";
			csCommunityChestCard[4,1] = "";
			csCommunityChestCard[5,0] = "BANK ERROR IN YOUR FAVOR. COLLECT $200.";
			csCommunityChestCard[5,1] = "";
			csCommunityChestCard[6,0] = "YOU INHERIT $100.";
			csCommunityChestCard[6,1] = "";
			csCommunityChestCard[7,0] = "YOU ARE ASSESSED FOR STREET REPAIRS: $40 PER HOUSE, $115 PER HOTEL.";
			csCommunityChestCard[7,1] = "";
			csCommunityChestCard[8,0] = "GO TO JAIL. GO DIRECTLY TO JAIL, DO NOT PASS \"GO\", DO NOT COLLECT $200.";
			csCommunityChestCard[8,1] = "";
			if (cbGetOutOfJailInDeck == true) {
				csCommunityChestCard[9,0] = "GET OUT OF JAIL FREE.";
				csCommunityChestCard[9,1] = "This card may be kept until needed or traded.";
			} else {
				csCommunityChestCard[9, 0] = "";
				csCommunityChestCard[9, 1] = "";
			}
			csCommunityChestCard[10,0] = "HOLIDAY FUND MATURES. RECEIVE $100.";
			csCommunityChestCard[10,1] = "";
			csCommunityChestCard[11,0] = "RECEIVE $25 CONSULTANCY FEE.";
			csCommunityChestCard[11,1] = "";
			csCommunityChestCard[12,0] = "YOU HAVE WON SECON PRIZE IN A BEAUTY CONTEST. COLLECT $10.";
			csCommunityChestCard[12,1] = "";
			csCommunityChestCard[13,0] = "ADVANCE TO GO. (COLLECT $200)";
			csCommunityChestCard[13,1] = "";
			csCommunityChestCard[14,0] = "PAY SCHOOL FEES OF $50.";
			csCommunityChestCard[14,1] = "";
			csCommunityChestCard[15,0] = "INCOME TAX REFUND. COLLECT $20.";
			csCommunityChestCard[15,1] = "";
		}
	}
}
