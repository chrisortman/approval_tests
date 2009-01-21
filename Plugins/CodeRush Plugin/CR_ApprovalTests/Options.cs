using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests
{
	[UserLevel(UserLevel.NewUser)]
	public partial class Options : OptionsPage
	{
		public static string GetCategory()
		{
			return @"Approval Tests";
		}
		
		public static string GetPageName()
		{
			return @"Tools";
		}

		private ApprovalToolsSettings settings = ApprovalTestsPlugIn.Settings;

		private void UpdateData()
		{
			settings.RunTestAfterApproval = checkBoxRunTestAfterApproval.Checked;
			settings.UnitTestCommand = textBoxUnitTestCommand.Text;
			settings.DiffTextTool = textBoxDiffTool.Text;
			settings.DiffImageTool = textBoxImageTool.Text;
		}

		public void UpdateScreen(ApprovalToolsSettings settings)
		{
			if (settings == null) return;

			checkBoxRunTestAfterApproval.Checked = settings.RunTestAfterApproval;
            textBoxUnitTestCommand.Text = settings.UnitTestCommand;
			textBoxDiffTool.Text = settings.DiffTextTool;
			textBoxImageTool.Text = settings.DiffImageTool;
		}

		private void UpdateScreen()
		{
			UpdateScreen(settings);
		}

		private void buttonApply_Click(object sender, System.EventArgs e)
		{
			UpdateData();
			ApprovalTestsPlugIn.Settings = settings;
		}

		protected override void Initialize()
		{
			base.Initialize();
            UpdateScreen();
		}

		private void Options_Load(object sender, System.EventArgs e)
		{

		}
	}
}