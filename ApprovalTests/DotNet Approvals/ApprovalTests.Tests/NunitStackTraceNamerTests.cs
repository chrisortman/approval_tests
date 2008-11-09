using System;
using System.Diagnostics;
using System.IO;
using ApprovalTests.StackTraceParsers;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
	[TestFixture]
	public class NunitStackTraceNamerTests
	{
		[Test]
		public void TestApprovalName()
		{
			string name = new StackTraceNamer().Name;
			Assert.AreEqual("NunitStackTraceNamerTests.TestApprovalName", name);
		}


		[Test]
		public void TestSourcePath()
		{
			string name = new StackTraceNamer().SourcePath;
			var basePath = Environment.CurrentDirectory + @"\..\..";
			Assert.AreEqual(Path.GetFullPath(basePath).ToLower(), name.ToLower());
		}
	}
}