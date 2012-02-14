namespace ApprovalTests.Reporters
{
	public class FrameworkAssertReporter : FirstWorkingReporter
	{
		public readonly static FrameworkAssertReporter INSTANCE = new FrameworkAssertReporter();
		public FrameworkAssertReporter()
			: base(MsTestReporter.INSTANCE, NUnitReporter.INSTANCE)
		{

		}
	}
}