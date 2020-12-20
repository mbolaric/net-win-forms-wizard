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
using System.Data;
using System.ComponentModel;
using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.ComponentModel.Design;
using System.Drawing;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using BitLaboratory.Windows.WizardFramework.Design;
using BitLaboratory.Windows.WizardFramework.Collection;

namespace BitLaboratory.Windows.WizardFramework
{
	/// <summary>
	/// Wizard page Layout styles
	/// </summary>
	public enum PageStyle
	{
		/// <summary>
		/// Wizard layout with header.
		/// </summary>
		PageWithHeader,
		/// <summary>
		/// Empty wizard page Layout
		/// </summary>
		EmptyPage
	}
	
	/// <summary>
	/// Wizard Page Item
	/// </summary>
	[TypeConverter(typeof(WizardTypeConverter)), ToolboxItem(false)]
	[ToolboxBitmap( typeof(WizardPage), "Resources.WizardPage.bmp" )]
	public class WizardPage: ContainerControl
	{	
		private WizardControl _parentWizard;

		private WizardButtonInfo _buttonMoveNext;
		private WizardButtonInfo _buttonMovePrevious;

		private WizardButtonInfo _buttonCancel;
		private WizardButtonInfo _buttonFinish;
		private WizardButtonInfo _buttonHelp;

		private string _headerCaption = "Header caption";
		private string _subHeaderCaption = "Sub Header caption";
		private Font _subHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		private Color _subHeaderColor = Color.Black;
		private Font _headerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		private Color _headerColor = Color.Black;


		private PageStyle _pageStyle = PageStyle.PageWithHeader;
		
		internal event EventHandler Changed;
		internal event ButtonStateChangedEventHandler ButtonStateChanged;
		
		/// <summary>
		/// Default Constructor
		/// </summary>
		public WizardPage()
		{
			this._buttonMoveNext = new WizardButtonInfo( true, true);
			this._buttonMoveNext.Changed += new EventHandler(OnButtonMoveNextChanged);
			this._buttonMovePrevious = new WizardButtonInfo(true, true);
			this._buttonMovePrevious.Changed += new EventHandler(OnButtonMovePreviousChanged);

			this._buttonCancel = new WizardButtonInfo(true, true);
			this._buttonCancel.Changed += new EventHandler(OnButtonCancelChanged);
			this._buttonFinish = new WizardButtonInfo(true, true);
			this._buttonFinish.Changed += new EventHandler(OnButtonFinishChanged);
			this._buttonHelp = new WizardButtonInfo(true, true);
			this._buttonHelp.Changed += new EventHandler(OnBbuttonHelpChanged);
		}

		/// <summary>
		/// Main Header caption for pages with interior Pagestyle
		/// </summary>
		/// <value></value>
		[Description("Main Header caption for pages with interior Pagestyle")]
		[Category("Appearance")]
		[Localizable(true)]
		public string HeaderCaption
		{
			get{ return _headerCaption; }
			set
			{
				_headerCaption = value;
				OnChanged(this, new EventArgs());
			}
		}
		
		/// <summary>
		/// Header text font
		/// </summary>
		[Category("Appearance")]
		public Font HeaderFont
		{
			get{ return _headerFont; }
			set
			{
				_headerFont = value;
				OnChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// Header text color
		/// </summary>
		[Category("Appearance")]
		public Color HeaderColor
		{
			get{ return _headerColor; }
			set
			{
				_headerColor = value;
				OnChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// Sub header caption for pages with interior Pagestyle
		/// </summary>
		/// <value></value>
		[Description("Sub header caption for pages with interior Pagestyle")]
		[Category("Appearance")]
		[Localizable(true)]
		public string SubHeaderCaption
		{
			get{ return _subHeaderCaption; }
			set
			{
				_subHeaderCaption = value;
				OnChanged(this, new EventArgs());
			}
		}
		
		/// <summary>
		/// Sub header text font
		/// </summary>
		[Category("Appearance")]
		public Font SubHeaderFont
		{
			get{ return _subHeaderFont; }
			set
			{
				_subHeaderFont = value;
				OnChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// Sub header text color
		/// </summary>
		[Category("Appearance")]
		public Color SubHeaderColor
		{
			get{ return _subHeaderColor; }
			set
			{
				_subHeaderColor = value;
				OnChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// Sets the page Style (PageWithHeader or EmptyPage)
		/// </summary>
		/// <value></value>
		[Description("Sets or Gets the page Style (PageWithHeader or EmptyPage)")]
		[Category("Behavior")]
		public PageStyle PageStyle
		{
			get{ return _pageStyle; }
			set
			{
				_pageStyle = value;
				OnChanged(this, new EventArgs());
			}
		}
		
		/// <summary>
		/// Next Button Info
		/// </summary>
		[Category("Behavior")]
		[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public WizardButtonInfo ButtonMoveNext
		{
			get{ return _buttonMoveNext; }
		}

		/// <summary>
		/// Previous Button Info
		/// </summary>
		[Category("Behavior")]
		[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public WizardButtonInfo ButtonMovePrevious
		{
			get{ return _buttonMovePrevious; }
		}

		/// <summary>
		/// Cancel Button Info
		/// </summary>
		[Category("Behavior")]
		[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public WizardButtonInfo ButtonCancel
		{
			get{ return _buttonCancel; }
		}

		/// <summary>
		/// Finish Button Info
		/// </summary>
		[Category("Behavior")]
		[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public WizardButtonInfo ButtonFinish
		{
			get{ return _buttonFinish; }
		}

		/// <summary>
		/// Help Button Info
		/// </summary>
		[Category("Behavior")]
		[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public WizardButtonInfo ButtonHelp
		{
			get{ return _buttonHelp; }
		}

		/// <summary>
		/// Wizard is changed
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event args</param>
		protected internal void OnChanged(object sender, EventArgs e)
		{
			if (Changed != null)
				Changed(sender, e);
		}
	
		/// <summary>
		/// Button state is changed
		/// </summary>
		/// <param name="sender">sender object</param>
		/// <param name="e">Event args</param>
		protected internal void OnButtonStateChanged(object sender, ButtonStateEventArgs e ) //bool bEnabled, bool visible)
		{
			if (ButtonStateChanged != null)
			{
				ButtonStateChanged(sender, e);
			}
		}

		/// <summary>
		///     Make sure the panels docked state = dockstyle.none
		///     The wizard Will handle the sizing of the controls
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDockChanged(System.EventArgs e)
		{
			this.Dock = DockStyle.None;
		}

		private void OnButtonMoveNextChanged(object sender, EventArgs e)
		{
			this.OnButtonStateChanged(this, new ButtonStateEventArgs( WizardButtons.Next, _buttonMoveNext.Allow, _buttonMoveNext.Visible )); // true ));
		}

		private void OnButtonMovePreviousChanged(object sender, EventArgs e)
		{
			this.OnButtonStateChanged(this, new ButtonStateEventArgs( WizardButtons.Previous, _buttonMovePrevious.Allow, _buttonMovePrevious.Visible )); // true));
		}

		private void OnButtonCancelChanged(object sender, EventArgs e)
		{
			this.OnButtonStateChanged(this, new ButtonStateEventArgs( WizardButtons.Cancel, _buttonCancel.Allow, _buttonCancel.Visible));
		}

		private void OnButtonFinishChanged(object sender, EventArgs e)
		{
			this.OnButtonStateChanged(this, new ButtonStateEventArgs( WizardButtons.Finish, _buttonFinish.Allow, _buttonFinish.Visible));
		}

		private void OnBbuttonHelpChanged(object sender, EventArgs e)
		{
			this.OnButtonStateChanged(this, new ButtonStateEventArgs( WizardButtons.Help, _buttonHelp.Allow, _buttonHelp.Visible));
		}

		internal WizardControl WizardControl
		{
			get { return _parentWizard; }
			set { _parentWizard = value; }
		}

	}
}
