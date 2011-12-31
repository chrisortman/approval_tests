using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
	[TestFixture]
	public class MultiReporterTest
	{
		[Test]
		public void TestMultiReporter()
		{
			var a = new RecordingReporter();
			var b = new RecordingReporter();
			var multi = new MultiReporter(a, b);
			multi.Report("a", "r");
			Assert.AreEqual("a,r", a.CalledWith);
			Assert.AreEqual("a,r", b.CalledWith);
		}
	}
}