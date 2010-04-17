using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace MonopolySim
{
	public class PlayerClass : INotifyPropertyChanged
	{
		int ciPropertiesOwned, ciCurrentPosition, ciTurnInJail;
		int ciNumber, ciCash, ciAssets;
		bool cbHasGetOutOfJailFree;
		string csMouseOverBox;
		int ciStatRentPaid, ciStatMovesMade, ciStatTimesPassingGo, ciStatTimesInJail, ciStatTurnsInJail, ciStatMoneyToFreeParking,
			ciStatTotalCommunityChestCardsDrawn, ciStatTotalChanceCardsDrawn, ciStatMostMoneyHeld, ciStatMostMoneyTurn,
			ciStatMostAssets, ciStatMostAssetsTurn;

		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}  

		public PlayerClass() {
			ciCash = 1300;
			RecalcAssets();
			MouseOverBoxUpdate();
		}
		
		
		// Player Properties
		public int Number
		{
			// Player Number
			get { return ciNumber; }
			set { ciNumber = value; MouseOverBoxUpdate(); }
		}
		public int PropertiesOwned
		{
			// Number of Properties this player owns
			get { return ciPropertiesOwned; }
			set { ciPropertiesOwned = value; }
		}
		public int CurrentPosition
		{
			// Current Board Position
			//		30 = In Jail
			get { return ciCurrentPosition; }
			set { ciCurrentPosition = value; }
		}
		public int TurnInJail
		{
			// Current turn number in jail for this stay only
			//		0 - Not in Jail
			//		1 - In Jail for 1 Turn
			//		2 - In Jail for 2 Turns
			//		3 - In Jail for 3 Turns
			get { return ciTurnInJail; }
			set { ciTurnInJail = value; }
		}
		public int Cash
		{
			// Cash on Hand
			get { return ciCash; }
			set {
				ciCash = value;
				RecalcAssets();
				MouseOverBoxUpdate();
			}
		}
		public int Assets
		{
			// Assets on Hand
			get { return ciAssets; }
			set {
				ciAssets = value;
				RecalcAssets();
				MouseOverBoxUpdate();
			}
		}
		public bool HasGetOutOfJailFree
		{
			// Has a "Get Out Of Jail Free" card
			get { return cbHasGetOutOfJailFree; }
			set { cbHasGetOutOfJailFree = value; }
		}
		// Board Information
		public string MouseOverBox
		{
			// Content for mouseover box
			get { return csMouseOverBox; }
			set { csMouseOverBox = value; }
		}
		// Player Statistics
		public int StatRentPaid
		{
			// Total rent player has paid
			get { return ciStatRentPaid; }
			set { ciStatRentPaid = value; }
		}
		public int StatMovesMade
		{
			// Total number of moves player has made
			get { return ciStatMovesMade; }
			set { ciStatMovesMade = value; }
		}
		public int StatTimesPassingGo
		{
			// Total number of times player has passed GO
			get { return ciStatTimesPassingGo; }
			set { ciStatTimesPassingGo = value; }
		}
		public int StatTimesInJail
		{
			// Total number of times player has gone to jail
			get { return ciStatTimesInJail; }
			set { ciStatTimesInJail = value; }
		}
		public int StatTurnsInJail
		{
			// Total number of turns player has spent in jail
			get { return ciStatTurnsInJail; }
			set { ciStatTurnsInJail = value; }
		}
		public int StatMoneyToFreeParking
		{
			// Total amount of money player has contributed to Free Parking
			get { return ciStatMoneyToFreeParking; }
			set { ciStatMoneyToFreeParking = value; }
		}
		public int StatTotalCommunityChestCardsDrawn
		{
			// Total number of Community Chest Cards drawn
			get { return ciStatTotalCommunityChestCardsDrawn; }
			set { ciStatTotalCommunityChestCardsDrawn = value; }
		}
		public int StatTotalChanceCardsDrawn
		{
			// Total number of Chance cards drawn
			get { return ciStatTotalChanceCardsDrawn; }
			set { ciStatTotalChanceCardsDrawn = value; }
		}
		public int StatMostMoneyHeld
		{
			// Most money ever held at one time
			get { return ciStatMostMoneyHeld; }
			set { ciStatMostMoneyHeld = value; }
		}
		public int StatMostMoneyTurn
		{
			// Turn that the most money was ever held on
			get { return ciStatMostMoneyTurn; }
			set { ciStatMostMoneyTurn = value; }
		}
		public int StatMostAssets
		{
			// Most assets ever held at one time
			//		Cash + Properties Mortgage Value (including houses/hotels) + (GetOutOfJailCards * 50)
			get { return ciStatMostAssets; }
			set { ciStatMostAssets = value; }
		}
		public int StatMostAssetsTurn
		{
			// Turn that the most assets was ever held on
			get { return ciStatMostAssetsTurn; }
			set { ciStatMostAssetsTurn = value; }
		}

		private void MouseOverBoxUpdate() {
			csMouseOverBox = "Player " + ciNumber.ToString() + ": " + ciCash.ToString("C0") + " | " + ciAssets.ToString("C0");
			NotifyPropertyChanged("MouseOverBox");
		}

		private void RecalcAssets() {
			ciAssets = ciCash;
			for (int i = 0; i <= 39; i++) {
				if (GameClass.Property[i].Owner == ciNumber) {
					ciAssets += GameClass.Property[i].MortgageValue;
					ciAssets += GameClass.Property[i].Improvements * GameClass.Property[i].HouseCost;
				}
			}
			if (cbHasGetOutOfJailFree == true) { ciAssets += 50; }
		}
	}
}
