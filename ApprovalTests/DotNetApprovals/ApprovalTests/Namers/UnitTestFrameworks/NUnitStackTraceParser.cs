using System;

namespace ApprovalTests.StackTraceParsers
{
	public class NUnitStackTraceParser : AttributeStackTraceParser
	{
		protected override Type GetAttributeType()
		{
			return Type.GetType("NUnit.Framework.TestAttribute, NUnit.Framework", false);
		}
	}
}