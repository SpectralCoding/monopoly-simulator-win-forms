using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonopolySim
{
	public partial class HouseRulesFrm : Form
	{
		public HouseRulesFrm()
		{
			InitializeComponent();
		}

		private void HouseRulesFrm_Load(object sender, EventArgs e)
		{
			ToolTip.SetToolTip(FreeParkingChk, "All fees from Chance & Community Chest cards, Jail Fees, and Income/Luxury\nTax are put into Free Parking as a form of lottery.");
			ToolTip.SetToolTip(FreeParking500Chk, "Every time someone wins the Free Parking Lottery $500 is put into Free\nParking. This means everytime someone lands they atleast get $500.");
			ToolTip.SetToolTip(CollectRentInJailChk, "Allows players to continue to collect rent from other players while\nthey're in Jail. Disabling this may deter people from staying in jail to\navoid paying rent to others.");
			
			FreeParkingChk.Checked = GameClass.Config.FreeParking;
			FreeParking500Chk.Checked = GameClass.Config.FreeParking500;
			CollectRentInJailChk.Checked = GameClass.Config.CollectRentInJail;
			
		}

		private void SaveCmd_Click(object sender, EventArgs e)
		{
			GameClass.Config.FreeParking = FreeParkingChk.Checked;
			GameClass.Config.FreeParking500 = FreeParking500Chk.Checked;
			GameClass.Config.CollectRentInJail = CollectRentInJailChk.Checked;
			GameClass.Config.SaveHouseRules();
			if (GameClass.Config.FreeParking500 == true || GameClass.FreeParkingCash == 0) {
				GameClass.FreeParkingCash = 500;
			}
			this.Close();
		}
	}
}
