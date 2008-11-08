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
	}
}