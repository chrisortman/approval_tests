using System;
using System.IO;
using ApprovalTests.Namers;
using ApprovalTests.StackTraceParsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApprovalTests.Tests.Namer
{
	[TestClass]
	public class VsTestStackTraceNamerTests
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

		[TestMethod]
		public void TestApprovalName()
		{
			string name = new UnitTestFrameworkNamer().Name;
			Assert.AreEqual("VsTestStackTraceNamerTests.TestApprovalName", name);
		}

		[TestMethod]
		public void TestSourcePath()
		{
			string name = new UnitTestFrameworkNamer().SourcePath;
			Assert.AreEqual(DirectoryThisSourceFileIsIn, name.ToLower());
		}

		[TestMethod]
		public void TestMSTestAware()
		{
			Assert.IsTrue(new VSStackTraceParser().IsApplicable());
		}
	}
}