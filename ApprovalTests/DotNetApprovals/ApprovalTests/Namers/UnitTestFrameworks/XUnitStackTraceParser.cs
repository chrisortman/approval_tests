namespace ApprovalTests.StackTraceParsers
{
	public class XUnitStackTraceParser : AttributeStackTraceParser
	{
		public override string ForTestingFramework
		{
			get { return "xUnit.net"; }
		}

		protected override string GetAttributeType()
		{
			return "Xunit.FactAttribute";
		}
	}
}