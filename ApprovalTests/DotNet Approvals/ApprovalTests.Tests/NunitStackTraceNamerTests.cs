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
		public void TestGetApprovalName()
		{
			string name = new StackTraceNamer().GetApprovalName();
			Assert.AreEqual("NunitStackTraceNamerTests.TestGetApprovalName", name);
		}


		[Test]
		public void TestGetSourceFilePath()
		{
			string name = new StackTraceNamer().GetSourceFilePath();
			Debug.Write(name);
			var basePath = Environment.CurrentDirectory + @"\..\..\";
			Assert.AreEqual(Path.GetFullPath(basePath), name);
		}
	}
}