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

namespace BitLaboratory.Windows.WizardFramework.Collection
{
	/// <summary>
	/// Holds All The WizardPage Details, And Handles All The Events
	/// </summary>
	[Designer("System.Windows.Forms.Design.ControlDesigner, System.Design", typeof(IDesigner)), Serializable()]
	public class WizardPageCollection : CollectionBase
	{
		/// <summary>
		/// Button is added
		/// </summary>
		internal event EventHandler Added;
		/// <summary>
		/// Button is changed
		/// </summary>
		internal event EventHandler Changed;
		/// <summary>
		/// Button is removed
		/// </summary>
		internal event EventHandler Removed;

		internal event ButtonStateChangedEventHandler ButtonStateChanged;

		/// <summary>
		/// Returns The Panelitem Relevant To The Index
		/// </summary>
		/// <param name="index">Page Index</param>
		/// <value>Return Wizard page for provided Index.</value>
		public WizardPage this[int index]
		{
			get{ return ((WizardPage) List[index]); }
			set
			{
				List[index] = value;
				OnChanged(this, new EventArgs());
			}
		}
		
		/// <summary>
		/// Initiates or Set A WizardPage And Adds It To The Collection
		/// </summary>
		/// <param name="value">Wizard page</param>
		/// <value></value>
		public int Add(WizardPage value)
		{
			int result = -1;
			try
			{
				result = List.Add(value);
				
				value.Changed += new EventHandler(OnChanged);
				value.ButtonStateChanged += new ButtonStateChangedEventHandler(OnButtonStateChanged);
				
				OnChanged(this, new EventArgs());
				OnAdded(value);
			}
			catch (Exception)
			{
				// Throw ex
			}
			
			return result;
			
		}
		
		/// <summary>
		/// Collection IndexOf Function
		/// </summary>
		/// <param name="value">Wizard page for whitch we need index.</param>
		/// <returns>Return index of Wizard Page.</returns>
		public int IndexOf(WizardPage value)
		{
			return List.IndexOf(value);
		}
		
		/// <summary>
		/// Collection Contains Function
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(WizardPage value)
		{
			return List.Contains(value);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		protected internal void OnAdded(object sender)
		{
			if (Added != null)
				Added(sender, EventArgs.Empty);
		}

		/// <summary>
		/// Button is changed
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event args</param>
		protected internal void OnChanged(object sender, EventArgs e)
		{
			if (Changed != null)
				Changed(sender, e);
		}

		/// <summary>
		/// Button is removed
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event args</param>
		protected internal void OnRemoved(object sender, EventArgs e)
		{
			if (Removed != null)
				Removed(sender, e);
			if (Changed != null)
				Changed(sender, e);
		}

		/// <summary>
		/// Button state is changed
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event args</param>
		protected internal void OnButtonStateChanged(object sender, ButtonStateEventArgs e)
		{
			if (ButtonStateChanged != null)
				ButtonStateChanged(sender, e);
		}
		
		/// <summary>
		/// Collection Insert Function
		/// </summary>
		/// <param name="index">Insert on Index</param>
		/// <param name="value">Wizard page to be inserted.</param>
		public void Insert(int index, WizardPage value)
		{
			List.Insert(index, value);
			OnChanged(this, new EventArgs());
		}
		
		/// <summary>
		/// Removes A PanelItem From The Collection
		/// </summary>
		/// <param name="value">Wizard page to be removed.</param>
		public void Remove(WizardPage value)
		{
			try
			{
				Control o = null;
				try
				{
					if (value != null)
					{
						value.Visible = false;
						o.Parent.Parent.Controls.Add(value);
					}
				}
				catch (Exception)
				{
					
				}
				
				OnRemoved(value, new EventArgs());
				List.Remove(value);
				value = null;
				
			}
			catch (Exception)
			{
				//Throw New Exception("No Item Selected", ex)
			}
		}
		
		/// <summary>
		/// Collection Insert Complete Event
		/// </summary>
		/// <param name="index">Inser is complete on index</param>
		/// <param name="value">Argument object</param>
		protected override void OnInsertComplete(int index, object value)
		{
			if (Added != null)
				Added(value, EventArgs.Empty);
		}
	}
	
}
