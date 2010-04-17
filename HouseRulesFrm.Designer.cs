namespace MonopolySim
{
	partial class HouseRulesFrm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.SaveCmd = new System.Windows.Forms.Button();
			this.CancelCmd = new System.Windows.Forms.Button();
			this.FreeParkingChk = new System.Windows.Forms.CheckBox();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.FreeParking500Chk = new System.Windows.Forms.CheckBox();
			this.CollectRentInJailChk = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// SaveCmd
			// 
			this.SaveCmd.Location = new System.Drawing.Point(42, 81);
			this.SaveCmd.Name = "SaveCmd";
			this.SaveCmd.Size = new System.Drawing.Size(75, 23);
			this.SaveCmd.TabIndex = 0;
			this.SaveCmd.Text = "Save";
			this.SaveCmd.UseVisualStyleBackColor = true;
			this.SaveCmd.Click += new System.EventHandler(this.SaveCmd_Click);
			// 
			// CancelCmd
			// 
			this.CancelCmd.Location = new System.Drawing.Point(123, 81);
			this.CancelCmd.Name = "CancelCmd";
			this.CancelCmd.Size = new System.Drawing.Size(75, 23);
			this.CancelCmd.TabIndex = 2;
			this.CancelCmd.Text = "Cancel";
			this.CancelCmd.UseVisualStyleBackColor = true;
			// 
			// FreeParkingChk
			// 
			this.FreeParkingChk.AutoSize = true;
			this.FreeParkingChk.Location = new System.Drawing.Point(12, 12);
			this.FreeParkingChk.Name = "FreeParkingChk";
			this.FreeParkingChk.Size = new System.Drawing.Size(121, 17);
			this.FreeParkingChk.TabIndex = 3;
			this.FreeParkingChk.Text = "Free Parking Lottery";
			this.FreeParkingChk.UseVisualStyleBackColor = true;
			// 
			// ToolTip
			// 
			this.ToolTip.IsBalloon = true;
			// 
			// FreeParking500Chk
			// 
			this.FreeParking500Chk.AutoSize = true;
			this.FreeParking500Chk.Location = new System.Drawing.Point(12, 35);
			this.FreeParking500Chk.Name = "FreeParking500Chk";
			this.FreeParking500Chk.Size = new System.Drawing.Size(168, 17);
			this.FreeParking500Chk.TabIndex = 4;
			this.FreeParking500Chk.Text = "Free Parking always has $500";
			this.FreeParking500Chk.UseVisualStyleBackColor = true;
			// 
			// CollectRentInJailChk
			// 
			this.CollectRentInJailChk.AutoSize = true;
			this.CollectRentInJailChk.Location = new System.Drawing.Point(12, 58);
			this.CollectRentInJailChk.Name = "CollectRentInJailChk";
			this.CollectRentInJailChk.Size = new System.Drawing.Size(193, 17);
			this.CollectRentInJailChk.TabIndex = 5;
			this.CollectRentInJailChk.Text = "Players may collect rent while in Jail";
			this.CollectRentInJailChk.UseVisualStyleBackColor = true;
			// 
			// HouseRulesFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(210, 113);
			this.Controls.Add(this.CollectRentInJailChk);
			this.Controls.Add(this.FreeParking500Chk);
			this.Controls.Add(this.FreeParkingChk);
			this.Controls.Add(this.CancelCmd);
			this.Controls.Add(this.SaveCmd);
			this.Name = "HouseRulesFrm";
			this.Text = "House Rules";
			this.Load += new System.EventHandler(this.HouseRulesFrm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button SaveCmd;
		private System.Windows.Forms.Button CancelCmd;
		private System.Windows.Forms.CheckBox FreeParkingChk;
		private System.Windows.Forms.ToolTip ToolTip;
		private System.Windows.Forms.CheckBox FreeParking500Chk;
		private System.Windows.Forms.CheckBox CollectRentInJailChk;
	}
}