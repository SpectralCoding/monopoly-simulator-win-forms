using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MonopolySim
{
	public class ConfigClass
	{
		
		public bool FreeParking = false;
		public bool FreeParking500 = false;
		public bool CollectRentInJail = false;
		
		
		public ConfigClass() {
			LoadHouseRules();
		}
		
		public void SaveHouseRules() {
			StreamWriter HouseRulesWriter = new StreamWriter("houserules.ini");
			if (FreeParking == true) {
				HouseRulesWriter.WriteLine("FreeParking=1");
			} else {
				HouseRulesWriter.WriteLine("FreeParking=0");
			}
			if (FreeParking500 == true) {
				HouseRulesWriter.WriteLine("FreeParking500=1");
			} else {
				HouseRulesWriter.WriteLine("FreeParking500=0");
			}
			if (CollectRentInJail == true) {
				HouseRulesWriter.WriteLine("CollectRentInJail=1");
			} else {
				HouseRulesWriter.WriteLine("CollectRentInJail=0");
			}
			HouseRulesWriter.Close();
		}
		
		private void LoadHouseRules() {
			StreamReader HouseRulesReader = new StreamReader("houserules.ini");
			string sCurrentLine;
			string[] sCurrentLineSplit;
			while (!HouseRulesReader.EndOfStream) {
				sCurrentLine = HouseRulesReader.ReadLine();
				sCurrentLineSplit = sCurrentLine.Split('=');
				switch (sCurrentLineSplit[0]) {
					case "FreeParking":
						if (sCurrentLineSplit[1] == "1") { FreeParking = true; }
						break;
					case "FreeParking500":
						if (sCurrentLineSplit[1] == "1") { FreeParking500 = true; }
						break;
					case "CollectRentInJail":
						if (sCurrentLineSplit[1] == "1") { CollectRentInJail = true; }
						break;
				}
			}
			HouseRulesReader.Close();
		}
		
	}
}
