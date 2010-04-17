using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace MonopolySim
{
	public class PropertyClass : INotifyPropertyChanged
	{
		int ciPosition, ciColorNum, ciMonopolyProgress, ciImprovements;
		int ciOwner = -1;
		bool[] cbPlayerOnSpace = new bool[4];
		string csName, csColorStr, csDescriptionBox, csImprovementBox, csPlayerBox;
		int ciCost, ciMortgageValue, ciHouseCost, ciNormalRent, ciMonopolyRent, ciHouseOneRent, ciHouseTwoRent,
			ciHouseThreeRent, ciHouseFourRent, ciHotelRent, ciRent;
		int ciStatTotalTimesLandedOn, ciStatTimesLandedOnNoMonopoly, ciStatTimesLandedOnMonopoly,
			ciStatTimesLandedOnOneHouse, ciStatTimesLandedOnTwoHouses, ciStatTimesLandedOnThreeHouses,
			ciStatTimesLandedOnFourHouses, ciStatTimesLandedOnHotel, ciStatRentCollected, ciStatTurnBoughtOn,
			ciStatTimesTraded;
		bool cbMonopolyStatus;
		
		public PropertyClass() {
			// Null Constructor
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}  
		// Static Properties
		public int Position
		{
			// Board Position
			//		0-39
			get { return ciPosition; }
		}
		public string Name
		{
			// Property Name
			get { return csName; }
		}
		public int ColorNum
		{
			// Property Color
			//		-1 - No Color (Non-purchasable Space)
			//		0 - Indigo (Mediterranean Avenue, Baltic Avenue)
			//		1 - Light Blue (Oriental Avenue, Vermont Avenue, Connecticut Avenue)
			//		2 - Purple (St. Charles Place, States Avenue, Virginia Avenue)
			//		3 - Orange (St. James Place, Tennessee Avenue, New York Avenue)
			//		4 - Red (Kentucky Avenue, Indiana Avenue, Illinois Avenue)
			//		5 - Yellow (Atlantic Avenue, Ventnor Avenue, Marvin Gardens)
			//		6 - Green (Pacific Avenue, North Carolina Avenue, Pennsylvania Avenue)
			//		7 - Blue (Park Place, Boardwalk)
			//		8 - Railroad (Reading Railroad, Pennsylvania Railroad, B&O Railroad, Short Line)
			//		9 - Utility (Electric Company, Water Works)
			get { return ciColorNum; }
		}
		public string ColorStr
		{
			// Property Color Name
			//		No Color
			//		Indigo
			//		Light Blue
			//		Purple
			//		Orange
			//		Red
			//		Yellow
			//		Green
			//		Blue
			//		Railroad
			//		Utility
			get { return csColorStr; }
		}
		public int Cost
		{
			// Property Cost
			//		-1 if not purchasable
			get { return ciCost; }
		}
		public int MortgageValue
		{
			// Mortgage Value
			//		-1 if not purchasable
			get { return ciMortgageValue; }
		}
		public int HouseCost
		{
			// Cost of House
			//		-1 if not improvable
			get { return ciHouseCost; }
		}
		public int NormalRent
		{
			// Rent if no monopoly
			//		0 if no rent
			get { return ciNormalRent; }
		}
		public int MonopolyRent
		{
			// Rent if monopoly but no improvements
			//		0 if no rent
			get { return ciMonopolyRent; }
		}
		public int HouseOneRent
		{
			// Rent if one house on property
			get { return ciHouseOneRent; }
		}
		public int HouseTwoRent
		{
			// Rent if two houses on property
			get { return ciHouseTwoRent; }
		}
		public int HouseThreeRent
		{
			// Rent if three houses on property
			get { return ciHouseThreeRent; }
		}
		public int HouseFourRent
		{
			// Rent if four houses on property
			get { return ciHouseFourRent; }
		}
		public int HotelRent
		{
			// Rent if hotel on property
			get { return ciHotelRent; }
		}
		// Ownership Properties
		public int Owner
		{
			// Owner's Player Number (byte)
			//		 -2 - if not ownable
			//		 -1 - for unowned
			//		0-3 - player number 
			get { return ciOwner; }
			set {
				ciOwner = value;
				NotifyPropertyChanged("Owner");
				DescriptionBox = "P" + ciOwner.ToString() + " - " + ciRent.ToString("C0");
			}
		}
		public int Rent
		{
			// Current rent
			//		0 if unowned (int)
			get { return ciRent; }
			set {
				ciRent = value;
				DescriptionBox = "P" + ciOwner.ToString() + " - " + ciRent.ToString("C0");
			}
		}
		public int MonopolyProgress
		{
			// Number of same color spots owned
			get { return ciMonopolyProgress; }
			set { ciMonopolyProgress = value; }
		}
		public bool MonopolyStatus
		{
			// Monopoly on this color
			get { return cbMonopolyStatus; }
			set { cbMonopolyStatus = value; }
		}
		public int Improvements
		{
			// Number of Property Improvements
			//		0/1/2/3/4 - Houses
			//		5 - Hotel
			get { return ciImprovements; }
			set {
				ciImprovements = value;
				if (ciImprovements == 1) {
					Rent = HouseOneRent;
				} else if (ciImprovements == 2) {
					Rent = HouseTwoRent;
				} else if (ciImprovements == 3) {
					Rent = HouseThreeRent;
				} else if (ciImprovements == 4) {
					Rent = HouseFourRent;
				} else if (ciImprovements == 5) {
					Rent = HotelRent;
				}
				NotifyPropertyChanged("Improvements");
			}
		}
		public bool PlayerZeroOnSpace
		{
			// Returns true if Player0 is currently on specified space.
			get { return cbPlayerOnSpace[0]; }
			set { cbPlayerOnSpace[0] = value; }
		}
		public bool PlayerOneOnSpace
		{
			// Returns true if Player1 is currently on specified space.
			get { return cbPlayerOnSpace[1]; }
			set { cbPlayerOnSpace[1] = value; }
		}
		public bool PlayerTwoOnSpace
		{
			// Returns true if Player2 is currently on specified space.
			get { return cbPlayerOnSpace[2]; }
			set { cbPlayerOnSpace[2] = value; }
		}
		public bool PlayerThreeOnSpace
		{
			// Returns true if Player3 is currently on specified space.
			get { return cbPlayerOnSpace[3]; }
			set { cbPlayerOnSpace[3] = value; }
		}
		// Board Information
		public string DescriptionBox
		{
			// Text for Propery's Description Box
			get { return csDescriptionBox; }
			set { csDescriptionBox = value; NotifyPropertyChanged("DescriptionBox"); }
		}
		public string ImprovementBox
		{
			// Text for Propery's Improvement Box
			get { return csImprovementBox; }
			set { csImprovementBox = value; }
		}
		public string PlayerBox
		{
			// Text for Propery's Player Box
			get { return csPlayerBox; }
			set { csPlayerBox = value; NotifyPropertyChanged("PlayerBox"); }
		}
		// Statistical Information
		public int StatTotalTimesLandedOn
		{
			// Total times landed on
			get { return ciStatTotalTimesLandedOn; }
			set { ciStatTotalTimesLandedOn = value; }
		}
		public int StatTimesLandedOnNoMonopoly
		{
			// Total times landed on with no monopoly
			get { return ciStatTimesLandedOnNoMonopoly; }
			set { ciStatTimesLandedOnNoMonopoly = value; }
		}
		public int StatTimesLandedOnMonopoly
		{
			// Total times landed on monopoly
			get { return ciStatTimesLandedOnMonopoly; }
			set { ciStatTimesLandedOnMonopoly = value; }
		}
		public int StatTimesLandedOnOneHouse
		{
			// Total times landed on with one house
			get { return ciStatTimesLandedOnOneHouse; }
			set { ciStatTimesLandedOnOneHouse = value; }
		}
		public int StatTimesLandedOnTwoHouses
		{
			// Total times landed on with two houses
			get { return ciStatTimesLandedOnTwoHouses; }
			set { ciStatTimesLandedOnTwoHouses = value; }
		}
		public int StatTimesLandedOnThreeHouses
		{
			// Total times landed on with three houses
			get { return ciStatTimesLandedOnThreeHouses; }
			set { ciStatTimesLandedOnThreeHouses = value; }
		}
		public int StatTimesLandedOnFourHouses
		{
			// Total times landed on with four houses
			get { return ciStatTimesLandedOnFourHouses; }
			set { ciStatTimesLandedOnFourHouses = value; }
		}
		public int StatTimesLandedOnHotel
		{
			// Total times landed on with hotel
			get { return ciStatTimesLandedOnHotel; }
			set { ciStatTimesLandedOnHotel = value; }
		}
		public int StatRentCollected
		{
			// Total rent collected
			get { return ciStatRentCollected; }
			set { ciStatRentCollected = value; }
		}
		public int StatTurnBoughtOn
		{
			// Turn property was purchased on
			get { return ciStatTurnBoughtOn; }
			set { ciStatTurnBoughtOn = value; }
		}
		public int StatTimesTraded
		{
			// Number of times property was traded
			get { return ciStatTimesTraded; }
			set { ciStatTimesTraded = value; }
		}
		
		public void SetProperty(int fiBoardPosition) {
			ciPosition = fiBoardPosition;
			switch (fiBoardPosition) {
				case 0:
					csName = "Go";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 1:
					csName = "Mediterranean Avenue";
					ciColorNum = 0;
					csColorStr = "Indigo";
					ciCost = 60;
					ciMortgageValue = 30;
					ciHouseCost = 50;
					ciNormalRent = 2;
					ciMonopolyRent = 4;
					ciHouseOneRent = 10;
					ciHouseTwoRent = 30;
					ciHouseThreeRent = 90;
					ciHouseFourRent = 160;
					ciHotelRent = 250;
					break;
				case 2:
					csName = "Community Chest";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 3:
					csName = "Baltic Avenue";
					ciColorNum = 0;
					csColorStr = "Indigo";
					ciCost = 60;
					ciMortgageValue = 30;
					ciHouseCost = 50;
					ciNormalRent = 4;
					ciMonopolyRent = 8;
					ciHouseOneRent = 20;
					ciHouseTwoRent = 60;
					ciHouseThreeRent = 180;
					ciHouseFourRent = 320;
					ciHotelRent = 450;
					break;
				case 4:
					csName = "Income Tax";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 5:
					csName = "Reading Railroad";
					ciColorNum = 8;
					csColorStr = "Railroad";
					ciCost = 200;
					ciMortgageValue = 100;
					ciHouseCost = -1;
					ciNormalRent = 25;
					ciMonopolyRent = 50;
					ciHouseOneRent = 100;
					ciHouseTwoRent = 200;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 6:
					csName = "Oriental Avenue";
					ciColorNum = 1;
					csColorStr = "Light Blue";
					ciCost = 100;
					ciMortgageValue = 50;
					ciHouseCost = 50;
					ciNormalRent = 6;
					ciMonopolyRent = 12;
					ciHouseOneRent = 30;
					ciHouseTwoRent = 90;
					ciHouseThreeRent = 270;
					ciHouseFourRent = 400;
					ciHotelRent = 550;
					break;
				case 7:
					csName = "Chance";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 8:
					csName = "Vermont Avenue";
					ciColorNum = 1;
					csColorStr = "Light Blue";
					ciCost = 100;
					ciMortgageValue = 50;
					ciHouseCost = 50;
					ciNormalRent = 6;
					ciMonopolyRent = 12;
					ciHouseOneRent = 30;
					ciHouseTwoRent = 90;
					ciHouseThreeRent = 270;
					ciHouseFourRent = 440;
					ciHotelRent = 550;
					break;
				case 9:
					csName = "Connecticut Avenue";
					ciColorNum = 1;
					csColorStr = "Light Blue";
					ciCost = 120;
					ciMortgageValue = 60;
					ciHouseCost = 50;
					ciNormalRent = 8;
					ciMonopolyRent = 16;
					ciHouseOneRent = 40;
					ciHouseTwoRent = 100;
					ciHouseThreeRent = 300;
					ciHouseFourRent = 450;
					ciHotelRent = 600;
					break;
				case 10:
					csName = "Just Visiting";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 11:
					csName = "St. Charles Place";
					ciColorNum = 2;
					csColorStr = "Purple";
					ciCost = 140;
					ciMortgageValue = 70;
					ciHouseCost = 100;
					ciNormalRent = 10;
					ciMonopolyRent = 20;
					ciHouseOneRent = 50;
					ciHouseTwoRent = 150;
					ciHouseThreeRent = 450;
					ciHouseFourRent = 625;
					ciHotelRent = 750;
					break;
				case 12:
					csName = "Electric Company";
					ciColorNum = 9;
					csColorStr = "Utility";
					ciCost = 150;
					ciMortgageValue = 75;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 13:
					csName = "States Avenue";
					ciColorNum = 2;
					csColorStr = "Purple";
					ciCost = 140;
					ciMortgageValue = 70;
					ciHouseCost = 100;
					ciNormalRent = 10;
					ciMonopolyRent = 20;
					ciHouseOneRent = 50;
					ciHouseTwoRent = 150;
					ciHouseThreeRent = 450;
					ciHouseFourRent = 625;
					ciHotelRent = 750;
					break;
				case 14:
					csName = "Virginia Avenue";
					ciColorNum = 2;
					csColorStr = "Purple";
					ciCost = 160;
					ciMortgageValue = 80;
					ciHouseCost = 100;
					ciNormalRent = 12;
					ciMonopolyRent = 24;
					ciHouseOneRent = 60;
					ciHouseTwoRent = 180;
					ciHouseThreeRent = 500;
					ciHouseFourRent = 700;
					ciHotelRent = 900;
					break;
				case 15:
					csName = "Pennsylvania Railroad";
					ciColorNum = 8;
					csColorStr = "Railroad";
					ciCost = 200;
					ciMortgageValue = 100;
					ciHouseCost = -1;
					ciNormalRent = 25;
					ciMonopolyRent = 50;
					ciHouseOneRent = 100;
					ciHouseTwoRent = 200;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 16:
					csName = "St. James Place";
					ciColorNum = 3;
					csColorStr = "Orange";
					ciCost = 180;
					ciMortgageValue = 90;
					ciHouseCost = 100;
					ciNormalRent = 14;
					ciMonopolyRent = 28;
					ciHouseOneRent = 70;
					ciHouseTwoRent = 200;
					ciHouseThreeRent = 550;
					ciHouseFourRent = 750;
					ciHotelRent = 950;
					break;
				case 17:
					csName = "Community Chest";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 18:
					csName = "Tennessee Avenue";
					ciColorNum = 3;
					csColorStr = "Orange";
					ciCost = 180;
					ciMortgageValue = 90;
					ciHouseCost = 100;
					ciNormalRent = 14;
					ciMonopolyRent = 28;
					ciHouseOneRent = 70;
					ciHouseTwoRent = 200;
					ciHouseThreeRent = 550;
					ciHouseFourRent = 750;
					ciHotelRent = 950;
					break;
				case 19:
					csName = "New York Avenue";
					ciColorNum = 3;
					csColorStr = "Orange";
					ciCost = 200;
					ciMortgageValue = 100;
					ciHouseCost = 100;
					ciNormalRent = 16;
					ciMonopolyRent = 32;
					ciHouseOneRent = 80;
					ciHouseTwoRent = 220;
					ciHouseThreeRent = 600;
					ciHouseFourRent = 800;
					ciHotelRent = 1000;
					break;
				case 20:
					csName = "Free Parking";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 21:
					csName = "Kentucky Avenue";
					ciColorNum = 4;
					csColorStr = "Red";
					ciCost = 220;
					ciMortgageValue = 110;
					ciHouseCost = 150;
					ciNormalRent = 18;
					ciMonopolyRent = 36;
					ciHouseOneRent = 90;
					ciHouseTwoRent = 250;
					ciHouseThreeRent = 700;
					ciHouseFourRent = 875;
					ciHotelRent = 1050;
					break;
				case 22:
					csName = "Chance";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 23:
					csName = "Indiana Avenue";
					ciColorNum = 4;
					csColorStr = "Red";
					ciCost = 220;
					ciMortgageValue = 110;
					ciHouseCost = 150;
					ciNormalRent = 18;
					ciMonopolyRent = 36;
					ciHouseOneRent = 90;
					ciHouseTwoRent = 250;
					ciHouseThreeRent = 700;
					ciHouseFourRent = 875;
					ciHotelRent = 1050;
					break;
				case 24:
					csName = "Illinois Avenue";
					ciColorNum = 4;
					csColorStr = "Red";
					ciCost = 240;
					ciMortgageValue = 120;
					ciHouseCost = 150;
					ciNormalRent = 20;
					ciMonopolyRent = 40;
					ciHouseOneRent = 100;
					ciHouseTwoRent = 300;
					ciHouseThreeRent = 750;
					ciHouseFourRent = 925;
					ciHotelRent = 1100;
					break;
				case 25:
					csName = "B&O Railroad";
					ciColorNum = 8;
					csColorStr = "Railroad";
					ciCost = 200;
					ciMortgageValue = 100;
					ciHouseCost = -1;
					ciNormalRent = 25;
					ciMonopolyRent = 50;
					ciHouseOneRent = 100;
					ciHouseTwoRent = 200;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 26:
					csName = "Atlantic Avenue";
					ciColorNum = 5;
					csColorStr = "Yellow";
					ciCost = 260;
					ciMortgageValue = 130;
					ciHouseCost = 150;
					ciNormalRent = 22;
					ciMonopolyRent = 44;
					ciHouseOneRent = 110;
					ciHouseTwoRent = 330;
					ciHouseThreeRent = 800;
					ciHouseFourRent = 975;
					ciHotelRent = 1150;
					break;
				case 27:
					csName = "Ventnor Avenue";
					ciColorNum = 5;
					csColorStr = "Yellow";
					ciCost = 260;
					ciMortgageValue = 130;
					ciHouseCost = 150;
					ciNormalRent = 22;
					ciMonopolyRent = 44;
					ciHouseOneRent = 110;
					ciHouseTwoRent = 330;
					ciHouseThreeRent = 800;
					ciHouseFourRent = 975;
					ciHotelRent = 1150;
					break;
				case 28:
					csName = "Water Works";
					ciColorNum = 9;
					csColorStr = "Utility";
					ciCost = 150;
					ciMortgageValue = 75;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 29:
					csName = "Marvin Gardens";
					ciColorNum = 5;
					csColorStr = "Yellow";
					ciCost = 280;
					ciMortgageValue = 140;
					ciHouseCost = 150;
					ciNormalRent = 24;
					ciMonopolyRent = 48;
					ciHouseOneRent = 120;
					ciHouseTwoRent = 360;
					ciHouseThreeRent = 850;
					ciHouseFourRent = 1025;
					ciHotelRent = 1200;
					break;
				case 30:
					csName = "Jail";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 31:
					csName = "Pacific Avenue";
					ciColorNum = 6;
					csColorStr = "Green";
					ciCost = 300;
					ciMortgageValue = 150;
					ciHouseCost = 200;
					ciNormalRent = 26;
					ciMonopolyRent = 52;
					ciHouseOneRent = 130;
					ciHouseTwoRent = 390;
					ciHouseThreeRent = 900;
					ciHouseFourRent = 1100;
					ciHotelRent = 1275;
					break;
				case 32:
					csName = "North Carolina Avenue";
					ciColorNum = 6;
					csColorStr = "Green";
					ciCost = 300;
					ciMortgageValue = 150;
					ciHouseCost = 200;
					ciNormalRent = 26;
					ciMonopolyRent = 52;
					ciHouseOneRent = 130;
					ciHouseTwoRent = 390;
					ciHouseThreeRent = 900;
					ciHouseFourRent = 1100;
					ciHotelRent = 1275;
					break;
				case 33:
					csName = "Community Chest";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 34:
					csName = "Pennsylvania Avenue";
					ciColorNum = 6;
					csColorStr = "Green";
					ciCost = 320;
					ciMortgageValue = 160;
					ciHouseCost = 200;
					ciNormalRent = 28;
					ciMonopolyRent = 56;
					ciHouseOneRent = 150;
					ciHouseTwoRent = 450;
					ciHouseThreeRent = 1000;
					ciHouseFourRent = 1200;
					ciHotelRent = 1400;
					break;
				case 35:
					csName = "Short Line";
					ciColorNum = 8;
					csColorStr = "Railroad";
					ciCost = 200;
					ciMortgageValue = 100;
					ciHouseCost = -1;
					ciNormalRent = 25;
					ciMonopolyRent = 50;
					ciHouseOneRent = 100;
					ciHouseTwoRent = 200;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 36:
					csName = "Chance";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 37:
					csName = "Park Place";
					ciColorNum = 7;
					csColorStr = "Blue";
					ciCost = 350;
					ciMortgageValue = 175;
					ciHouseCost = 250;
					ciNormalRent = 35;
					ciMonopolyRent = 70;
					ciHouseOneRent = 175;
					ciHouseTwoRent = 500;
					ciHouseThreeRent = 1100;
					ciHouseFourRent = 1300;
					ciHotelRent = 1500;
					break;
				case 38:
					csName = "Luxury Tax";
					ciColorNum = -1;
					csColorStr = "No Color";
					ciCost = -1;
					ciMortgageValue = -1;
					ciHouseCost = -1;
					ciNormalRent = 0;
					ciMonopolyRent = 0;
					ciHouseOneRent = 0;
					ciHouseTwoRent = 0;
					ciHouseThreeRent = 0;
					ciHouseFourRent = 0;
					ciHotelRent = 0;
					break;
				case 39:
					csName = "Boardwalk";
					ciColorNum = 7;
					csColorStr = "Blue";
					ciCost = 400;
					ciMortgageValue = 200;
					ciHouseCost = 250;
					ciNormalRent = 50;
					ciMonopolyRent = 100;
					ciHouseOneRent = 200;
					ciHouseTwoRent = 600;
					ciHouseThreeRent = 1400;
					ciHouseFourRent = 1700;
					ciHotelRent = 2000;
					break;
			}
			if (ciCost != -1) { csDescriptionBox = ciCost.ToString("C0"); } else { csDescriptionBox = ""; }
			if (ciHouseCost != -1) { csImprovementBox = "0 / 4"; } else { csImprovementBox = ""; }
			UpdatePlayerBox();
		}

		public void PlayerOnSpace(int fiPlayerNumber)
		{
			cbPlayerOnSpace[fiPlayerNumber] = true;
			UpdatePlayerBox();
		}
		public void PlayerOffSpace(int fiPlayerNumber)
		{
			cbPlayerOnSpace[fiPlayerNumber] = false;
			UpdatePlayerBox();
		}
		
		private void UpdatePlayerBox()
		{
			csPlayerBox = "";
			if (cbPlayerOnSpace[0] == true) { csPlayerBox = "0/"; }
			if (cbPlayerOnSpace[1] == true) { csPlayerBox += "1/"; }
			if (cbPlayerOnSpace[2] == true) { csPlayerBox += "2/"; }
			if (cbPlayerOnSpace[3] == true) { csPlayerBox += "3"; }
			if (csPlayerBox.Length > 0) {
				if (csPlayerBox.Substring(csPlayerBox.Length - 1, 1) == "/") {
					csPlayerBox = csPlayerBox.Substring(0, csPlayerBox.Length - 1);
				}
			}
			NotifyPropertyChanged("PlayerBox");
		}

	}
}
