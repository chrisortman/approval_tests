using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ApprovalTests.StackTraceParsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApprovalTests.Tests
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
			var basePath = Environment.CurrentDirectory + @"\..\..";
			Assert.AreEqual(Path.GetFullPath(basePath).ToLower(), name.ToLower());
		}
	}
}