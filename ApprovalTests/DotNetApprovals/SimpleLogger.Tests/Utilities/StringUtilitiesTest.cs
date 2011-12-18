using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalUtilities.Utilities;

namespace ApprovalUtilities.Tests.Utilities
{
	[TestClass]
	public class StringUtilitiesTest
	{
		[TestMethod]
		public void TestToReadableString()
		{ 
		Assert.AreEqual("[]",new int[0].ToReadableString());
		Assert.AreEqual("[1, 2, 3]",new int[]{1,2,3}.ToReadableString());
		}
	}
}
