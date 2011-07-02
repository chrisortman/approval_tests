using System;
using System.Net;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Asp
{
	public static class Approvals
	{
		public static void ApproveAspPage(Action testMethod)
		{
			var html = LoadHtmlFromUrl(testMethod);
			Html.Approvals.ApproveHtml(html);
		}

		private static string LoadHtmlFromUrl(Action testMethod)
		{
			var host = "http://localhost:1359";
			return ApproveUrl(host, GetUrl(testMethod, host));
		}

		private static string GetUrl(Action testMethod, string host)
		{
			var type = testMethod.Method.DeclaringType;
			var clazz = type.Name;
			var path = type.Namespace.Substring(type.Assembly.GetName().Name.Length);
			path = path.Replace('.', '/');
			var method = testMethod.Method.Name;
			return "{0}{1}/{2}.aspx?{3}".FormatWith(host, path, clazz, method);
		}

		private static string ApproveUrl(string host, string url)
		{
			try
			{
				string html;
				using (var client = new WebClient())
				{
					html = client.DownloadString(url);
					if (!html.Contains("<base"))
					{
						html = html.Replace("<head>", "<head><base href=\"{0}\">".FormatWith(host));
					}
				}
				return html;
			}
			catch (Exception e)
			{
				throw new Exception(
					"The following error occured while connecting to:\r\n{0}\r\nError:\r\n{1}".FormatWith(url, e.Message), e);
			}
		}

		public static void ApproveAspPage(string page, string queryString, string relativePath)
		{
			var host = AppRenderer.GetHostRelativeToAssemblyPath(relativePath);
			var htmlResult = host.ExecuteMvcUrl(page, queryString);
			ApprovalTests.Approvals.Approve(new ApprovalTextWriter(htmlResult, "html"), new UnitTestFrameworkNamer(),
			                                ApprovalTests.Approvals.GetReporter(new FileLauncherReporter()));
		}
	}
}