using System;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
	[TestFixture]
	public class DiffReporterTest
	{
		private static void AssertLauncher(string approved, string received)
		{
			var reporter = new DiffReporter();

			LaunchArgs args = reporter.GetLaunchArguments(approved, received);

			try
			{
				Approvals.Approve(args.ToString());
			}
			catch (Exception ex)
			{
				reporter.Launch(args);
				throw;
			}
		}

		[Test]
		public void TestLaunchesTortoiseImage()
		{
			AssertLauncher("../../a.png", "../../b.png");
		}

		[Test]
		
		public void TestLaunchesTortoiseMerge()
		{
			AssertLauncher("../../a.txt", "../../b.txt");
		}
	}
}