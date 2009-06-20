using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.SmartTagItems
{
	public class RunTestItem : SmartTagItem
	{
		public RunTestItem(string name) : base(name)
		{
		}

        public RunTestItem()
        {
            
        }
         
		protected override void OnExecute()
		{
			CodeRush.Command.Execute("Test.RunTestsInCurrentContext");
		}
	}
}