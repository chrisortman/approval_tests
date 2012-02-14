using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
	[TestFixture]
	public class FirstWorkingReporterTest
	{
		[Test]
		public void TestCallsFirstAndOnlyFirst()
		{
			var a = new RecordingReporter(false);
			var b = new RecordingReporter(true);
			var c = new RecordingReporter(true);

			var reporter = new FirstWorkingReporter(a,b,c);
	Assert.IsTrue(reporter.IsWorkingInThisEnvironment());
			reporter.Report("a","b");
			Assert.IsNull(a.CalledWith);
			Assert.AreEqual("a,b", b.CalledWith);
			Assert.IsNull(c.CalledWith);
		}
	}
}