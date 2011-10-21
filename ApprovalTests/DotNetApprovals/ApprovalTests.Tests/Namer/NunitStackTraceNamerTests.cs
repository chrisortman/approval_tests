using System;
using System.IO;
using ApprovalTests.Namers;
using NUnit.Framework;

namespace ApprovalTests.Tests.Namer
{
	[TestFixture]
    public class NunitStackTraceNamerTests
    {
		

		[Test]
		public void TestApprovalName()
        {
            string name = new UnitTestFrameworkNamer().Name;
            Assert.AreEqual("NunitStackTraceNamerTests.TestApprovalName", name);
        }

		[Test]
        public void TestSourcePath()
        {
            string name = new UnitTestFrameworkNamer().SourcePath;
						var path = name.ToLower() + "\\"+ this.GetType().Name+".cs";
						Assert.IsTrue(File.Exists(path), path + " does not exist");
				}

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The approval file should be based on the scenario name with outline")]
        [NUnit.Framework.TestCaseAttribute("Fred")]
        [NUnit.Framework.TestCaseAttribute("John")]
        public virtual void TestCaseAttributes(string caseName)
        {
            NamerFactory.AdditionalInformation = caseName;
            string name = new UnitTestFrameworkNamer().Name;
            Assert.AreEqual("NunitStackTraceNamerTests.TestCaseAttributes." + caseName, name);
        }
    }
}