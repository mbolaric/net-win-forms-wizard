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
using System.Diagnostics;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Drawing;
using BitLaboratory.Windows.WizardFramework.Design;
using BitLaboratory.Windows.WizardFramework.Collection;

namespace BitLaboratory.Windows.WizardFramework
{
	
	/// <summary>
	/// Wizard Control
	/// </summary>
	[Serializable(), Designer(typeof(WizardControlDesigner), typeof(System.ComponentModel.Design.IDesigner)), ToolboxItem(true)]
	[ToolboxBitmap( typeof(WizardPage), "Resources.WizardControl.bmp" )]
	public class WizardControl : UserControl
	{
		private System.ComponentModel.Container components = null;
		
		private System.Windows.Forms.Panel _buttonBar;
		private System.Windows.Forms.Button _finish;
		private System.Windows.Forms.Button _cancel;
		private System.Windows.Forms.Button _previous;
		private System.Windows.Forms.Button _next;
		private System.Windows.Forms.Button _help;
		private BitLaboratory.Windows.WizardFramework.HeaderPanel _headerPanel;
		private BitLaboratory.Windows.WizardFramework.The3DLine _lineTop;
		private BitLaboratory.Windows.WizardFramework.The3DLine _lineBottom;

		private WizardPageCollection _pages = new WizardPageCollection();
		
		private WizardPage _selectedItem = null;
		private int _startItemIndex;
		private int _currentItemIndex;

		/// <summary>
		/// Wizard Event Delegate
		/// </summary>
		public delegate void WizardEventHandler();

		/// <summary>
		/// 
		/// </summary>
		[Category("Wizard")]
		public event WizardMoveEventHandler BeforeMoveNext;
		/// <summary>
		/// 
		/// </summary>
		[Category("Wizard")]
		public event WizardMoveEventHandler BeforeMovePrevious;
		/// <summary>
		/// 
		/// </summary>
		[Category("Wizard")]
		public event WizardMoveEventHandler AfterMoveNext;
		/// <summary>
		/// 
		/// </summary>
		[Category("Wizard")]
		public event WizardMoveEventHandler AfterMovePrevious;
		/// <summary>
		/// 
		/// </summary>
		[Category("Wizard")]
		public event WizardEventHandler HelpClick;
		/// <summary>
		/// 
		/// </summary>
		[Category("Wizard")]
		public event WizardEventHandler CancelClick;
		/// <summary>
		/// 
		/// </summary>
		[Category("Wizard")]
		public event WizardEventHandler FinishClick;

		/// <summary>
		/// Initialises a new Instance Of The Control
		/// </summary>
		public WizardControl()
		{
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.UserMouse, true);
			SetStyle(ControlStyles.ContainerControl, true);
			SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

			this.UpdateStyles();
			AttachPagesEvents();
			InitializeComponent();			
		}
		
		/// <summary>
		/// Dispose Wizard Component
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
				
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this._buttonBar = new System.Windows.Forms.Panel();
			this._help = new System.Windows.Forms.Button();
			this._previous = new System.Windows.Forms.Button();
			this._next = new System.Windows.Forms.Button();
			this._finish = new System.Windows.Forms.Button();
			this._cancel = new System.Windows.Forms.Button();
			this._lineBottom = new BitLaboratory.Windows.WizardFramework.The3DLine();
			this._headerPanel = new BitLaboratory.Windows.WizardFramework.HeaderPanel();
			this._lineTop = new BitLaboratory.Windows.WizardFramework.The3DLine();
			this._buttonBar.SuspendLayout();
			this._headerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _buttonBar
			// 
			this._buttonBar.Controls.Add(this._help);
			this._buttonBar.Controls.Add(this._previous);
			this._buttonBar.Controls.Add(this._next);
			this._buttonBar.Controls.Add(this._finish);
			this._buttonBar.Controls.Add(this._cancel);
			this._buttonBar.Controls.Add(this._lineBottom);
			this._buttonBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._buttonBar.Location = new System.Drawing.Point(0, 216);
			this._buttonBar.Name = "_buttonBar";
			this._buttonBar.Size = new System.Drawing.Size(472, 40);
			this._buttonBar.TabIndex = 2;
			// 
			// _help
			// 
			this._help.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._help.Location = new System.Drawing.Point(8, 9);
			this._help.Name = "_help";
			this._help.TabIndex = 9;
			this._help.Text = "&Help";
			// 
			// _previous
			// 
			this._previous.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._previous.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._previous.Location = new System.Drawing.Point(152, 8);
			this._previous.Name = "_previous";
			this._previous.Size = new System.Drawing.Size(75, 24);
			this._previous.TabIndex = 1;
			this._previous.Text = "&Previous";
			this._previous.Click += new System.EventHandler(this.OnPreviousClick);
			this._previous.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPreviousMouseUp);
			this._previous.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPreviousMouseDown);
			// 
			// _next
			// 
			this._next.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._next.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._next.Location = new System.Drawing.Point(232, 8);
			this._next.Name = "_next";
			this._next.Size = new System.Drawing.Size(75, 24);
			this._next.TabIndex = 0;
			this._next.Text = "&Next";
			this._next.Click += new System.EventHandler(this.OnNextClick);
			this._next.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnNextMouseUp);
			this._next.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnNextMouseDown);
			// 
			// _finish
			// 
			this._finish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._finish.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._finish.Location = new System.Drawing.Point(312, 8);
			this._finish.Name = "_finish";
			this._finish.Size = new System.Drawing.Size(75, 24);
			this._finish.TabIndex = 7;
			this._finish.Text = "&Finish";
			this._finish.Click += new System.EventHandler(this.OnFinishClick);
			// 
			// _cancel
			// 
			this._cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._cancel.Location = new System.Drawing.Point(392, 8);
			this._cancel.Name = "_cancel";
			this._cancel.TabIndex = 8;
			this._cancel.Text = "&Cancel";
			this._cancel.Click += new System.EventHandler(this.OnCancelClick);
			// 
			// _lineBottom
			// 
			this._lineBottom.BackColor = System.Drawing.SystemColors.Control;
			this._lineBottom.Dock = System.Windows.Forms.DockStyle.Top;
			this._lineBottom.HeaderText = "";
			this._lineBottom.LineStyle = System.Windows.Forms.Border3DStyle.Etched;
			this._lineBottom.Location = new System.Drawing.Point(0, 0);
			this._lineBottom.Name = "_lineBottom";
			this._lineBottom.Size = new System.Drawing.Size(472, 12);
			this._lineBottom.Spacing = 0;
			this._lineBottom.TabIndex = 4;
			// 
			// _headerPanel
			// 
			this._headerPanel.BackColor = System.Drawing.Color.White;
			this._headerPanel.Controls.Add(this._lineTop);
			this._headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._headerPanel.Location = new System.Drawing.Point(0, 0);
			this._headerPanel.Name = "_headerPanel";
			this._headerPanel.Size = new System.Drawing.Size(472, 56);
			this._headerPanel.TabIndex = 3;
			this._headerPanel.Visible = false;
			// 
			// _lineTop
			// 
			this._lineTop.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._lineTop.HeaderText = "";
			this._lineTop.LineStyle = System.Windows.Forms.Border3DStyle.Etched;
			this._lineTop.Location = new System.Drawing.Point(0, 54);
			this._lineTop.Name = "_lineTop";
			this._lineTop.Size = new System.Drawing.Size(472, 2);
			this._lineTop.Spacing = 0;
			this._lineTop.TabIndex = 3;
			// 
			// WizardControl
			// 
			this.Controls.Add(this._buttonBar);
			this.Controls.Add(this._headerPanel);
			this.Name = "WizardControl";
			this.Size = new System.Drawing.Size(472, 256);
			this.EnabledChanged += new System.EventHandler(this.OnWizardEnabledChanged);
			this.Resize += new System.EventHandler(this.OnWizardResize);
			this._buttonBar.ResumeLayout(false);
			this._headerPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		internal Panel ButtonBar
		{
			get{ return this._buttonBar; }
		}

		private void OnPagesChanged(object sender, System.EventArgs e)
		{
			try
			{
				DisplayCurrentPage();
				this.UpdateDesignTimeComponents();
				Invalidate();
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		private void OnlPagesAdded(object sender, EventArgs e)
		{
			try
			{
				if (sender != null)
				{
					if (! this.Controls.Contains((System.Windows.Forms.Control) sender))
					{
						this.Controls.Add((System.Windows.Forms.Control) sender);
					}
					
					if (DesignMode)
					{
						this._currentItemIndex = Pages.IndexOf((BitLaboratory.Windows.WizardFramework.WizardPage) sender);
					}
					DisplayCurrentPage();
				}
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message, ex));
			}
			Invalidate();
		}
		
		private void OnPagesRemoved(object sender, System.EventArgs e)
		{
			WizardPage page = (WizardPage) sender;
			
			try
			{
				if (page.Visible)
				{
					page.Visible = false;
				}
				
				if (page != null)
				{
					this.Controls.Remove(page);
				}
				
				this.Refresh();
			}
			catch (Exception)
			{
				
			}
		}
		
		internal void UpdateDesignTimeComponents()
		{
			if (DesignMode)
			{
				IComponentChangeService c = (IComponentChangeService) GetService(typeof(IComponentChangeService));
				c.OnComponentChanged(this, null, null, null);
				c = null;
				
				ISelectionService selectionService;
				ArrayList items;
				
				if (SelectedPage != null)
				{
					selectionService = (ISelectionService) GetService(typeof(ISelectionService));
					items = new ArrayList();
					items.Add(SelectedPage);
					selectionService.SetSelectedComponents(items);
				}
			}
		}
		
		/// <summary>
		/// Determines what page you want the Wizard to start at
		/// </summary>
		/// <value></value>
		[Description("Determines what page you want the Wizard to start at")]
		[Category("Paging")]
		public int StartItemIndex
		{
			get{ return _startItemIndex; }
			set
			{
				_startItemIndex = value;
				if (_startItemIndex >= Pages.Count)
				{
					_startItemIndex = Pages.Count;
				}
				
				if (_startItemIndex < 0)
				{
					_startItemIndex = 0;
				}
				
				_currentItemIndex = _startItemIndex;
				DisplayCurrentPage();
				Invalidate();
			}
		}

		/// <summary>
		/// Banner Image
		/// </summary>
		[Description("Sets or Gets the Banner image for PageWithHeader Pages")]
		[Category("Appearance")]
		public Image BannerImage
		{
			get{ return this._headerPanel.BackgroundImage; }
			set
			{
				this._headerPanel.BackgroundImage = value;
				Invalidate();
			}
		}
		
		/// <summary>
		/// Bunner image layout
		/// </summary>
		[Description("Sets or Gets the Banner layout for PageWithHeader Pages")]
		[DefaultValue(WizardImageLayout.Tile)]
		[Category("Appearance")]
		public WizardImageLayout BannerImageLayout
		{
			get{ return this._headerPanel.BannerImageLayout; }
			set
			{
				this._headerPanel.BannerImageLayout = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Wizard page collection.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("Wizard page collection")]
		[Category("Paging")]
		public WizardPageCollection Pages
		{
			get
			{
				return (_pages == null ? new WizardPageCollection() : _pages);
			}
			set
			{
				if( _pages != null )
					DetatchPagesEvents();
				_pages = value;
				AttachPagesEvents();
				
				this.Invalidate();
			}
		}
		
		private void DetatchPagesEvents()
		{
			_pages.Changed -= new EventHandler(OnPagesChanged);
			_pages.Added -= new EventHandler(OnlPagesAdded);
			_pages.Removed -= new EventHandler(OnPagesRemoved);

			_pages.ButtonStateChanged -= new ButtonStateChangedEventHandler(OnPagesButtonStateChanged);
		}

		private void AttachPagesEvents()
		{
			_pages.Changed += new EventHandler(OnPagesChanged);
			_pages.Added += new EventHandler(OnlPagesAdded);
			_pages.Removed += new EventHandler(OnPagesRemoved);

			_pages.ButtonStateChanged += new ButtonStateChangedEventHandler(OnPagesButtonStateChanged);
		}

		private void OnPagesButtonStateChanged(object sender, ButtonStateEventArgs e)
		{
			if (sender == this.CurrentPage)
			{
				switch( e.WizardButtons )
				{
					case WizardButtons.Cancel:
						this._cancel.Enabled = e.Allow;
						this._cancel.Visible = e.Visible;
						break;
					case WizardButtons.Finish:
						this._finish.Enabled = e.Allow;
						this._finish.Visible = e.Visible;
						break;
					case WizardButtons.Help:
						this._help.Enabled = e.Allow;
						this._help.Visible = e.Visible;
						break;
					case WizardButtons.Next:
						this._next.Enabled = e.Allow;
						break;
					case WizardButtons.Previous:
						this._previous.Enabled = e.Allow;
						break;
				}
			}
			this.Refresh();
			Invalidate();
		}

		/// <summary>
		/// Return current selected page
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(false), Description("Gets the current page")]
		[Category("Paging")]
		public WizardPage CurrentPage
		{
			get{ return Pages[_currentItemIndex]; }
		}
		
		[DefaultValue(typeof(WizardPage), null)]
		internal WizardPage SelectedPage
		{
			get{ return Pages[_currentItemIndex]; }
			set
			{
				try
				{
					_selectedItem = value;
				}
				catch (Exception)
				{
				}
				Invalidate();
			}
		}
		
		/// <summary>
		/// Go to next wizard page
		/// </summary>
		public void GoNext()
		{
			this.GotoPage( _currentItemIndex + 1 );
		}

		/// <summary>
		/// Go to previous wizard page
		/// </summary>
		public void GoPrevious()
		{
			this.GotoPage( _currentItemIndex - 1 );
		}

		/// <summary>
		/// Navigates you to the page you want to display
		/// </summary>
		/// <param name="Index">Page Index</param>
		public void GotoPage(int Index)
		{
			try
			{
				if (Index < 0 || Index > Pages.Count)
				{
					throw new Exception("No panel with that index exists!");
				}
				else
				{
					_currentItemIndex = Index;
					
					if (_currentItemIndex >= Pages.Count)
					{
						_currentItemIndex = Pages.Count;
					}
					
					if (_currentItemIndex < 0)
					{
						_currentItemIndex = 0;
					}
					DisplayCurrentPage();
				}
			}
			catch (Exception)
			{
			}
			Invalidate();
		}
		
		
		/// <summary>
		/// checks the current state of the wizard
		/// also checks for designmode, so we can edit at design time
		/// </summary>
		private void CheckState()
		{
			_previous.Enabled = _currentItemIndex > 0;
			
			if (DesignMode)
			{
				this._next.Enabled = true;
				this._previous.Enabled = true;
				this._cancel.Enabled = false;
				this._finish.Enabled = false;
				this._help.Enabled = false;
			}
			else
			{
				if (Pages.Count > 0)
				{
					if (SelectedPage != null)
					{
						OnPagesButtonStateChanged( SelectedPage, new ButtonStateEventArgs( WizardButtons.Finish, SelectedPage.ButtonFinish ) );
						OnPagesButtonStateChanged( SelectedPage, new ButtonStateEventArgs( WizardButtons.Cancel, SelectedPage.ButtonCancel ) );
						OnPagesButtonStateChanged( SelectedPage, new ButtonStateEventArgs( WizardButtons.Help, SelectedPage.ButtonHelp ) );

						OnPagesButtonStateChanged( SelectedPage, new ButtonStateEventArgs( WizardButtons.Next, SelectedPage.ButtonMoveNext.Allow,  true ) );
						OnPagesButtonStateChanged( SelectedPage, new ButtonStateEventArgs( WizardButtons.Previous, SelectedPage.ButtonMovePrevious.Allow , true ) );

						if (_startItemIndex > 0)
						{
							bool enabled = _currentItemIndex > _startItemIndex && SelectedPage.ButtonMovePrevious.Allow;
							OnPagesButtonStateChanged( SelectedPage, new ButtonStateEventArgs( WizardButtons.Previous, enabled, true ) );
						}
						else
						{
							bool enabled = _currentItemIndex > 0 && SelectedPage.ButtonMovePrevious.Allow;
							if( _previous.Enabled != enabled )
								OnPagesButtonStateChanged( SelectedPage, new ButtonStateEventArgs( WizardButtons.Previous, enabled, true ) );
						}
						
						if (_next.Enabled)
						{
							bool enabled = _currentItemIndex < (Pages.Count - 1);
							if( _next.Enabled != enabled )
								OnPagesButtonStateChanged( SelectedPage, new ButtonStateEventArgs( WizardButtons.Next, enabled, true ) );
						}
					}
					else
					{
						this._finish.Enabled = false;
						this._next.Enabled = false;
						this._previous.Enabled = false;
						this._cancel.Enabled = false;
						this._help.Enabled = false;
					}
				}
				else
				{
					this._finish.Enabled = false;
					this._next.Enabled = false;
					this._previous.Enabled = false;
					this._cancel.Enabled = false;
					this._help.Enabled = false;
				}
				
			}
		}
		
		/// <summary>
		/// Control is added to Wizard
		/// </summary>
		/// <param name="e">Control Event args</param>
		protected override void OnControlAdded(ControlEventArgs e)
		{
			try
			{
				DisplayCurrentPage();
				Invalidate();
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		/// <summary>
		/// Control is removed to Wizard
		/// </summary>
		/// <param name="e">Control Event args</param>
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			if (e.Control.GetType() == typeof(WizardPage))
			{
				if (Pages.IndexOf((BitLaboratory.Windows.WizardFramework.WizardPage) e.Control) == _currentItemIndex)
				{
					_currentItemIndex--;
					
					if (_currentItemIndex < 0)
					{
						_currentItemIndex = 0;
					}
					
					this.DisplayCurrentPage();
				}
				
				// Remove The control From The Parent form
				if (!System.Convert.ToBoolean(FindForm() == null))
				{
					FindForm().Controls.Remove(e.Control);
				}
				
				this.Pages.Remove((BitLaboratory.Windows.WizardFramework.WizardPage) e.Control);
				
				// Reset The Design Time Layout
				if (this.DesignMode)
				{
					_currentItemIndex = 0;
					this.InitLayout();
				}
				Application.DoEvents();
			}
		}

		/// <summary>
		/// Control got a focus
		/// </summary>
		/// <param name="e">Control Event args</param>
		protected override void OnGotFocus(System.EventArgs e)
		{
			if (SelectedPage != null)
			{
				SelectedPage.Focus();
			}
		}
		
		/// <summary>
		/// Initialize layout
		/// </summary>
		protected override void InitLayout()
		{
			_currentItemIndex = this.StartItemIndex;
			DisplayCurrentPage();
			CheckState();
			Invalidate();
		}
				
		private void OnWizardEnabledChanged(object sender, System.EventArgs e)
		{
			Invalidate();
		}
		
		private void OnWizardResize(object sender, System.EventArgs e)
		{
			DisplayCurrentPage();
			Invalidate();
		}
		
		private void OnNextClick(System.Object sender, System.EventArgs e)
		{
			int beforePageIndex = _currentItemIndex;
			int nextPageIndex = _currentItemIndex + 1;

			if (nextPageIndex < Pages.Count)
			{
				WizardMoveEventArgs moveEvent = new WizardMoveEventArgs(this.Pages[beforePageIndex], this.Pages[nextPageIndex]);
				OnBeforeMoveNext( moveEvent);

				if( !moveEvent.Cancel )
				{
					if( this.Pages[nextPageIndex] != moveEvent.NextPage )
					{
						_currentItemIndex = this.Pages.IndexOf(moveEvent.NextPage);
					}
					else
					{
						_currentItemIndex++;
					}
					DisplayCurrentPage();
					OnAfterMoveNext( moveEvent );
				}
			}
			Invalidate();
		}
		
		private void OnBeforeMoveNext( WizardMoveEventArgs e )
		{
			if( BeforeMoveNext != null )
				BeforeMoveNext( this, e );
		}

		private void OnAfterMoveNext( WizardMoveEventArgs e )
		{
			if( AfterMoveNext != null )
				AfterMoveNext( this, e );
		}

		private void OnPreviousClick(System.Object sender, System.EventArgs e)
		{
			int beforePageIndex = _currentItemIndex;
			int nextPageIndex = _currentItemIndex - 1;

			if( nextPageIndex < 0 ) 
			{
				return;
			}

			WizardMoveEventArgs moveEvent = new WizardMoveEventArgs(this.Pages[beforePageIndex], this.Pages[nextPageIndex]);
			OnBeforeMovePrevious( moveEvent );

			if( !moveEvent.Cancel )
			{
				if( this.Pages[beforePageIndex] != moveEvent.PreviousPage )
				{
					_currentItemIndex = this.Pages.IndexOf(moveEvent.PreviousPage);
				}
				else
				{
					_currentItemIndex--;
				}
//				_currentItemIndex -= 1;
				this.DisplayCurrentPage();
				OnAfterMovePrevious( moveEvent );
			}
			Invalidate();
		}
			
		private void OnBeforeMovePrevious( WizardMoveEventArgs e )
		{
			if( BeforeMovePrevious != null )
				BeforeMovePrevious( this, e );
		}

		private void OnAfterMovePrevious( WizardMoveEventArgs e )
		{
			if( AfterMovePrevious != null )
				AfterMovePrevious( this, e );
		}

		private void OnCancelClick(System.Object sender, System.EventArgs e)
		{
			if (CancelClick != null)
				CancelClick();
			Invalidate();
		}
			
		private void OnFinishClick(System.Object sender, System.EventArgs e)
		{
			if (FinishClick != null)
				FinishClick();
			Invalidate();
		}
			
		private void OnHelpClick(System.Object sender, System.EventArgs e)
		{
			if (HelpClick != null)
				HelpClick();
			Invalidate();
		}

		private void OnPreviousMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (DesignMode)
			{
				_next.Select();
				_previous.PerformClick();
			}
		}
			
		private void OnNextMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.DesignMode)
			{
				_next.Select();
				_next.PerformClick();
			}
		}
			
		private void OnNextMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (DesignMode)
			{
				_next.Select();
			}
			base.OnMouseDown(e);
		}
			
		private void OnPreviousMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (DesignMode)
			{
				_previous.Select();
			}
		}
			
		/// <summary>
		/// Displays The current page
		/// </summary>
		internal void DisplayCurrentPage()
		{
			try
			{
				CheckState();
					
				if( this.Pages.Count > 0 )
				{
					foreach( WizardPage tempPage in Pages )
					{
						// EmptyPage Page config
						if (tempPage.PageStyle == PageStyle.EmptyPage)
						{
							this._headerPanel.Visible = false;
							tempPage.Location = new Point(0, 0);
							tempPage.Size = new Size(Width, Height -(this.ButtonBar.Height));
							tempPage.BringToFront();
						}
						else
						{
							tempPage.Location = new Point(0, _headerPanel.Height);
							tempPage.Size = new Size(Width, Height -(_headerPanel.Height + this.ButtonBar.Height));
						}
							
						tempPage.Visible = System.Convert.ToBoolean(this._currentItemIndex == Pages.IndexOf(tempPage));
					}
						
					if (this.CurrentPage != null)
					{
						WizardPage page = this.CurrentPage;
						if (page.PageStyle == PageStyle.PageWithHeader)
						{
							this._headerPanel.Visible = true;
							_headerPanel.BringToFront();

							this._headerPanel.Title = page.HeaderCaption;
							this._headerPanel.TitleColor = page.HeaderColor;
							this._headerPanel.TitleFont = page.HeaderFont;
							this._headerPanel.SubTitle = page.SubHeaderCaption;
							this._headerPanel.SubTitleColor = page.SubHeaderColor;
							this._headerPanel.SubTitleFont = page.SubHeaderFont;
							
							this._headerPanel.RightToLeft = this.RightToLeft;
						}
						
						FocusPageControl();
					}
				}
				else
				{
					this._headerPanel.Visible = false;

					this._headerPanel.Title = String.Empty;
					this._headerPanel.SubTitle = String.Empty;
				}
			}
			catch (Exception)
			{
				
			}
		}
			
		private void FocusPageControl()
		{
			if (this.SelectedPage != null)
			{
				base.ActiveControl = null;
				this.SelectedPage.SelectNextControl(null, true, true, true, true);
				if (base.ActiveControl != null)
				{
					base.ActiveControl.Focus();
				}
				else if (this._next.Enabled)
				{
					this._next.Focus();
				}
			}
		}


		internal int InternalItemCount()
		{
			try
			{
				if (Pages != null)
				{
					return Pages.Count;
				}
				else
				{
					return 0;
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		/// <exclude></exclude>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Image BackgroundImage
		{
			get{ return base.BackgroundImage; }
			set{ /*base.BackgroundImage = value;*/ }
		}

		/// <summary>
		/// Set or Get text for next button  
		/// </summary>
		[Category("Buttons")]
		[Localizable(true)]
		public String ButtonNextText
		{
			get{ return this._next.Text; }
			set{ this._next.Text = value; }
		}

		/// <summary>
		/// Previous Button text
		/// </summary>
		[Category("Buttons")]
		[Localizable(true)]
		public String ButtonPreviosText
		{
			get{ return this._previous.Text; }
			set{ this._previous.Text = value; }
		}

		/// <summary>
		/// Set or Get text for cancel button  
		/// </summary>
		[Category("Buttons")]
		[Localizable(true)]
		public String ButtonCancelText
		{
			get{ return this._cancel.Text; }
			set{ this._cancel.Text = value; }
		}

		/// <summary>
		/// Set or Get text for finish button  
		/// </summary>
		[Category("Buttons")]
		[Localizable(true)]
		public String ButtonFinishText
		{
			get{ return this._finish.Text; }
			set{ this._finish.Text = value; }
		}
	
		/// <summary>
		/// Set or Get text for help button  
		/// </summary>
		[Category("Buttons")]
		[Localizable(true)]
		public String ButtonHelpText
		{
			get{ return this._help.Text; }
			set{ this._help.Text = value; }
		}
	}
		
		
}
	
	
	
	
