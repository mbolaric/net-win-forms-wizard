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

namespace BitLaboratory.Windows.WizardFramework.Helpers
{
	/// <summary>
	/// Drawing Helper Functions
	/// </summary>
	internal class DrawingHelper
	{
		public DrawingHelper()
		{

		}

		public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, WizardImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect, Point scrollOffset, RightToLeft rightToLeft)
		{
			if (g == null)
			{
				throw new ArgumentNullException("g");
			}
			if (backgroundImageLayout == WizardImageLayout.Tile)
			{
				using (TextureBrush brush = new TextureBrush(backgroundImage, WrapMode.Tile))
				{
					if (scrollOffset != Point.Empty)
					{
						Matrix transform = brush.Transform;
						transform.Translate((float) scrollOffset.X, (float) scrollOffset.Y);
						brush.Transform = transform;
					}
					g.FillRectangle(brush, clipRect);
					return;
				}
			}
			Rectangle rect = CalculateBackgroundImageRectangle(bounds, backgroundImage, backgroundImageLayout);
			if ((rightToLeft == RightToLeft.Yes) && (backgroundImageLayout == WizardImageLayout.None))
			{
				rect.X += clipRect.Width - rect.Width;
			}
			using (SolidBrush brush2 = new SolidBrush(backColor))
			{
				g.FillRectangle(brush2, clipRect);
			}
			if (!clipRect.Contains(rect))
			{
				if ((backgroundImageLayout == WizardImageLayout.Stretch) || (backgroundImageLayout == WizardImageLayout.Zoom))
				{
					rect.Intersect(clipRect);
					g.DrawImage(backgroundImage, rect);
				}
				else if (backgroundImageLayout == WizardImageLayout.None)
				{
					rect.Offset(clipRect.Location);
					Rectangle destRect = rect;
					destRect.Intersect(clipRect);
					Rectangle rectangle3 = new Rectangle(Point.Empty, destRect.Size);
					g.DrawImage(backgroundImage, destRect, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, GraphicsUnit.Pixel);
				}
				else
				{
					Rectangle rectangle4 = rect;
					rectangle4.Intersect(clipRect);
					Rectangle rectangle5 = new Rectangle(new Point(rectangle4.X - rect.X, rectangle4.Y - rect.Y), rectangle4.Size);
					g.DrawImage(backgroundImage, rectangle4, rectangle5.X, rectangle5.Y, rectangle5.Width, rectangle5.Height, GraphicsUnit.Pixel);
				}
			}
			else
			{
				ImageAttributes imageAttr = new ImageAttributes();
				imageAttr.SetWrapMode(WrapMode.TileFlipXY);
				g.DrawImage(backgroundImage, rect, 0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel, imageAttr);
				imageAttr.Dispose();
			}
		}

		public static Rectangle CalculateBackgroundImageRectangle(Rectangle bounds, Image backgroundImage, WizardImageLayout imageLayout)
		{
			Rectangle rectangle = bounds;
			if (backgroundImage != null)
			{
				switch (imageLayout)
				{
					case WizardImageLayout.None:
						rectangle.Size = backgroundImage.Size;
						return rectangle;

					case WizardImageLayout.Tile:
						return rectangle;

					case WizardImageLayout.Center:
					{
						rectangle.Size = backgroundImage.Size;
						Size size = bounds.Size;
						if (size.Width > rectangle.Width)
						{
							rectangle.X = (size.Width - rectangle.Width) / 2;
						}
						if (size.Height > rectangle.Height)
						{
							rectangle.Y = (size.Height - rectangle.Height) / 2;
						}
						return rectangle;
					}
					case WizardImageLayout.Stretch:
						rectangle.Size = bounds.Size;
						return rectangle;

					case WizardImageLayout.Zoom:
					{
						Size size2 = backgroundImage.Size;
						float num = ((float) bounds.Width) / ((float) size2.Width);
						float num2 = ((float) bounds.Height) / ((float) size2.Height);
						if (num >= num2)
						{
							rectangle.Height = bounds.Height;
							rectangle.Width = (int) ((size2.Width * num2) + 0.5);
							if (bounds.X >= 0)
							{
								rectangle.X = (bounds.Width - rectangle.Width) / 2;
							}
							return rectangle;
						}
						rectangle.Width = bounds.Width;
						rectangle.Height = (int) ((size2.Height * num) + 0.5);
						if (bounds.Y >= 0)
						{
							rectangle.Y = (bounds.Height - rectangle.Height) / 2;
						}
						return rectangle;
					}
				}
			}
			return rectangle;
		}

		public static StringFormat CreateFormattingInformation(bool rtl, bool allowWrap, StringAlignment horizontalAlignment, StringAlignment verticalAlignment, bool showMnemonics)
		{
			StringFormat format = new StringFormat(StringFormat.GenericTypographic);
			if (rtl)
			{
				format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
			}
			if (!allowWrap)
			{
				format.FormatFlags = StringFormatFlags.NoWrap;
			}
			format.Trimming = StringTrimming.EllipsisCharacter;
			format.LineAlignment = verticalAlignment;
			format.Alignment = horizontalAlignment;
			format.HotkeyPrefix = showMnemonics ? HotkeyPrefix.Show : HotkeyPrefix.Hide;
			return format;
		}

		public static Size MeasureText(Graphics graphics, string text, Font font, StringFormat textFormat)
		{
			return Size.Ceiling(graphics.MeasureString(text, font, 0x7fffffff, textFormat));
		}

		public static Size MeasureText(Graphics graphics, string text, Font font, int width, StringFormat textFormat)
		{
			return Size.Ceiling(graphics.MeasureString(text, font, width, textFormat));
		}
	}
}
