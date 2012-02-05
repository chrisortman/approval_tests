namespace ApprovalTests.Html
{
	public class HtmlApprovals
	{
		public static void VerifyHtml(string html)
		{
			Xml.Approvals.ApproveText(html, "html", true);
		}

		/// <summary>
		/// 	Throws exception if Html is incorrectly formatted
		/// </summary>
		public static void VerifyHtmlStrict(string html)
		{
			Xml.Approvals.ApproveText(html, "html", false);
		}
	}
}