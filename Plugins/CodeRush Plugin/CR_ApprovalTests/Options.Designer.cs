using System;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests
{
	partial class Options
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Options()
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxDiffTool = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.checkBoxRunTestAfterApproval = new System.Windows.Forms.CheckBox();
			this.buttonApply = new System.Windows.Forms.Button();
			this.labelUnitTestCommand = new System.Windows.Forms.Label();
			this.textBoxUnitTestCommand = new System.Windows.Forms.TextBox();
			this.textBoxImageTool = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Diff Text Tool:";
			// 
			// textBoxDiffTool
			// 
			this.textBoxDiffTool.Location = new System.Drawing.Point(95, 10);
			this.textBoxDiffTool.Name = "textBoxDiffTool";
			this.textBoxDiffTool.Size = new System.Drawing.Size(285, 20);
			this.textBoxDiffTool.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(388, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "&Browse";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// checkBoxRunTestAfterApproval
			// 
			this.checkBoxRunTestAfterApproval.AutoSize = true;
			this.checkBoxRunTestAfterApproval.Location = new System.Drawing.Point(9, 122);
			this.checkBoxRunTestAfterApproval.Name = "checkBoxRunTestAfterApproval";
			this.checkBoxRunTestAfterApproval.Size = new System.Drawing.Size(134, 17);
			this.checkBoxRunTestAfterApproval.TabIndex = 3;
			this.checkBoxRunTestAfterApproval.Text = "Run test after approval";
			this.checkBoxRunTestAfterApproval.UseVisualStyleBackColor = true;
			// 
			// buttonApply
			// 
			this.buttonApply.Location = new System.Drawing.Point(310, 343);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 4;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// labelUnitTestCommand
			// 
			this.labelUnitTestCommand.AutoSize = true;
			this.labelUnitTestCommand.Location = new System.Drawing.Point(9, 96);
			this.labelUnitTestCommand.Name = "labelUnitTestCommand";
			this.labelUnitTestCommand.Size = new System.Drawing.Size(103, 13);
			this.labelUnitTestCommand.TabIndex = 5;
			this.labelUnitTestCommand.Text = "Unit Test Command:";
			// 
			// textBoxUnitTestCommand
			// 
			this.textBoxUnitTestCommand.Location = new System.Drawing.Point(119, 96);
			this.textBoxUnitTestCommand.Name = "textBoxUnitTestCommand";
			this.textBoxUnitTestCommand.Size = new System.Drawing.Size(307, 20);
			this.textBoxUnitTestCommand.TabIndex = 6;
			// 
			// textBoxImageTool
			// 
			this.textBoxImageTool.Location = new System.Drawing.Point(95, 36);
			this.textBoxImageTool.Name = "textBoxImageTool";
			this.textBoxImageTool.Size = new System.Drawing.Size(285, 20);
			this.textBoxImageTool.TabIndex = 8;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(388, 34);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "&Browse";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Diff Image Tool:";
			// 
			// Options
			// 
			this.Controls.Add(this.textBoxImageTool);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxUnitTestCommand);
			this.Controls.Add(this.labelUnitTestCommand);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.checkBoxRunTestAfterApproval);
			this.Controls.Add(this.textBoxDiffTool);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Options";
			this.Load += new System.EventHandler(this.Options_Load);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		///
		/// Gets a DecoupledStorage instance for this options page.
		///
		public static DecoupledStorage Storage
		{
			get
			{
				return DevExpress.CodeRush.Core.CodeRush.Options.GetStorage(GetCategory(), GetPageName());
			}
		}
		///
		/// Returns the category of this options page.
		///
		public override string Category
		{
			get
			{
				return Options.GetCategory();
			}
		}
		///
		/// Returns the page name of this options page.
		///
		public override string PageName
		{
			get
			{
				return Options.GetPageName();
			}
		}
		///
		/// Returns the full path (Category + PageName) of this options page.
		///
		public static string FullPath
		{
			get
			{
				return GetCategory() + "\\" + GetPageName();
			}
		}

		///
		/// Displays the DXCore options dialog and selects this page.
		///
		public new static void Show()
		{
			DevExpress.CodeRush.Core.CodeRush.Command.Execute("Options", FullPath);
		}

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxDiffTool;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBoxRunTestAfterApproval;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Label labelUnitTestCommand;
		private System.Windows.Forms.TextBox textBoxUnitTestCommand;
		private System.Windows.Forms.TextBox textBoxImageTool;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
	}
}