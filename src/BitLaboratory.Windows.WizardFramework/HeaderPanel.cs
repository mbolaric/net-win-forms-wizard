/*
* Copyright 2008 - BitLaboratory
*
* Permission is hereby granted, free of charge, to any person obtaining a copy 
* of this software and associated documentation files (the "Software"), to 
* deal in the Software without restriction, including without limitation the
* rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
* sell copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE. 
 */
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BitLaboratory.Windows.WizardFramework.Helpers;

namespace BitLaboratory.Windows.WizardFramework
{
	/// <summary>
	/// Wizard Header Panel
	/// </summary>
	internal class HeaderPanel : Control
	{
		private WizardImageLayout _bannerImageLayout = WizardImageLayout.Tile;
		private String _headerTitle = String.Empty;
		private String _headerSubTitle = String.Empty;
		private Font _titleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		private Color _titleColor = Color.Black;
		private Font _subTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		private Color _subTitleColor = Color.Black;

		public HeaderPanel()
		{
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.Selectable, false);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.DoubleBuffer, true);
		}

		public WizardImageLayout BannerImageLayout
		{
			get{ return _bannerImageLayout; }
			set
			{ 
				_bannerImageLayout = value; 
				this.Invalidate();
			}
		}

		public String Title
		{
			get{ return _headerTitle; }
			set{ _headerTitle = value; }
		}

		public Font TitleFont
		{
			get{ return _titleFont; }
			set{ _titleFont = value; }
		}

		public Color TitleColor
		{
			get{ return _titleColor; }
			set{ _titleColor = value; }
		}

		public Font SubTitleFont
		{
			get{ return _subTitleFont; }
			set{ _subTitleFont = value; }
		}

		public String SubTitle
		{
			get{ return _headerSubTitle; }
			set{ _headerSubTitle = value; }
		}

		public Color SubTitleColor
		{
			get{ return _subTitleColor; }
			set{ _subTitleColor = value; }
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			if (this.BackgroundImage != null && this.BannerImageLayout != WizardImageLayout.None)
				DrawingHelper.DrawBackgroundImage( pevent.Graphics, this.BackgroundImage, this.BackColor, this._bannerImageLayout,
					this.ClientRectangle, this.ClientRectangle,  new Point(0), this.RightToLeft);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
			StringFormat format = DrawingHelper.CreateFormattingInformation(this.RightToLeft == System.Windows.Forms.RightToLeft.Yes, true, StringAlignment.Near, StringAlignment.Near, false);

			String testString = this.Title;
			if( this.Title == null || this.Title == String.Empty )
				testString = "BitLaboratory";

			Size size = DrawingHelper.MeasureText( e.Graphics, testString, this.TitleFont, format);
			Rectangle titleBounds = new Rectangle( 0, 8, this.Width,  size.Height );
			
			using (SolidBrush brush = new SolidBrush(this.TitleColor))
			{
				titleBounds.Inflate( -8, 0 );
				e.Graphics.DrawString(this.Title, this.TitleFont, brush, titleBounds, format);
			}

			using (SolidBrush brush = new SolidBrush(this.SubTitleColor))
			{
				size = DrawingHelper.MeasureText( e.Graphics, this.SubTitle, this.SubTitleFont, format);
				Rectangle bounds = new Rectangle( 0, titleBounds.Bottom + 3, this.Width,  size.Height );
				bounds.Inflate( -32, 0 );
				e.Graphics.DrawString(this.SubTitle, this.SubTitleFont, brush, bounds, format);
			}
		}
	}
}
