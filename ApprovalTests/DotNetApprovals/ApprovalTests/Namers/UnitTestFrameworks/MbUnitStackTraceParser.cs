namespace ApprovalTests.StackTraceParsers
{
	public class MbUnitStackTraceParser : AttributeStackTraceParser
	{
		public override string ForTestingFramework
		{
			get { return "MbUnit"; }
		}

		protected override string GetAttributeType()
		{
			return "MbUnit.Framework.TestAttribute";
		}
	}
}