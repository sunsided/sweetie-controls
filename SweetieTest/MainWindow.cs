using System;
using System.Windows.Forms;

namespace SweetieTest
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();

			progressTimer.Tick += progressTimer_Tick;
			progressTimer.Enabled = sweetieBox.Checked;
			sweetieBox.CheckedChanged += delegate { progressTimer.Enabled = sweetieBox.Checked; };
		}

		void progressTimer_Tick(object sender, EventArgs e)
		{
			if (sweetieProgress.Value < sweetieProgress.Maximum)
				sweetieProgress.Value++;
			else
				sweetieProgress.Value = sweetieProgress.Minimum;
		}
	}
}
