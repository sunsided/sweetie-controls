using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MMT.Controls.Sweetie
{
	/// <summary>
	/// SweetieBox checkbox control
	/// </summary>
	[ToolboxBitmap(typeof(CheckBox))]
	[DefaultEvent("CheckedChanged")]
	[DefaultProperty("Checked")]
	[Description("SweetieBox checkbox control")]
	public partial class SweetieBox : UserControl
	{
		/// <summary>
		/// Creates a SweetieBox
		/// </summary>
		public SweetieBox()
		{
			InitializeComponent();
			SetStyle(ControlStyles.Selectable, true);
			SetStyle(ControlStyles.FixedHeight, true);
			SetStyle(ControlStyles.FixedWidth, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			//SetStyle(ControlStyles.StandardClick, true);
			//SetStyle(ControlStyles.StandardDoubleClick, true);
			SetStyle(ControlStyles.CacheText, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.ContainerControl, false);
		}

		/// <summary>
		/// Creates a SweetieBox
		/// </summary>
		/// <param name="isChecked">Sets the checked state</param>
		public SweetieBox(bool isChecked)
			:this()
		{
			_checked = true;
			Invalidate();
		}

		/// <summary>
		/// Creates a SweetieBox
		/// </summary>
		/// <param name="isChecked">Sets the checked state</param>
		/// <param name="antiAlias">Sets anti-aliasing mode</param>
		public SweetieBox(bool isChecked, bool antiAlias)
			: this(isChecked)
		{
			_hq = antiAlias;
			Invalidate();
		}

		private Rectangle _enabledBoxRect = new Rectangle(0, 0, 10, 10);

		protected override void OnPaint(PaintEventArgs e)
		{
			DrawBox(e.Graphics);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.X >= _enabledBoxRect.Left - 1 && e.X <= _enabledBoxRect.Right + 1 &&
				e.Y >= _enabledBoxRect.Top - 1 && e.Y <= _enabledBoxRect.Bottom + 1)
			{
				Checked = !Checked;
				Invalidate();
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (e.KeyChar == ' ' || e.KeyChar == 13 || e.KeyChar == 10)
			{
				Checked = !Checked;
				Invalidate();
			}
		}

		private bool _checked = true;

		/// <summary>
		/// Gets or sets checked state
		/// </summary>
		[Browsable(true)]
		[Description("Sets whether the box is checked or not.")]
		[DefaultValue(true)]
		public bool Checked
		{
			get { return _checked; }
			set 
			{
				if (value == _checked ) return;
				_checked = value;
				Invalidate();

				if (CheckedChanged != null) CheckedChanged(this, EventArgs.Empty);
			}
		}

		private bool _hq = false;

		/// <summary>
		/// Gets or sets whether antialiasing is enabled
		/// </summary>
		[DefaultValue(false)]
		[Description("Sets whether anti-aliasing is enabled")]
		public bool AntiAlias
		{
			get { return _hq; }
			set { _hq = value; Invalidate(); }
		}



		/// <summary>
		/// Gets or sets the border color
		/// </summary>
		[Description("Sets the border color")]
		[Category("Appearance")]
		[Browsable(true)]
		public Color BorderColor
		{
			get { return _BorderColor; }
			set { _BorderColor = value; Invalidate();  }
		}

		private Color _BorderColor = Color.Black;
		private Color _LightBackground_Enab = Color.DimGray;
		private Color _DarkBackground_Enab = Color.White;
		private Color _LightBackground_Disab = Color.Gray;
		private Color _DarkBackground_Disab = Color.DimGray;

		/// <summary>
		/// Gets or sets the bright background color
		/// </summary>
		[Description("Sets the bright background color")]
		[Category("Appearance")]
		[Browsable(true)]
		public Color LightBackgroundEnabled
		{
			get { return _LightBackground_Enab; }
			set { _LightBackground_Enab = value; Invalidate(); }
		}

		/// <summary>
		/// Gets or sets the dark background color
		/// </summary>
		[Description("Sets the dark background color")]
		[Category("Appearance")]
		[Browsable(true)]
		public Color DarkBackgroundEnabled
		{
			get { return _DarkBackground_Enab; }
			set { _DarkBackground_Enab = value; Invalidate(); }
		}

		/// <summary>
		/// Gets or sets the light background color
		/// </summary>
		[Description("Sets the light background color")]
		[Category("Appearance")]
		[Browsable(true)]
		public Color LightBackgroundDisabled
		{
			get { return _LightBackground_Disab; }
			set { _LightBackground_Disab = value; Invalidate(); }
		}

		/// <summary>
		/// Gets or sets the dark background color
		/// </summary>
		[Description("Sets the dark background color")]
		[Category("Appearance")]
		[Browsable(true)]
		public Color DarkBackgroundDisabled
		{
			get { return _DarkBackground_Disab; }
			set { _DarkBackground_Disab = value; Invalidate(); }
		}


		private void DrawBox(Graphics gr)
		{
			Rectangle rect = _enabledBoxRect;

			if (AntiAlias)
				gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			else
				gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

			//Brush white = new SolidBrush(_LightBackground_Enab);
			Brush white = new System.Drawing.Drawing2D.LinearGradientBrush(rect, _DarkBackground_Enab, _LightBackground_Enab, 0.0f);
			Brush crimson = new System.Drawing.Drawing2D.LinearGradientBrush(rect, _DarkBackground_Disab, _LightBackground_Disab, 0.0f);

			Pen black = new Pen(ForeColor);
			Pen border = new Pen(BorderColor);

			// Draw fill region
			if (Checked)
			{
				gr.FillRectangle(white, rect);
				gr.DrawLine(black, new Point(rect.Left + 2, rect.Bottom - 5), new Point(rect.Width / 2 -1, rect.Bottom - 2));
				gr.DrawLine(black, new Point(rect.Width / 2-1, rect.Bottom - 2), new Point(rect.Right - 2, rect.Top + 2));
			}
			else
			{
				gr.FillRectangle(crimson, rect);
				gr.DrawLine(black, new Point(rect.Left + 2, rect.Bottom - 2), new Point(rect.Right - 2, rect.Top + 2));
				gr.DrawLine(black, new Point(rect.Left + 2, rect.Top + 2), new Point(rect.Right - 2, rect.Bottom - 2));
			}

			// Draw rectangle
			gr.DrawRectangle(border, rect);

			// Draw rounded rectangle
			if (Parent != null) {
				Pen backPen = new Pen(Parent.BackColor);
				gr.DrawLine(backPen, new Point(rect.Left, rect.Top), new Point(rect.Left - 1, rect.Top - 1));
				gr.DrawLine(backPen, new Point(rect.Left, rect.Bottom), new Point(rect.Left - 1, rect.Bottom + 1));
				gr.DrawLine(backPen, new Point(rect.Right, rect.Top), new Point(rect.Right + 1, rect.Top - 1));
				gr.DrawLine(backPen, new Point(rect.Right, rect.Bottom), new Point(rect.Right + 1, rect.Bottom + 1));
			}
		}

		/// <summary>
		/// Raised when the checked state of the SweetieBox changes
		/// </summary>
		public event EventHandler CheckedChanged;
	}
}
