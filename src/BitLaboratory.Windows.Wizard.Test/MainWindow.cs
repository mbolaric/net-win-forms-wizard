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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BitLaboratory.Windows.WizardFramework;

namespace WizardTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainWindow : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private BitLaboratory.Windows.WizardFramework.WizardPage wizardPage1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ProgressBar progressBar1;
		private BitLaboratory.Windows.WizardFramework.WizardPage _wizardPageProgress;
		private BitLaboratory.Windows.WizardFramework.WizardPage _wizardPageFalse;
		private BitLaboratory.Windows.WizardFramework.WizardPage _wizardPageTree;
		private BitLaboratory.Windows.WizardFramework.WizardPage _wizardPageTrue;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton _radioButtonYes;
		private System.Windows.Forms.RadioButton _radioButtonNo;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ListBox _listBoxHardware;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private WizardControl _wizard;

		public MainWindow()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.wizardPage1 = new BitLaboratory.Windows.WizardFramework.WizardPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._wizard = new BitLaboratory.Windows.WizardFramework.WizardControl();
            this._wizardPageFalse = new BitLaboratory.Windows.WizardFramework.WizardPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._wizardPageProgress = new BitLaboratory.Windows.WizardFramework.WizardPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this._wizardPageTree = new BitLaboratory.Windows.WizardFramework.WizardPage();
            this._radioButtonNo = new System.Windows.Forms.RadioButton();
            this._radioButtonYes = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this._wizardPageTrue = new BitLaboratory.Windows.WizardFramework.WizardPage();
            this._listBoxHardware = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.wizardPage1.SuspendLayout();
            this._wizard.SuspendLayout();
            this._wizardPageFalse.SuspendLayout();
            this._wizardPageProgress.SuspendLayout();
            this._wizardPageTree.SuspendLayout();
            this._wizardPageTrue.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardPage1
            // 
            this.wizardPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("wizardPage1.BackgroundImage")));
            this.wizardPage1.ButtonFinish.Allow = false;
            this.wizardPage1.ButtonHelp.Allow = false;
            this.wizardPage1.ButtonHelp.Visible = false;
            this.wizardPage1.Controls.Add(this.label5);
            this.wizardPage1.Controls.Add(this.label4);
            this.wizardPage1.Controls.Add(this.label3);
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.HeaderCaption = "Wizard Item";
            this.wizardPage1.HeaderColor = System.Drawing.Color.Black;
            this.wizardPage1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.wizardPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.PageStyle = BitLaboratory.Windows.WizardFramework.PageStyle.EmptyPage;
            this.wizardPage1.Size = new System.Drawing.Size(516, 358);
            this.wizardPage1.SubHeaderCaption = "Panel Item";
            this.wizardPage1.SubHeaderColor = System.Drawing.Color.Black;
            this.wizardPage1.SubHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.wizardPage1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(168, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "To continue click Next.";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(208, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "• Troubleshoot problems you may be having with your hardware.";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(208, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "• Install software to support hardware you add to your computer.";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(168, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "This wizard helps you:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(168, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Add Hardware Wizard";
            // 
            // _wizard
            // 
            this._wizard.BannerImage = ((System.Drawing.Image)(resources.GetObject("_wizard.BannerImage")));
            this._wizard.ButtonCancelText = "&Cancel";
            this._wizard.ButtonFinishText = "&Finish";
            this._wizard.ButtonHelpText = "&Help";
            this._wizard.ButtonNextText = "&Next";
            this._wizard.ButtonPreviosText = "&Previous";
            this._wizard.Controls.Add(this._wizardPageFalse);
            this._wizard.Controls.Add(this.wizardPage1);
            this._wizard.Controls.Add(this._wizardPageProgress);
            this._wizard.Controls.Add(this._wizardPageTree);
            this._wizard.Controls.Add(this._wizardPageTrue);
            this._wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this._wizard.Location = new System.Drawing.Point(0, 0);
            this._wizard.Name = "_wizard";
            this._wizard.Pages.Add(this.wizardPage1);
            this._wizard.Pages.Add(this._wizardPageProgress);
            this._wizard.Pages.Add(this._wizardPageTree);
            this._wizard.Pages.Add(this._wizardPageTrue);
            this._wizard.Pages.Add(this._wizardPageFalse);
            this._wizard.Size = new System.Drawing.Size(516, 398);
            this._wizard.StartItemIndex = 0;
            this._wizard.TabIndex = 0;
            this._wizard.BeforeMoveNext += new BitLaboratory.Windows.WizardFramework.WizardMoveEventHandler(this._wizard_OnBeforeMoveNext);
            this._wizard.BeforeMovePrevious += new BitLaboratory.Windows.WizardFramework.WizardMoveEventHandler(this._wizard_BeforeMovePrevious);
            this._wizard.CancelClick += new BitLaboratory.Windows.WizardFramework.WizardControl.WizardEventHandler(this._wizard_CancelClick);
            this._wizard.FinishClick += new BitLaboratory.Windows.WizardFramework.WizardControl.WizardEventHandler(this._wizard_FinishClick);
            this._wizard.Load += new System.EventHandler(this.OnWizard_Load);
            // 
            // _wizardPageFalse
            // 
            this._wizardPageFalse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_wizardPageFalse.BackgroundImage")));
            this._wizardPageFalse.ButtonHelp.Allow = false;
            this._wizardPageFalse.ButtonHelp.Visible = false;
            this._wizardPageFalse.Controls.Add(this.label15);
            this._wizardPageFalse.Controls.Add(this.label14);
            this._wizardPageFalse.Controls.Add(this.label13);
            this._wizardPageFalse.Controls.Add(this.checkBox1);
            this._wizardPageFalse.Controls.Add(this.label12);
            this._wizardPageFalse.Controls.Add(this.label11);
            this._wizardPageFalse.HeaderCaption = "Wizard Item False";
            this._wizardPageFalse.HeaderColor = System.Drawing.Color.White;
            this._wizardPageFalse.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this._wizardPageFalse.Location = new System.Drawing.Point(0, 0);
            this._wizardPageFalse.Name = "_wizardPageFalse";
            this._wizardPageFalse.PageStyle = BitLaboratory.Windows.WizardFramework.PageStyle.EmptyPage;
            this._wizardPageFalse.Size = new System.Drawing.Size(516, 358);
            this._wizardPageFalse.SubHeaderCaption = "Panel Item";
            this._wizardPageFalse.SubHeaderColor = System.Drawing.Color.White;
            this._wizardPageFalse.SubHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._wizardPageFalse.TabIndex = 7;
            this._wizardPageFalse.Text = "New Tab Item 3";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(168, 336);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(224, 16);
            this.label15.TabIndex = 5;
            this.label15.Text = "To close this wizard, click Finish.";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(168, 264);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(328, 40);
            this.label14.TabIndex = 4;
            this.label14.Text = "To start a troubleshooter that can help you resolve any problems you might be hav" +
    "ing, click Finish.";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(168, 192);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(328, 56);
            this.label13.TabIndex = 3;
            this.label13.Text = "In most cases Windows will automatically install your hardware after you connect " +
    "it. If Windows does not find it, you can reopen this wizard to install the suppo" +
    "rting software.";
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(168, 120);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(328, 32);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Turn off the computer when I click Finish so that I can open the computer and con" +
    "nect the hardware.";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(168, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(336, 40);
            this.label12.TabIndex = 1;
            this.label12.Text = "Completing the Sample Wizard";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(168, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(280, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "You have successfully completed the Sample Wizard.";
            // 
            // _wizardPageProgress
            // 
            this._wizardPageProgress.ButtonFinish.Allow = false;
            this._wizardPageProgress.ButtonHelp.Allow = false;
            this._wizardPageProgress.ButtonHelp.Visible = false;
            this._wizardPageProgress.Controls.Add(this.progressBar1);
            this._wizardPageProgress.Controls.Add(this.label6);
            this._wizardPageProgress.HeaderCaption = "Wizard Item";
            this._wizardPageProgress.HeaderColor = System.Drawing.Color.White;
            this._wizardPageProgress.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this._wizardPageProgress.Location = new System.Drawing.Point(0, 56);
            this._wizardPageProgress.Name = "_wizardPageProgress";
            this._wizardPageProgress.PageStyle = BitLaboratory.Windows.WizardFramework.PageStyle.PageWithHeader;
            this._wizardPageProgress.Size = new System.Drawing.Size(516, 302);
            this._wizardPageProgress.SubHeaderCaption = "Panel Item";
            this._wizardPageProgress.SubHeaderColor = System.Drawing.Color.White;
            this._wizardPageProgress.SubHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._wizardPageProgress.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(74, 120);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(368, 16);
            this.progressBar1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(40, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(432, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "This wizard is searching for hardware that has been connected to your computer re" +
    "cently but has not yet been installed.";
            // 
            // _wizardPageTree
            // 
            this._wizardPageTree.ButtonFinish.Allow = false;
            this._wizardPageTree.ButtonHelp.Allow = false;
            this._wizardPageTree.ButtonHelp.Visible = false;
            this._wizardPageTree.ButtonMoveNext.Allow = false;
            this._wizardPageTree.Controls.Add(this._radioButtonNo);
            this._wizardPageTree.Controls.Add(this._radioButtonYes);
            this._wizardPageTree.Controls.Add(this.label7);
            this._wizardPageTree.HeaderCaption = "Wizard Item Tree";
            this._wizardPageTree.HeaderColor = System.Drawing.Color.White;
            this._wizardPageTree.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this._wizardPageTree.Location = new System.Drawing.Point(0, 56);
            this._wizardPageTree.Name = "_wizardPageTree";
            this._wizardPageTree.PageStyle = BitLaboratory.Windows.WizardFramework.PageStyle.PageWithHeader;
            this._wizardPageTree.Size = new System.Drawing.Size(516, 302);
            this._wizardPageTree.SubHeaderCaption = "Panel Item";
            this._wizardPageTree.SubHeaderColor = System.Drawing.Color.White;
            this._wizardPageTree.SubHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._wizardPageTree.TabIndex = 4;
            this._wizardPageTree.Text = "New Tab Item 1";
            // 
            // _radioButtonNo
            // 
            this._radioButtonNo.Location = new System.Drawing.Point(72, 88);
            this._radioButtonNo.Name = "_radioButtonNo";
            this._radioButtonNo.Size = new System.Drawing.Size(272, 24);
            this._radioButtonNo.TabIndex = 2;
            this._radioButtonNo.Text = "No, I have not added the hardware yet";
            this._radioButtonNo.CheckedChanged += new System.EventHandler(this._radioButtonYes_CheckedChanged);
            // 
            // _radioButtonYes
            // 
            this._radioButtonYes.Location = new System.Drawing.Point(72, 56);
            this._radioButtonYes.Name = "_radioButtonYes";
            this._radioButtonYes.Size = new System.Drawing.Size(272, 24);
            this._radioButtonYes.TabIndex = 1;
            this._radioButtonYes.Text = "Yes, I have already connected the hardware";
            this._radioButtonYes.CheckedChanged += new System.EventHandler(this._radioButtonYes_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(32, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(456, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Have you already connected this hardware to your computer?";
            // 
            // _wizardPageTrue
            // 
            this._wizardPageTrue.ButtonFinish.Allow = false;
            this._wizardPageTrue.ButtonHelp.Allow = false;
            this._wizardPageTrue.ButtonHelp.Visible = false;
            this._wizardPageTrue.Controls.Add(this._listBoxHardware);
            this._wizardPageTrue.Controls.Add(this.label10);
            this._wizardPageTrue.Controls.Add(this.label9);
            this._wizardPageTrue.Controls.Add(this.label8);
            this._wizardPageTrue.HeaderCaption = "Wizard Item True";
            this._wizardPageTrue.HeaderColor = System.Drawing.Color.White;
            this._wizardPageTrue.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this._wizardPageTrue.Location = new System.Drawing.Point(0, 56);
            this._wizardPageTrue.Name = "_wizardPageTrue";
            this._wizardPageTrue.PageStyle = BitLaboratory.Windows.WizardFramework.PageStyle.PageWithHeader;
            this._wizardPageTrue.Size = new System.Drawing.Size(516, 302);
            this._wizardPageTrue.SubHeaderCaption = "Panel Item";
            this._wizardPageTrue.SubHeaderColor = System.Drawing.Color.White;
            this._wizardPageTrue.SubHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._wizardPageTrue.TabIndex = 6;
            this._wizardPageTrue.Text = "New Tab Item 2";
            // 
            // _listBoxHardware
            // 
            this._listBoxHardware.Location = new System.Drawing.Point(32, 160);
            this._listBoxHardware.Name = "_listBoxHardware";
            this._listBoxHardware.Size = new System.Drawing.Size(456, 134);
            this._listBoxHardware.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(32, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Installed hardware:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(40, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(440, 23);
            this.label9.TabIndex = 1;
            this.label9.Text = "To add hardware not shown in the list, click \"Add a new hardware device.\"";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(40, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(440, 40);
            this.label8.TabIndex = 0;
            this.label8.Text = "From the list below, select an installed hardware device, then click Next to chec" +
    "k properties or troubleshoot a problem you might be having.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            // 
            // MainWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(516, 398);
            this.Controls.Add(this._wizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Main Window";
            this.wizardPage1.ResumeLayout(false);
            this._wizard.ResumeLayout(false);
            this._wizardPageFalse.ResumeLayout(false);
            this._wizardPageProgress.ResumeLayout(false);
            this._wizardPageTree.ResumeLayout(false);
            this._wizardPageTrue.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new MainWindow());
		}

		private void _wizard_OnBeforeMoveNext(object sender, WizardMoveEventArgs e)
		{
			if( e.PreviousPage == _wizardPageTree )
			{
				if( !_radioButtonYes.Checked && !_radioButtonNo.Checked )
				{
					
				}
				else
				{
					if( _radioButtonNo.Checked )
						e.NextPage = _wizardPageFalse;
				}
			}
		}

		private void _wizard_CancelClick()
		{
			this.Close();
		}

		private void _wizard_BeforeMovePrevious(object sender, BitLaboratory.Windows.WizardFramework.WizardMoveEventArgs e)
		{
			if( e.PreviousPage == _wizardPageFalse )
			{
				if( _radioButtonNo.Checked )
					e.PreviousPage = _wizardPageTree;
			}
		}

		private void _radioButtonYes_CheckedChanged(object sender, System.EventArgs e)
		{
			_wizardPageTree.ButtonMoveNext.Allow = _radioButtonNo.Checked || _radioButtonYes.Checked;
		}

		private void _wizard_FinishClick()
		{
			this.Close();
		}

        private void OnWizard_Load(object sender, EventArgs e)
        {

        }
    }
}
