using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MonopolySim
{
	public partial class MainFrm : Form
	{		
		public MainFrm()
		{
			InitializeComponent();
		}
		
		public int LocationX { get { return this.Location.X; } }
		public int LocationY { get { return this.Location.Y; } }
		public int SizeHeight { get { return this.Size.Height; } }
		public int SizeWidth { get { return this.Size.Width; } }
		
		private void InitializeDataBindings()
		{
			// Initialize CostLabel Bindings
			Pos1Cost.DataBindings.Add(new Binding("Text", GameClass.Property[1], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos3Cost.DataBindings.Add(new Binding("Text", GameClass.Property[3], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos5Cost.DataBindings.Add(new Binding("Text", GameClass.Property[5], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos6Cost.DataBindings.Add(new Binding("Text", GameClass.Property[6], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos8Cost.DataBindings.Add(new Binding("Text", GameClass.Property[8], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos9Cost.DataBindings.Add(new Binding("Text", GameClass.Property[9], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos11Cost.DataBindings.Add(new Binding("Text", GameClass.Property[11], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos12Cost.DataBindings.Add(new Binding("Text", GameClass.Property[12], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos13Cost.DataBindings.Add(new Binding("Text", GameClass.Property[13], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos14Cost.DataBindings.Add(new Binding("Text", GameClass.Property[14], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos15Cost.DataBindings.Add(new Binding("Text", GameClass.Property[15], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos16Cost.DataBindings.Add(new Binding("Text", GameClass.Property[16], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos18Cost.DataBindings.Add(new Binding("Text", GameClass.Property[18], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos19Cost.DataBindings.Add(new Binding("Text", GameClass.Property[19], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos21Cost.DataBindings.Add(new Binding("Text", GameClass.Property[21], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos23Cost.DataBindings.Add(new Binding("Text", GameClass.Property[23], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos24Cost.DataBindings.Add(new Binding("Text", GameClass.Property[24], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos25Cost.DataBindings.Add(new Binding("Text", GameClass.Property[25], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos26Cost.DataBindings.Add(new Binding("Text", GameClass.Property[26], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos27Cost.DataBindings.Add(new Binding("Text", GameClass.Property[27], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos28Cost.DataBindings.Add(new Binding("Text", GameClass.Property[28], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos29Cost.DataBindings.Add(new Binding("Text", GameClass.Property[29], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos31Cost.DataBindings.Add(new Binding("Text", GameClass.Property[31], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos32Cost.DataBindings.Add(new Binding("Text", GameClass.Property[32], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos34Cost.DataBindings.Add(new Binding("Text", GameClass.Property[34], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos35Cost.DataBindings.Add(new Binding("Text", GameClass.Property[35], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos37Cost.DataBindings.Add(new Binding("Text", GameClass.Property[37], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			Pos39Cost.DataBindings.Add(new Binding("Text", GameClass.Property[39], "DescriptionBox", true, DataSourceUpdateMode.Never, "$0", "C0"));
			// Initialize ImprovementLabel Bindings
			Pos1Imp.DataBindings.Add(new Binding("Text", GameClass.Property[1], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos3Imp.DataBindings.Add(new Binding("Text", GameClass.Property[3], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos6Imp.DataBindings.Add(new Binding("Text", GameClass.Property[6], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos8Imp.DataBindings.Add(new Binding("Text", GameClass.Property[8], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos9Imp.DataBindings.Add(new Binding("Text", GameClass.Property[9], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos11Imp.DataBindings.Add(new Binding("Text", GameClass.Property[11], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos13Imp.DataBindings.Add(new Binding("Text", GameClass.Property[13], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos14Imp.DataBindings.Add(new Binding("Text", GameClass.Property[14], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos16Imp.DataBindings.Add(new Binding("Text", GameClass.Property[16], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos18Imp.DataBindings.Add(new Binding("Text", GameClass.Property[18], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos19Imp.DataBindings.Add(new Binding("Text", GameClass.Property[19], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos21Imp.DataBindings.Add(new Binding("Text", GameClass.Property[21], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos23Imp.DataBindings.Add(new Binding("Text", GameClass.Property[23], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos24Imp.DataBindings.Add(new Binding("Text", GameClass.Property[24], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos26Imp.DataBindings.Add(new Binding("Text", GameClass.Property[26], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos27Imp.DataBindings.Add(new Binding("Text", GameClass.Property[27], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos29Imp.DataBindings.Add(new Binding("Text", GameClass.Property[29], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos31Imp.DataBindings.Add(new Binding("Text", GameClass.Property[31], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos32Imp.DataBindings.Add(new Binding("Text", GameClass.Property[32], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos37Imp.DataBindings.Add(new Binding("Text", GameClass.Property[37], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			Pos39Imp.DataBindings.Add(new Binding("Text", GameClass.Property[39], "ImprovementBox", true, DataSourceUpdateMode.Never, "0 / 4"));
			// Initialize PlayerLabel Bindings
			Pos0Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[0], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos1Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[1], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos2Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[2], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos3Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[3], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos4Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[4], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos5Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[5], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos6Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[6], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos7Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[7], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos8Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[8], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos9Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[9], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos10Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[10], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos11Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[11], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos12Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[12], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos13Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[13], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos14Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[14], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos15Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[15], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos16Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[16], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos17Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[17], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos18Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[18], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos19Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[19], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos21Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[21], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos22Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[22], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos23Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[23], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos24Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[24], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos25Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[25], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos26Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[26], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos27Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[27], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos28Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[28], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos29Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[29], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos30Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[30], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos31Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[31], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos32Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[32], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos33Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[33], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos34Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[34], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos35Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[35], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos36Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[36], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos37Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[37], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos38Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[38], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			Pos39Playerlbl.DataBindings.Add(new Binding("Text", GameClass.Property[39], "PlayerBox", true, DataSourceUpdateMode.Never, ""));
			// Initialize Player Cash Label Bindings
			Player0MouseLbl.DataBindings.Add(new Binding("Text", GameClass.Player[0], "MouseoverBox", true, DataSourceUpdateMode.Never, ""));
			Player1MouseLbl.DataBindings.Add(new Binding("Text", GameClass.Player[1], "MouseoverBox", true, DataSourceUpdateMode.Never, ""));
			Player2MouseLbl.DataBindings.Add(new Binding("Text", GameClass.Player[2], "MouseoverBox", true, DataSourceUpdateMode.Never, ""));
			Player3MouseLbl.DataBindings.Add(new Binding("Text", GameClass.Player[3], "MouseoverBox", true, DataSourceUpdateMode.Never, ""));
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MainFrm_Load(object sender, EventArgs e)
		{
			this.Location = new Point(100, 100);
			GameClass.StartGame();
			InitializeDataBindings();
			System.Threading.Thread.Sleep(100);
			Window.SetPositionSize(GameClass.Board.LogFilename, (this.Location.X + this.Size.Width + 1), this.Location.Y, 638, this.Size.Height);
		}

		private void PositionChance_MouseEnter(object sender, EventArgs e)
		{
			ToolTipTxt.Text = "Current Chance Deck:" + Environment.NewLine;
			for (int i = 0; i <= 15; i++) {
				ToolTipTxt.Text += "  " + i.ToString() + " - " + GameClass.ChanceDeck.ChanceDeck(i, 0);
				if (i != 15) { ToolTipTxt.Text += Environment.NewLine; }
			}
		}
		private void PositionCommunityChest_MouseEnter(object sender, EventArgs e)
		{
			ToolTipTxt.Text = "Current Community Chest Deck:" + Environment.NewLine;
			for (int i = 0; i <= 15; i++)
			{
				ToolTipTxt.Text += "  " + i.ToString() + " - " + GameClass.CommunityChestDeck.CommunityChestDeck(i, 0);
				if (i != 15) { ToolTipTxt.Text += Environment.NewLine; }
			}
		}

		private void Player0MouseLbl_MouseEnter(object sender, EventArgs e)
		{
			int PlayerNum = 0;
			ToolTipTxt.Text = "Player " + PlayerNum.ToString() + ":" + Environment.NewLine;
			ToolTipTxt.Text += "  Current Cash: " + GameClass.Player[PlayerNum].Cash.ToString("C0") + Environment.NewLine;
			ToolTipTxt.Text += "  Current Assets: " + GameClass.Player[PlayerNum].Assets.ToString("C0") + Environment.NewLine;
			if (GameClass.Player[PlayerNum].HasGetOutOfJailFree == true)
			{
				ToolTipTxt.Text += "  Get Out Of Jail Free: Yes" + Environment.NewLine;
			}
			else
			{
				ToolTipTxt.Text += "  Get Out Of Jail Free: No" + Environment.NewLine;
			}
			ToolTipTxt.Text += "  Properties Owned: " + GameClass.Player[PlayerNum].PropertiesOwned.ToString() + Environment.NewLine;
			ToolTipTxt.Text += "  Current Position: " + GameClass.Player[PlayerNum].CurrentPosition.ToString() + " (" +
				GameClass.Property[GameClass.Player[PlayerNum].CurrentPosition].Name + ")" + Environment.NewLine;
			if (GameClass.Player[PlayerNum].TurnInJail > 0)
			{
				ToolTipTxt.Text += "  Turn in Jail: " + GameClass.Player[PlayerNum].TurnInJail.ToString() + Environment.NewLine;
			}
			else
			{
				ToolTipTxt.Text += "  Turn in Jail: N/A" + Environment.NewLine;
			}
		}
		private void Player1MouseLbl_MouseEnter(object sender, EventArgs e)
		{
			int PlayerNum = 1;
			ToolTipTxt.Text = "Player " + PlayerNum.ToString() + ":" + Environment.NewLine;
			ToolTipTxt.Text += "  Current Cash: " + GameClass.Player[PlayerNum].Cash.ToString("C0") + Environment.NewLine;
			ToolTipTxt.Text += "  Current Assets: " + GameClass.Player[PlayerNum].Assets.ToString("C0") + Environment.NewLine;
			if (GameClass.Player[PlayerNum].HasGetOutOfJailFree == true)
			{
				ToolTipTxt.Text += "  Get Out Of Jail Free: Yes" + Environment.NewLine;
			}
			else
			{
				ToolTipTxt.Text += "  Get Out Of Jail Free: No" + Environment.NewLine;
			}
			ToolTipTxt.Text += "  Properties Owned: " + GameClass.Player[PlayerNum].PropertiesOwned.ToString() + Environment.NewLine;
			ToolTipTxt.Text += "  Current Position: " + GameClass.Player[PlayerNum].CurrentPosition.ToString() + " (" +
				GameClass.Property[GameClass.Player[PlayerNum].CurrentPosition].Name + ")" + Environment.NewLine;
			if (GameClass.Player[PlayerNum].TurnInJail > 0)
			{
				ToolTipTxt.Text += "  Turn in Jail: " + GameClass.Player[PlayerNum].TurnInJail.ToString() + Environment.NewLine;
			}
			else
			{
				ToolTipTxt.Text += "  Turn in Jail: N/A" + Environment.NewLine;
			}

		}
		private void Player2MouseLbl_MouseEnter(object sender, EventArgs e)
		{
			int PlayerNum = 2;
			ToolTipTxt.Text = "Player " + PlayerNum.ToString() + ":" + Environment.NewLine;
			ToolTipTxt.Text += "  Current Cash: " + GameClass.Player[PlayerNum].Cash.ToString("C0") + Environment.NewLine;
			ToolTipTxt.Text += "  Current Assets: " + GameClass.Player[PlayerNum].Assets.ToString("C0") + Environment.NewLine;
			if (GameClass.Player[PlayerNum].HasGetOutOfJailFree == true)
			{
				ToolTipTxt.Text += "  Get Out Of Jail Free: Yes" + Environment.NewLine;
			}
			else
			{
				ToolTipTxt.Text += "  Get Out Of Jail Free: No" + Environment.NewLine;
			}
			ToolTipTxt.Text += "  Properties Owned: " + GameClass.Player[PlayerNum].PropertiesOwned.ToString() + Environment.NewLine;
			ToolTipTxt.Text += "  Current Position: " + GameClass.Player[PlayerNum].CurrentPosition.ToString() + " (" +
				GameClass.Property[GameClass.Player[PlayerNum].CurrentPosition].Name + ")" + Environment.NewLine;
			if (GameClass.Player[PlayerNum].TurnInJail > 0)
			{
				ToolTipTxt.Text += "  Turn in Jail: " + GameClass.Player[PlayerNum].TurnInJail.ToString() + Environment.NewLine;
			}
			else
			{
				ToolTipTxt.Text += "  Turn in Jail: N/A" + Environment.NewLine;
			}

		}
		private void Player3MouseLbl_MouseEnter(object sender, EventArgs e)
		{
			int PlayerNum = 3;
			ToolTipTxt.Text = "Player " + PlayerNum.ToString() + ":" + Environment.NewLine;
			ToolTipTxt.Text += "  Current Cash: " + GameClass.Player[PlayerNum].Cash.ToString("C0") + Environment.NewLine;
			ToolTipTxt.Text += "  Current Assets: " + GameClass.Player[PlayerNum].Assets.ToString("C0") + Environment.NewLine;
			if (GameClass.Player[PlayerNum].HasGetOutOfJailFree == true)
			{
				ToolTipTxt.Text += "  Get Out Of Jail Free: Yes" + Environment.NewLine;
			}
			else
			{
				ToolTipTxt.Text += "  Get Out Of Jail Free: No" + Environment.NewLine;
			}
			ToolTipTxt.Text += "  Properties Owned: " + GameClass.Player[PlayerNum].PropertiesOwned.ToString() + Environment.NewLine;
			ToolTipTxt.Text += "  Current Position: " + GameClass.Player[PlayerNum].CurrentPosition.ToString() + " (" +
				GameClass.Property[GameClass.Player[PlayerNum].CurrentPosition].Name + ")" + Environment.NewLine;
			if (GameClass.Player[PlayerNum].TurnInJail > 0)
			{
				ToolTipTxt.Text += "  Turn in Jail: " + GameClass.Player[PlayerNum].TurnInJail.ToString() + Environment.NewLine;
			}
			else
			{
				ToolTipTxt.Text += "  Turn in Jail: N/A" + Environment.NewLine;
			}

		}


		private void DoOneMoveCmd_Click(object sender, EventArgs e)
		{
			GameClass.NextTurn();
		}

		private void DoFourMovesCmd_Click(object sender, EventArgs e)
		{
			Console.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff"));
			int iStopAtMove;
			iStopAtMove = GameClass.MoveNumber + Convert.ToInt32(NumOfMovesTxt.Text);
			while (GameClass.MoveNumber <= iStopAtMove) {
				GameClass.NextTurn();
			}
			Console.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff"));
		}

		private void OpenLogCmd_Click(object sender, EventArgs e)
		{
			Process TailProc = new Process();
			TailProc.StartInfo.FileName = "H:\\Programming\\C#\\Monopoly Simulator\\Logs\\WinTail.exe";
			TailProc.StartInfo.Arguments = "\"" + GameClass.Board.LogFullPath + "\"";
			TailProc.Start();
			GameClass.Board.TailProcId = TailProc.Id;
			System.Threading.Thread.Sleep(100);
			Window.SetPositionSize(GameClass.Board.LogFilename, (this.Location.X + this.Size.Width + 1), this.Location.Y, 638, this.Size.Height);
		}

		private void StrategyCfgCmd_Click(object sender, EventArgs e)
		{
			StrategyCfgFrm StrategyCfgFrm = new StrategyCfgFrm();
			StrategyCfgFrm.Show();
		}

		private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
		{
			foreach (Process proc in Process.GetProcesses()) {
				if (proc.Id == GameClass.Board.TailProcId) {
					proc.Kill();
				}
			}
		}

		private void MainFrm_Move(object sender, EventArgs e)
		{
			int iTailTLX, iTailTLY, iTailWidth, iTailHeight;
			iTailTLX = this.Location.X + this.Size.Width + 1;
			iTailTLY = this.Location.Y;
			iTailWidth = 638;
			iTailHeight = this.Size.Height;
			Window.SetPositionSize(GameClass.Board.LogFilename, iTailTLX, iTailTLY, iTailWidth, iTailHeight);

		}

		private void HouseRulesCmd_Click(object sender, EventArgs e)
		{
			HouseRulesFrm HouseRulesFrm = new HouseRulesFrm();
			HouseRulesFrm.Show();
		}
	}
	
	// Window Class to enable resizing of external windows
	public sealed class Window
	{

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport(@"user32.dll", EntryPoint = "SetWindowPos", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
		public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		public static void SetPositionSize(string name, int x, int y, int width, int height)
		{
			foreach (Process proc in Process.GetProcesses())
			{
				if (proc.MainWindowTitle.StartsWith(name))
				{
					IntPtr hWind = proc.MainWindowHandle;
					//IntPtr hWind = FindWindow(null, name);
					SetWindowPos(hWind, (IntPtr)null, x, y, width, height, 0u);
				}
			}
		}

		private Window()
		{

		}
	}



}
