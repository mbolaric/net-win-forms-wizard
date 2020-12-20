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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms.Design;
//using System.ComponentModel.Design.DesignerVerbCollection;
using BitLaboratory.Windows.WizardFramework;


namespace BitLaboratory.Windows.WizardFramework.Design
{
	/// <summary>
	/// Designer for the Wizard Control
	/// </summary>
	internal class WizardControlDesigner : ParentControlDesigner
	{	
		private WizardControl _wizardControl = null;
		private DesignerVerbCollection _verbs = null;
		private bool _compSelectedOld;
		
		
		public WizardControlDesigner()
		{
			_verbs = new DesignerVerbCollection();
		}
		
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			try
			{
				ISelectionService service = (ISelectionService) base.GetService(typeof(ISelectionService));
				service.SelectionChanged += new System.EventHandler(OnServiceSelectionChange);
				
				_wizardControl = (WizardControl) component;
				
				Verbs.Add(new DesignerVerb(string.Concat("&Add empty Page"), new System.EventHandler(OnAddCommandEmptyPage)));
				Verbs.Add(new DesignerVerb(string.Concat("&Add Page with Header"), new System.EventHandler(OnAddCommandWithHeaderPage)));
				Verbs.Add(new DesignerVerb(string.Concat("&Remove selected Page"), new System.EventHandler(OnRemoveCommand)));
			}
			catch (Exception)
			{
				
			}
		}
		
		
		/// <summary>
		/// Here we are checking to see the mous position of the control at design time
		/// </summary>
		/// <param name="point">Point need to be tested</param>
		/// <returns>Return true if Point is inside of ButtonBar</returns>
		protected override bool GetHitTest(Point point)
		{
			Button button = (Button) _wizardControl.ButtonBar.GetChildAtPoint(_wizardControl.ButtonBar.PointToClient(point));
            return button != null;
        }

        private void OnServiceSelectionChange(object sender, EventArgs e)
		{
			try
			{
				ISelectionService service = (ISelectionService) base.GetService(typeof(ISelectionService));
				bool compSelected = false;
				
				if (service == null)
				{
					return;
				}
				
				foreach (WizardPage item in _wizardControl.Pages)
				{
					if (service.GetComponentSelected(item))
					{
						compSelected = true;
					}
				}
				
				if ((!(compSelected == _compSelectedOld)) || compSelected)
				{				
					_compSelectedOld = compSelected;
					_wizardControl.Invalidate();
				}
				
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		
		/// <summary>
		/// Adds An EmptyPage Page To The Wizard
		/// </summary>
		/// <param name="sender">Sender Object</param>
		/// <param name="e">Additional event data</param>
		private void OnAddCommandEmptyPage(object sender, EventArgs e)
		{
			try
			{
				IDesignerHost host = (IDesignerHost) base.GetService(typeof(IDesignerHost));
				IComponentChangeService service = (IComponentChangeService) base.GetService(typeof(IComponentChangeService));
				DesignerTransaction transaction = host.CreateTransaction("Add Item");
				service.OnComponentChanging(_wizardControl, null);
				WizardPage item = (WizardPage) host.CreateComponent(typeof(WizardPage));
				string name = "New Tab Item ";
				int i = 1;
				while (ContainsWizardPage(name + i.ToString()))
				{
					System.Math.Min(System.Threading.Interlocked.Increment(ref i), i - 1);
				}
				
				item.PageStyle = PageStyle.EmptyPage;
				item.Text = name + i.ToString();
				_wizardControl.Pages.Add(item);
				service.OnComponentChanged(_wizardControl, null, null, null);
				transaction.Commit();
				_wizardControl.Invalidate(true);
				_wizardControl.UpdateDesignTimeComponents();
				
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		/// <summary>
		/// Chages The selected page style
		/// </summary>
		/// <param name="sender">Sender Object</param>
		/// <param name="e">Additional event data</param>
		private void OnChangePageType(object sender, EventArgs e)
		{
			try
			{
				IDesignerHost host = (IDesignerHost) base.GetService(typeof(IDesignerHost));
				IComponentChangeService service = (IComponentChangeService) base.GetService(typeof(IComponentChangeService));
				DesignerTransaction transaction = host.CreateTransaction("Add Item");
				
				WizardPage page = _wizardControl.CurrentPage;
				
				if (page != null)
				{
					service.OnComponentChanging(_wizardControl.CurrentPage, null);
					
					if (page.PageStyle == PageStyle.EmptyPage)
					{
						page.PageStyle = PageStyle.PageWithHeader;
					}
					else
					{
						page.PageStyle = PageStyle.EmptyPage;
					}
					
					service.OnComponentChanged(_wizardControl.CurrentPage, null, null, null);
					transaction.Commit();
					_wizardControl.CurrentPage.Invalidate(true);
				}
				
				_wizardControl.Invalidate(true);
				_wizardControl.UpdateDesignTimeComponents();
			}
			catch (Exception ex)
			{
				if (_wizardControl.Pages.Count > 0)
				{
					MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("There are no Pages to change!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		/// <summary>
		/// Adds An PageWithHeader Page to The Wizard
		/// </summary>
		/// <param name="sender">Sender Object</param>
		/// <param name="e">Additional event data</param>
		private void OnAddCommandWithHeaderPage(object sender, EventArgs e)
		{
			try
			{
				IDesignerHost host = (IDesignerHost) base.GetService(typeof(IDesignerHost));
				IComponentChangeService service = (IComponentChangeService) base.GetService(typeof(IComponentChangeService));
				DesignerTransaction transaction = host.CreateTransaction("Add Item");
				service.OnComponentChanging(_wizardControl, null);
				
				WizardPage page = (WizardPage) host.CreateComponent(typeof(WizardPage));
				
				string name = "New Tab Item ";
				
				int i = 1;
				while (ContainsWizardPage(name + i.ToString()))
				{
					System.Math.Min(System.Threading.Interlocked.Increment(ref i), i - 1);
				}
				
				page.Text = name + i.ToString();
				_wizardControl.Pages.Add(page);
				service.OnComponentChanged(_wizardControl, null, null, null);
				transaction.Commit();
				_wizardControl.Invalidate(true);
				_wizardControl.UpdateDesignTimeComponents();
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		/// <summary>
		/// Checks To See If the Page Aready Exists
		/// </summary>
		/// <param name="name">Name of Wizard Page.</param>
		/// <returns>Return if wizard contain Page with provided name.</returns>
		public bool ContainsWizardPage(string name)
		{
			if (_wizardControl == null)
			{
				return false;
			}

			foreach (WizardPage tab in _wizardControl.Pages)
			{
				if (tab.Text == name)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Removes A Page From The Wizard
		/// </summary>
		/// <param name="sender">Sender Object</param>
		/// <param name="e">Additional event data</param>
		internal void OnRemoveCommand(object sender, EventArgs e)
		{
			try
			{
				IDesignerHost host = (IDesignerHost) base.GetService(typeof(IDesignerHost));
				IComponentChangeService service = (IComponentChangeService) base.GetService(typeof(IComponentChangeService));
				ISelectionService selService = (ISelectionService) base.GetService(typeof(ISelectionService));
				WizardPage selected = _wizardControl.SelectedPage;
				
				if (selected == null)
				{
					MessageBox.Show("WizardTemplate: OnRemoveCommand: Nothing");
					return;
				}
				
				DesignerTransaction transaction = host.CreateTransaction("Delete Item");
				service.OnComponentChanging(_wizardControl, null);
				_wizardControl.Pages.Remove(selected);
				host.DestroyComponent(selected);
				service.OnComponentChanged(_wizardControl, null, null, null);
				transaction.Commit();
				
				if (_wizardControl.Pages.Count > 0)
				{
					_wizardControl.DisplayCurrentPage();
				}
				
			}
			catch (Exception ex)
			{
				if (_wizardControl.Pages.Count > 0)
				{
					MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("There are no Pages to remove!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				
			}
			
		}

		/// <summary>
		/// Gets the collection of components associated with the component managed by the designer.
		/// </summary>
		/// <returns>
		/// The components that are associated with the component managed by the designer.
		/// </returns>
		public override ICollection AssociatedComponents
		{
			get
			{
				return _wizardControl.Pages;
			}
		}

		/// <summary>
		/// >Gets the design-time verbs supported by the component that is associated with the designer.
		/// </summary>
		public override DesignerVerbCollection Verbs
		{
			get
			{
				try
				{
					if (_wizardControl.InternalItemCount() == 0)
					{
						_verbs[2].Enabled = false;
						_verbs[3].Enabled = false;
					}
					else
					{
						_verbs[3].Enabled = true;
						_verbs[2].Enabled = true;
					}
				}
				catch (Exception)
				{
					
				}
				
				return _verbs;
			}
		}
	}
}
