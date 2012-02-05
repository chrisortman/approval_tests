using System;

namespace ApprovalTests.Asp
{
	[Obsolete("Use AspApprovals instead")]
	public static class Approvals
	{
		public static void ApproveAspPage(Action testMethod)
		{
			AspApprovals.VerifyAspPage(testMethod);
		}

		public static void ApproveUrl(string url)
		{
			AspApprovals.VerifyUrl(url);
		}

		public static string GetUrlContents(string url)
		{
			return AspApprovals.GetUrlContents(url);
		}
	}
}