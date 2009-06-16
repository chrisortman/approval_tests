using System;
using System.IO;
using ApprovalTests.Namers;
using NUnit.Framework;

namespace ApprovalTests.Tests.Namer
{
	[TestFixture]
    public class NunitStackTraceNamerTests
    {
		public static string DirectoryThisSourceFileIsIn
		{
			get
			{
				string basePath = String.Format(@"{0}\..\..\..\namer", System.Reflection.Assembly.GetExecutingAssembly().Location);
				string pathGetFullPathToLower = Path.GetFullPath(basePath).ToLower();
				return pathGetFullPathToLower;
			}
		}

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
            Assert.AreEqual(DirectoryThisSourceFileIsIn, name.ToLower());
        }
    }
}