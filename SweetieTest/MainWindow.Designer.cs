namespace SweetieTest
{
	partial class MainWindow
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
			this.progressTimer = new System.Windows.Forms.Timer(this.components);
			this.sweetieProgress = new MMT.Controls.Sweetie.SweetieProgress();
			this.sweetieBox = new MMT.Controls.Sweetie.SweetieBox();
			this.SuspendLayout();
			// 
			// sweetieProgress
			// 
			this.sweetieProgress.BorderColor = System.Drawing.Color.Black;
			this.sweetieProgress.DarkBackground = System.Drawing.Color.WhiteSmoke;
			this.sweetieProgress.ForeColor = System.Drawing.Color.White;
			this.sweetieProgress.ForegroundBottomColor = System.Drawing.Color.CornflowerBlue;
			this.sweetieProgress.ForegroundShadeColor = System.Drawing.Color.SteelBlue;
			this.sweetieProgress.LightBackground = System.Drawing.Color.White;
			this.sweetieProgress.Location = new System.Drawing.Point(58, 27);
			this.sweetieProgress.MaximumSize = new System.Drawing.Size(100000, 11);
			this.sweetieProgress.Name = "sweetieProgress";
			this.sweetieProgress.Size = new System.Drawing.Size(150, 11);
			this.sweetieProgress.TabIndex = 1;
			// 
			// sweetieBox
			// 
			this.sweetieBox.BorderColor = System.Drawing.Color.Black;
			this.sweetieBox.DarkBackgroundDisabled = System.Drawing.Color.DimGray;
			this.sweetieBox.DarkBackgroundEnabled = System.Drawing.Color.White;
			this.sweetieBox.LightBackgroundDisabled = System.Drawing.Color.Gray;
			this.sweetieBox.LightBackgroundEnabled = System.Drawing.Color.DimGray;
			this.sweetieBox.Location = new System.Drawing.Point(41, 27);
			this.sweetieBox.MaximumSize = new System.Drawing.Size(11, 11);
			this.sweetieBox.MinimumSize = new System.Drawing.Size(11, 11);
			this.sweetieBox.Name = "sweetieBox";
			this.sweetieBox.Size = new System.Drawing.Size(11, 11);
			this.sweetieBox.TabIndex = 0;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(278, 67);
			this.Controls.Add(this.sweetieProgress);
			this.Controls.Add(this.sweetieBox);
			this.Name = "MainWindow";
			this.Text = "Test";
			this.ResumeLayout(false);

		}

		#endregion

		private MMT.Controls.Sweetie.SweetieBox sweetieBox;
		private MMT.Controls.Sweetie.SweetieProgress sweetieProgress;
		private System.Windows.Forms.Timer progressTimer;
	}
}

