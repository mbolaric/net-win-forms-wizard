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
using System.ComponentModel;

using BitLaboratory.Windows.WizardFramework.Design;

namespace BitLaboratory.Windows.WizardFramework
{
	/// <summary>
	/// Wizard Button Description
	/// </summary>
	[TypeConverter(typeof(WizardButtonInfoConverter))]
	public class WizardButtonInfo
	{
		private bool _allow = true;
		private bool _visible = true;

		internal event EventHandler Changed;

		/// <summary>
		/// Default Constructor for Design Time
		/// </summary>
		public WizardButtonInfo()
		{
		}

		/// <summary>
		/// Constructor for initialization
		/// </summary>
		/// <param name="allow">True if button is Allowed.</param>
		/// <param name="visible">True if button is visible.</param>
		public WizardButtonInfo(bool allow, bool visible)
		{
			this._visible = visible;
			this._allow = allow;
		}

		private void OnChanged()
		{
			if (Changed != null)
				Changed( this, EventArgs.Empty );
		}

		/// <summary>
		/// Return if button is visible.
		/// </summary>
		[DefaultValue(true)]
		public bool Visible
		{
			get{ return this._visible; }
			set
			{ 
				if( this._visible != value )
				{
					this._visible = value; 
					OnChanged();
				}
			}
		}

		/// <summary>
		/// Return true if button is allowed.
		/// </summary>
		[DefaultValue(true)]
		public bool Allow
		{
			get{ return this._allow; }
			set
			{ 
				if (this._allow != value)
				{
					this._allow = value; 
					OnChanged();
				}
			}
		}
	}
}
