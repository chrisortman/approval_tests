using System;

namespace ApprovalTests.StackTraceParsers
{
    public class VSStackTraceParser : AttributeStackTraceParser
    {
        protected override Type GetAttributeType()
        {
            return Type.GetType("Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute, Microsoft.VisualStudio.QualityTools.UnitTestFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false);
        }
    }
}