namespace CR_ApprovalTests
{
	partial class ApprovalTestsPlugin
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public ApprovalTestsPlugin()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApprovalTestsPlugin));
			this.ApprovalTestsProvider = new DevExpress.CodeRush.Core.SmartTagProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ApprovalTestsProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// ApprovalTestsProvider
			// 
			this.ApprovalTestsProvider.Description = "Approvals";
			this.ApprovalTestsProvider.Image = ((System.Drawing.Bitmap)(resources.GetObject("ApprovalTestsProvider.Image")));
			this.ApprovalTestsProvider.ImageBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(254)))), ((int)(((byte)(0)))));
			this.ApprovalTestsProvider.MenuOrder = 0;
			this.ApprovalTestsProvider.ProviderName = "Approvals";
			this.ApprovalTestsProvider.Register = true;
			this.ApprovalTestsProvider.ShowInContextMenu = false;
			this.ApprovalTestsProvider.ShowInPopupMenu = true;
			this.ApprovalTestsProvider.GetSmartTagItemColors += new DevExpress.CodeRush.Core.GetSmartTagItemColorsEventHandler(this.ApprovalTestsProvider_GetSmartTagItemColors);
			this.ApprovalTestsProvider.CheckSmartTagAvailability += new DevExpress.CodeRush.Core.CheckSmartTagAvailabilityEventHandler(this.ApprovalTestsProvider_CheckSmartTagAvailability);
			this.ApprovalTestsProvider.GetSmartTagItems += new DevExpress.CodeRush.Core.GetSmartTagItemsEventHandler(this.ApprovalTestsProvider_GetSmartTagItems);
			// 
			// ApprovalTestsPlugin
			// 
			this.EditorPaintLanguageElement += new DevExpress.CodeRush.Core.EditorPaintLanguageElementEventHandler(this.ApprovalTestsPlugin_EditorPaintLanguageElement);
			((System.ComponentModel.ISupportInitialize)(this.ApprovalTestsProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		public DevExpress.CodeRush.Core.SmartTagProvider ApprovalTestsProvider;

	}
}