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
	/// 
	/// </summary>
	public delegate void WizardMoveEventHandler(object sender, WizardMoveEventArgs e);

	/// <summary>
	/// Wizard Move Event Arguments
	/// </summary>
	public class WizardMoveEventArgs : EventArgs
	{
		private WizardPage _previousWizPage;
		private WizardPage _nextWizPage;
		private bool _cancel;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="previousWizPage">Previous wizard page</param>
		/// <param name="nextWizPage">Next wizard page</param>
		public WizardMoveEventArgs(WizardPage previousWizPage, WizardPage nextWizPage)
		{
			this._previousWizPage = previousWizPage;
			this._nextWizPage = nextWizPage;
			this._cancel = false;
		}

		/// <summary>
		/// Previous wizard page.
		/// </summary>
		public WizardPage PreviousPage
		{
			get{ return _previousWizPage; }
			set{ _previousWizPage = value; }
		}

		/// <summary>
		/// >Next wizard page.
		/// </summary>
		public WizardPage NextPage
		{
			get{ return _nextWizPage; }
			set{ _nextWizPage = value; }
		}

		/// <summary>
		/// Cancel Move
		/// </summary>
		public bool Cancel
		{
			get{ return _cancel; }
			set{ _cancel = value; }
		}

	}
}
