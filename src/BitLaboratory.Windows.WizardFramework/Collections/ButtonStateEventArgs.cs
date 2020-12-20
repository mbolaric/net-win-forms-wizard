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

namespace BitLaboratory.Windows.WizardFramework.Collection
{
	/// <summary>
	/// Posible Wizard Buttons
	/// </summary>
	public enum WizardButtons
	{
		/// <summary>
		/// Help Button
		/// </summary>
		Help,
		/// <summary>
		/// Cancel Button
		/// </summary>
		Cancel,
		/// <summary>
		/// Finish Button
		/// </summary>
		Finish,
		/// <summary>
		/// Next Button
		/// </summary>
		Next,
		/// <summary>
		/// Previous Button
		/// </summary>
		Previous
	}

	internal delegate void ButtonStateChangedEventHandler (object sender, ButtonStateEventArgs e);

	/// <summary>
	/// Button State Event Arguments.
	/// </summary>
	public class ButtonStateEventArgs
	{
		private bool _allow;
		private bool _visible;
		private WizardButtons _wizardButton;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="wizardButton">Wizard button</param>
		/// <param name="info">Button info</param>
		public ButtonStateEventArgs(WizardButtons wizardButton, WizardButtonInfo info)
		{
			this._wizardButton = wizardButton;
			this._allow = info.Allow;
//			this._text = info.Text;
			this._visible = info.Visible;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="wizardButton">Wizard button</param>
		/// <param name="allow">Is Button allowed</param>
		/// <param name="visible">Is Button visible</param>
		public ButtonStateEventArgs(WizardButtons wizardButton, bool allow, bool visible)
		{
			this._wizardButton = wizardButton;
			this._allow = allow;
//			this._text = text;
			this._visible = visible;
		}

		/// <summary>
		/// Wizard Button
		/// </summary>
		public WizardButtons WizardButtons
		{
			get{ return _wizardButton; }
			set{ _wizardButton = value; }
		}

		/// <summary>
		/// Button Allow
		/// </summary>
		public bool Allow
		{
			get{ return _allow; }
			set{ _allow = value; }
		}

		/// <summary>
		/// Button Visible
		/// </summary>
		public bool Visible
		{
			get{ return _visible; }
			set{ _visible = value; }
		}
	}
}
