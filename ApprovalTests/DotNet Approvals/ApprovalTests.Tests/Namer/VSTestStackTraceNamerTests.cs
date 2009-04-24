using ApprovalTests.StackTraceParsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApprovalTests.Tests.Namer
{
    [TestClass]
    public class VSTestStackTraceNamerTests
    {
        [TestMethod]
        public void TestApprovalName()
        {
            string name = new StackTraceNamer().Name;
            Assert.AreEqual("VSTestStackTraceNamerTests.TestApprovalName", name);
        }


        [TestMethod]
        public void TestSourcePath()
        {
            string name = new StackTraceNamer().SourcePath;
            Assert.AreEqual(NunitStackTraceNamerTests.GetPathGetFullPathToLower(), name.ToLower());
        }

        [TestMethod]
        public void TestMSTestAware()
        {
            Assert.IsTrue(new VSStackTraceParser().IsApplicable());
        }
    }
}