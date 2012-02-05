using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
	[TestFixture]
	public class GenericDiffReporterTest
	{
		[Test]
		public void TestProgramsExist()
		{
			Assert.IsFalse(new GenericDiffReporter("this_should_never_exist", "").IsWorkingInThisEnvironment());
		}
		[Test]
		public void TestLaunchesBeyondCompareImage()
		{
			AssertLauncher("../../a.png", "../../b.png", new BeyondCompareReporter());
		}
		[Test]
		public void TestWinMerge()
		{
			AssertLauncher("../../a.txt", "../../b.txt", new WinMergeReporter());
		}
		[Test]
		public void TestLaunchesTortoiseMerge()
		{
			AssertLauncher("../../a.txt", "../../b.txt", new TortoiseDiffReporter());
		}
		[Test]
		public void TestLaunchesTortoiseImage()
		{
			AssertLauncher("../../a.png", "../../b.png", new TortoiseImageDiffReporter());
		}

		private static void AssertLauncher(string approved, string received, GenericDiffReporter reporter)
		{
			var args = reporter.GetLaunchArguments(approved, received);

			try
			{
				Approvals.Verify(args.ToString());
			}
			catch
			{
				DiffReporter.Launch(args);
				throw;
			}
		}
	}
}