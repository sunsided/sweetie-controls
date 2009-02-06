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
	[ToolboxBitmap(typeof(ProgressBar))]
	[DefaultProperty("Value")]
	[Description("SweetieProgress progress bar control")]
	public partial class SweetieProgress : UserControl
	{

		/// <summary>
		/// The height
		/// </summary>
		private const int FixedHeight = 11;

		public SweetieProgress()
		{
			ForeColor = Color.White;
			InitializeComponent();
		}

		private int _min = 0;

		/// <summary>
		/// Gets or sets the minimum value
		/// </summary>
		[Browsable(true)]
		[Description("Sets the minimum value of the progress bar")]
		[DefaultValue(0)]
		public int Minimum
		{
			get { return _min; }
			set { _min = value; Invalidate(); }
		}
		private int _max = 100;

		/// <summary>
		/// Gets or sets the maximal value
		/// </summary>
		[Browsable(true)]
		[Description("Sets the maximal value.")]
		[DefaultValue(100)]
		public int Maximum
		{
			get { return _max; }
			set { _max = value; Invalidate(); }
		}

		private int _value = 50;

		/// <summary>
		/// Gets or sets the current value
		/// </summary>
		[Browsable(true)]
		[Description("Sets the value of the progress bar.")]
		[DefaultValue(50)]
		public int Value
		{
			get { return _value; }
			set { _value = value; Invalidate(); }
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
			set { _BorderColor = value; Invalidate(); }
		}

		private Color _BorderColor = Color.Black;
		private Color _LightBackground = Color.White;
		private Color _DarkBackground = Color.WhiteSmoke;
		private Color _Foreground_Shade = Color.SteelBlue;
		private Color _Foreground_Bottom = Color.CornflowerBlue;

		/// <summary>
		/// Gets or sets the bright background color
		/// </summary>
		[Description("Sets the bright background color")]
		[Category("Appearance")]
		[Browsable(true)]
		public Color LightBackground
		{
			get { return _LightBackground; }
			set { _LightBackground = value; Invalidate(); }
		}

		/// <summary>
		/// Gets or sets the dark background color
		/// </summary>
		[Description("Sets the dark background color")]
		[Category("Appearance")]
		[Browsable(true)]
		public Color DarkBackground
		{
			get { return _DarkBackground; }
			set { _DarkBackground = value; Invalidate(); }
		}

		/// <summary>
		/// Gets or sets the dark foreground color
		/// </summary>
		[Description("Sets the dark foreground color")]
		[Category("Appearance")]
		[Browsable(true)]
		public Color ForegroundShadeColor
		{
			get { return _Foreground_Shade; }
			set { _Foreground_Shade = value; Invalidate(); }
		}

		/// <summary>
		/// Gets or sets the bottom foreground color
		/// </summary>
		[Description("Sets the bottom foreground color")]
		[Category("Appearance")]
		[Browsable(true)]
		public Color ForegroundBottomColor
		{
			get { return _Foreground_Bottom; }
			set { _Foreground_Bottom = value; Invalidate(); }
		}

		protected override void OnForeColorChanged(EventArgs e)
		{
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			int val = Value > Maximum ? Maximum : Value < Minimum ? Minimum : Value;

			int leftOffset = 2;
			int topOffset = 2;
			int height = ClientRectangle.Height - 2 * topOffset;
			int widthMax = ClientRectangle.Width - 2 * leftOffset;
			int width = (int)(widthMax * ((float)val) / ((float)Maximum - (float)Minimum));

			Graphics gr = e.Graphics;

			if (AntiAlias)
			{
				gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				height-=1;
			}
			else
				gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

			Rectangle rect = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

			//Brush white = new SolidBrush(_LightBackground_Enab);
			Brush white = new System.Drawing.Drawing2D.LinearGradientBrush(rect, _DarkBackground, _LightBackground, 0.0f);

			Pen black = new Pen(ForeColor);
			Pen border = new Pen(BorderColor);

			// Fill background
			gr.FillRectangle(white, rect);

			// Fill block
			if (width > 0)
			{
				Rectangle rectBlockTop = new Rectangle(leftOffset, topOffset, width, height / 2);
				Rectangle rectBlockBottom = new Rectangle(leftOffset, topOffset + height / 2 - 1, width, height / 2 + 2);
				Brush crimsonTop = new System.Drawing.Drawing2D.LinearGradientBrush(rectBlockTop, ForegroundShadeColor, ForeColor, -90.0f);
				Brush crimsonBottom = new System.Drawing.Drawing2D.LinearGradientBrush(rectBlockBottom, ForegroundShadeColor, this._Foreground_Bottom, 90.0f);
				gr.FillRectangle(crimsonBottom, rectBlockBottom);
				gr.FillRectangle(crimsonTop, rectBlockTop);
			}

			// Round block
			if (RoundRectangle)
			{
				Pen darkPen = new Pen(_DarkBackground);
				Pen lightPen = new Pen(_LightBackground);
				gr.DrawLine(darkPen, new Point(leftOffset, topOffset), new Point(leftOffset - 1, topOffset - 1));
				gr.DrawLine(darkPen, new Point(leftOffset, topOffset + height - 1), new Point(leftOffset - 1, topOffset + height));
				gr.DrawLine(lightPen, new Point(leftOffset + width - 1, topOffset), new Point(leftOffset + width, topOffset - 1));
				gr.DrawLine(lightPen, new Point(leftOffset + width - 1, topOffset + height - 1), new Point(leftOffset + width, topOffset + height));
			}

			// Draw rectangle
			gr.DrawRectangle(border, rect);

			// Draw rounded rectangle
			if (Parent != null)
			{
				Pen backPen = new Pen(Parent.BackColor);
				gr.DrawLine(backPen, new Point(rect.Left, rect.Top), new Point(rect.Left - 1, rect.Top - 1));
				gr.DrawLine(backPen, new Point(rect.Left, rect.Bottom), new Point(rect.Left - 1, rect.Bottom + 1));
				gr.DrawLine(backPen, new Point(rect.Right, rect.Top), new Point(rect.Right + 1, rect.Top - 1));
				gr.DrawLine(backPen, new Point(rect.Right, rect.Bottom), new Point(rect.Right + 1, rect.Bottom + 1));
			}
		}

		protected override void OnResize(EventArgs e)
		{
			if (Height != FixedHeight)
			{
				Height = FixedHeight;
				return;
			}
			Invalidate();
		}

		private bool _hq = false;

		/// <summary>
		/// Gets or sets whether antialiasing is enabled
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Sets whether anti-aliasing is enabled")]
		public bool AntiAlias
		{
			get { return _hq; }
			set { _hq = value; Invalidate(); }
		}

		private bool _round = false;

		/// <summary>
		/// Gets or sets whether the progress bar is rounded
		/// </summary>
		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Sets whether the progress bar is rounded")]
		public bool RoundRectangle
		{
			get { return _round; }
			set { _round = value; Invalidate(); }
		}

		[DefaultValue(typeof(Size), "150, 11")]
		public new Size Size
		{
			get { return base.Size; }
			set { base.Size = value; }
		}

		[DefaultValue(typeof(Size), "11, 11")]
		public new Size MinimumSize
		{
			get { return base.MinimumSize; }
			set { base.MinimumSize = value; }
		}

		[DefaultValue(typeof(Size), "0, 11")]
		public new Size MaximumSize
		{
			get { return base.MaximumSize; }
			set { base.MaximumSize = value; }
		}
	}
}
