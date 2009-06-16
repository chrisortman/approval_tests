using System;

namespace ApprovalTests.StackTraceParsers
{
	public class MbUnitStackTraceParser : AttributeStackTraceParser
	{
		protected override Type GetAttributeType()
		{
			return Type.GetType("MbUnit.Framework.TestAttribute, MbUnit", false);
		}
	}
}