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
		}

		public void UpdateScreen(ApprovalToolsSettings settings)
		{
			checkBoxRunTestAfterApproval.Checked = settings.RunTestAfterApproval;
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
	}
}