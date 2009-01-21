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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.checkBoxRunTestAfterApproval = new System.Windows.Forms.CheckBox();
			this.buttonApply = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Diff Tool:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(67, 10);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(285, 20);
			this.textBox1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(360, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "&Browse";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// checkBoxRunTestAfterApproval
			// 
			this.checkBoxRunTestAfterApproval.AutoSize = true;
			this.checkBoxRunTestAfterApproval.Location = new System.Drawing.Point(18, 54);
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
			// Options
			// 
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.checkBoxRunTestAfterApproval);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Options";
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
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBoxRunTestAfterApproval;
		private System.Windows.Forms.Button buttonApply;
	}
}