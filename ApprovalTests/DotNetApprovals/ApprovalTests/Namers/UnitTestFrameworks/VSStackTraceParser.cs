namespace ApprovalTests.StackTraceParsers
{
	public class VSStackTraceParser : AttributeStackTraceParser
	{
		public override string ForTestingFramework
		{
			get { return "MsTest"; }
		}

		protected override string GetAttributeType()
		{
			return "Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute";
		}
	}
}