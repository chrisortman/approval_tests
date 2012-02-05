using System;

namespace ApprovalTests.Html
{
	[Obsolete("Use HtmlApprovals instead")]

	public class Approvals
	{
		public static void ApproveHtml(string html)
		{
			HtmlApprovals.VerifyHtml(html);
		}

		/// <summary>
		/// 	Throws exception if Html is incorrectly formatted
		/// </summary>
		public static void ApproveHtmlStrict(string html)
		{
			HtmlApprovals.VerifyHtmlStrict(html);
		}
	}
}