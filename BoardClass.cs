using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.IO;

namespace MonopolySim
{
	public class BoardClass
	{
		public string LogFullPath;
		public string LogFilename;
		public int TailProcId;
		StreamWriter LogWriter;
		
		public string GameLog
		{
			// Game Log
			set { AddLineToLog(value.ToString()); }
		}
		
		public BoardClass()
		{
			LogFilename = DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".log";
			LogFullPath = "H:\\Programming\\C#\\Monopoly Simulator\\Logs\\" + LogFilename;
			LogWriter = new StreamWriter(LogFullPath);
			LogWriter.AutoFlush = true;
			System.Diagnostics.Process TailProc = new System.Diagnostics.Process();
			TailProc.StartInfo.FileName = "H:\\Programming\\C#\\Monopoly Simulator\\Logs\\WinTail.exe";
			TailProc.StartInfo.Arguments = "\"" + LogFullPath + "\"";
			TailProc.Start();
			TailProcId = TailProc.Id;
		}

		public void AddLineToLog(string fsLineToAdd)
		{
			if (GameClass.MoveNumber < 1) {
				LogWriter.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff") + " :0000: " + fsLineToAdd);
			} else {
				LogWriter.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff") + " :" + GameClass.MoveNumber.ToString("0000") + ": " + fsLineToAdd);
			}
		}

		
	}
}
