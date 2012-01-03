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
	}
}