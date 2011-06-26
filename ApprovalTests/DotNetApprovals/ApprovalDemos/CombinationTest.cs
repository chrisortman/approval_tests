using System;
using System.Linq;
using ApprovalTests.Reporters;
using NUnit.Framework;
using Approvals = ApprovalTests.Combinations.Approvals;

namespace ApprovalDemos.Data
{
	[TestFixture]
	[UseReporter(typeof(FileLauncherReporter))]
	public class CombinationTest
	{
	
		[Test]
		public void TestLambdas()
		{
			Approvals.ApproveAllCombinations((int a, int b, int c) =>average(a,b,c), Enumerable.Range(-10, 1000), new int[]{1,2,3,4,5,6,7},Enumerable.Range(-200, 50)  );
		}

		public double average(int a, int b, int c)
		{
			return (a + b + c)/3.0;
		}	
		[Test]
		public void TestSquareRoot()
		{
			Approvals.ApproveAllCombinations((int a) =>square(a), Enumerable.Range(Int32.MinValue, Int32.MaxValue)  );
		}

		public double square(int a)
		{
			return a*a;
		}
	}

}