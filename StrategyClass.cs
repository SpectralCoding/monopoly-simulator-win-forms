using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySim
{
	class StrategyClass
	{
		
		private double cdBuyPropertyCutoffPct;
		private PlayerClass coPlayer;

		public StrategyClass(PlayerClass Player) {
			coPlayer = Player;
			// Null Constructor
		}
		
		public double BuyPropertyCutOffPct {
			// Determines when to buy property.
			// Example: BuyPropertyCutOffPct = 25
			//    If the cost of purchasing property is less than 25% of player's cash on hand
			get { return cdBuyPropertyCutoffPct; }
			set { cdBuyPropertyCutoffPct = value; }
		}
		
		public PlayerClass Player {
			get { return coPlayer; }
			set { coPlayer = value; }
		}
		
		public void RunPreturnOptions() {
			EvaluateImprovementPurchases();
		}
		
		public void EvaluateImprovementPurchases() {
			double dBuildEvenlyCost;
			double dTurnStartingCash;
			double dTempCutOffTest;
			dTurnStartingCash = coPlayer.Cash;
			for (int i = 0; i <= 39; i++) {
				// For each property on the board
				if (GameClass.Property[i].ColorNum != -1 && GameClass.Property[i].ColorNum != 8 && GameClass.Property[i].ColorNum != 9) {
					// If property is improvable (not non-purchasable, utility, or railroad)
					if (GameClass.Property[i].Owner == coPlayer.Number) {
						// If property is owned by the current player
						if (GameClass.Property[i].MonopolyStatus == true) {
							// If you have a monopoly on that color
							if (GameClass.Property[i].ColorNum == 1 || GameClass.Property[i].ColorNum == 7) {
								// If only two properties make a monopoly
								dBuildEvenlyCost = GameClass.Property[i].HouseCost * 2;
							} else {
								// If three properties make a monopoly
								dBuildEvenlyCost = GameClass.Property[i].HouseCost * 3;
							}
							dTempCutOffTest = (dBuildEvenlyCost / dTurnStartingCash)*100.0;
							if (dTempCutOffTest <= cdBuyPropertyCutoffPct) {
								// If cost to buy improvements is less than or equal to the BuyPropertyCutOffPct
								for (int y = 0; y <= 39; y++) {
									if (GameClass.Property[y].ColorNum == GameClass.Property[i].ColorNum) {
										if (GameClass.Property[y].Improvements < 5) {
											// If you can build more on this property then do so
											GameClass.Board.GameLog = "(dBuildEvenlyCost / dTurnStartingCash * 100.0) = (" + dBuildEvenlyCost.ToString() + "/" + dTurnStartingCash.ToString() + " * 100.0) = " + dTempCutOffTest.ToString();
											GameClass.PlayerImprovesSpace(coPlayer.Number, y);
										}
									}
								}
								dTurnStartingCash = coPlayer.Cash;
							}
						}
					}
				}
			}
		}
		
		public bool BuyProperty(int fiPropertyPosition) {
			// Always buy properties
			return true;
		}

		public bool TradeOption(int[] fiGivePropArr, int fiGiveCash, bool fbGiveJailCard, int[] fiGetPropArr, int fiGetCash, bool fbGetJailCard) {
			return true;
		}
	}
}
