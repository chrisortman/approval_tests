using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalDemos.Data
{
	[TestFixture]
	[UseReporter(typeof(DiffReporter))]
	public class HtmlTest
	{
	
		[Test]
		public void TestLambdas()
		{
			string html = "<html><body><h1>Hello World</h1></body></html>";
			Approvals.ApproveHtml(html);
		}

		
	}
}