namespace ApprovalTests.StackTraceParsers
{
	public class NUnitStackTraceParser : AttributeStackTraceParser
	{
		public override string ForTestingFramework
		{
			get { return "NUnit"; }
		}

		protected override string GetAttributeType()
		{
			return "NUnit.Framework.TestAttribute";
		}
	}
}