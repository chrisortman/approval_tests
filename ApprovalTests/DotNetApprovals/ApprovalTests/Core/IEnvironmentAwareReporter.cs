namespace ApprovalTests.Core
{
	public interface IEnvironmentAwareReporter:IApprovalFailureReporter
	{
		bool IsWorkingInThisEnvironment();
	}
}