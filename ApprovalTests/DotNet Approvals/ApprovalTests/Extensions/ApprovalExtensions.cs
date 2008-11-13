using System.Collections;

namespace ApprovalTests.Extensions
{
	public static class ApprovalExtensions
	{
		public static void ShouldBeApproved<T>(this T o)
		{
			Approvals.Approve(o.ToString());
		}

		public static void ShouldBeApproved(this IEnumerable e, string label)
		{
			Approvals.Approve(e, label);
		}
	}
}