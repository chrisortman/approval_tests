using System;
using System.Linq;
using System.Text;
using ApprovalTests.Reporters;
using NUnit.Framework;
using Approvals = ApprovalTests.Combinations.Approvals;
using ApprovalUtilities.Utilities;

namespace ApprovalDemos.Data
{
	[TestFixture]
	[UseReporter(typeof(DiffReporter))]
	public class CombinationTest
	{
	 
		[Test]
		public void TestMultiplyAndAdd()
		{
			var range = Enumerable.Range(1,10);
			Approvals.ApproveAllCombinations((a,b,c) => MultiplyAndAdd(a,b,c), range, range,range);
		}

		public double MultiplyAndAdd(int a, int b, int c)
		{
			return a*b + c;
		}
	}

}