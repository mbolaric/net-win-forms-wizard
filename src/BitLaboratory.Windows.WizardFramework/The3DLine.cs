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
using Microsoft.VisualBasic;
using System.Data;
using System.ComponentModel;
using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.ComponentModel.Design;
using System.Drawing;


namespace BitLaboratory.Windows.WizardFramework
{
	/// <summary>
	/// Simple 3D Line control
	/// </summary>
	internal class The3DLine : Control
	{
		
		private int _spacing;
		private Border3DStyle _borderStyle = Border3DStyle.Etched;
		
		public The3DLine()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			UpdateStyles();
		}
		
		[System.ComponentModel.Category("Appearance")]
		public string HeaderText
		{
			get{ return Text; }
			set
			{
				Text = value;
				this.Invalidate();
			}
		}
		
		[System.ComponentModel.Category("Appearance")]
		public Border3DStyle LineStyle
		{
			get{ return _borderStyle; }
			set
			{
				if (value != _borderStyle)
				{
					_borderStyle = value;
					this.Invalidate();
				}
			}
		}

		[System.ComponentModel.Category("Appearance")]
		public int Spacing
		{
			get{ return _spacing; }
			set
			{
				if (value != _spacing)
				{
					_spacing = value;
					this.Invalidate();
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Font font = this.Font;
			using( Brush b = new SolidBrush(this.ForeColor) )
			{
				StringFormat sf = StringFormat.GenericTypographic;
				RectangleF labelBounds = new RectangleF(0, 0, this.Width, this.Height);
				SizeF textSize = g.MeasureString(this.Text, font, this.Width);
				g.DrawString(this.Text, font, b, 0, 0, sf);
				if (textSize.Width + Spacing < this.Width)
				{
					Point startingPoint = new System.Drawing.Point();
					startingPoint.X = (int) (textSize.Width + Spacing);
					startingPoint.Y = (int) (textSize.Height / 2);
					ControlPaint.DrawBorder3D(g, startingPoint.X, startingPoint.Y, this.Width - startingPoint.X, 5, _borderStyle, Border3DSide.Top);
				}
			}
		}
	}
}

