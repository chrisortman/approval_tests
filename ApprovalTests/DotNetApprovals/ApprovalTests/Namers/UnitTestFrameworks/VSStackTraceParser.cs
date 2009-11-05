using System;

namespace ApprovalTests.StackTraceParsers
{
	public class VSStackTraceParser : AttributeStackTraceParser
	{
		protected override Type GetAttributeType()
		{
			return
				Type.GetType(
					"Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute, Microsoft.VisualStudio.QualityTools.UnitTestFramework",
					false);
		}
	}
}