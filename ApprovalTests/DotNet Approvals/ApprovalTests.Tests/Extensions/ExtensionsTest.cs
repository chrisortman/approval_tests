using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ApprovalTests.Extensions;

namespace ApprovalTests.Tests.Extensions
{
	[TestFixture]
	public class ExtensionsTest
	{
		[Test]
		public void TestListToString()
		{
			string[] list = new[] { "one", "two", "three", "four" };

			Func<string,string> formatter = s => "{" +s+ "}";
			Approvals.Approve(list, formatter);
			list.ShouldBeApproved(formatter);
		}
		[Test]
		public void TestListSubobjects()
		{
			string[] list = new[] { "one", "two", "three", "four" };

			Func<string, string> formatter = s => "" + s.Length ;
			Approvals.Approve(list, formatter, "Number");
			list.ShouldBeApproved(formatter, "Number");
		}
	}
}
