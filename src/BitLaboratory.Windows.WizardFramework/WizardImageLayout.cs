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

namespace BitLaboratory.Windows.WizardFramework
{
	/// <summary>
	/// Image Layout
	/// </summary>
	public enum WizardImageLayout
	{
		/// <summary>
		/// Image is not shown
		/// </summary>
		None = 0,
		/// <summary>
		/// Tile Image
		/// </summary>
		Tile = 1,
		/// <summary>
		/// Center Image
		/// </summary>
		Center = 2,
		/// <summary>
		/// Stretch IMge
		/// </summary>
		Stretch = 3,
		/// <summary>
		/// Zoom Image
		/// </summary>
		Zoom = 4
	}
}
