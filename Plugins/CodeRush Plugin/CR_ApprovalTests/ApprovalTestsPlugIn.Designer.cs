using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests
{
	partial class ApprovalTestsPlugIn
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public ApprovalTestsPlugIn()
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApprovalTestsPlugIn));
			this.codeProviderApprovals = new DevExpress.CodeRush.Core.CodeProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.codeProviderApprovals)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// codeProviderApprovals
			// 
			this.codeProviderApprovals.ActionHintText = "";
			this.codeProviderApprovals.AutoActivate = true;
			this.codeProviderApprovals.AutoUndo = false;
			this.codeProviderApprovals.Description = "";
			this.codeProviderApprovals.DisplayName = "Approvals";
			this.codeProviderApprovals.Image = ((System.Drawing.Bitmap)(resources.GetObject("codeProviderApprovals.Image")));
			this.codeProviderApprovals.ImageBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(254)))), ((int)(((byte)(0)))));
			this.codeProviderApprovals.NeedsSelection = false;
			this.codeProviderApprovals.ProviderName = "Approvals";
			this.codeProviderApprovals.Register = true;
			this.codeProviderApprovals.SupportsAsyncMode = false;
			this.codeProviderApprovals.CheckAvailability += new DevExpress.Refactor.Core.CheckAvailabilityEventHandler(this.codeProviderApprovals_CheckAvailability);
			// 
			// ApprovalTestsPlugIn
			// 
			this.EditorPaintLanguageElement += new DevExpress.CodeRush.Core.EditorPaintLanguageElementEventHandler(this.PlugIn1_EditorPaintLanguageElement);
			((System.ComponentModel.ISupportInitialize)(this.codeProviderApprovals)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private CodeProvider codeProviderApprovals;





	}
}