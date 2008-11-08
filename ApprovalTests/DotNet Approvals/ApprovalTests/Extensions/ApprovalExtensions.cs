using System.Collections;

namespace ApprovalTests.Extensions
{
	public static class ApprovalExtensions
	{
		public static void ShouldBeApproved(this string s)
		{
			Approvals.Approve(s);
		}

		public static void ShouldBeApproved(this IEnumerable e, string label)
		{
			Approvals.Approve(e, label);
		}
	}
}