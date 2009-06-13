using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests
{
	public class TestSmartTagItem : SmartTagItem
	{
		public TestSmartTagItem(string name)
			: base(name)
		{
		}

		protected override void OnExecute()
		{
			CodeRush.Command.Execute("Test.RunTestsInCurrentContext");
		}
	}
}