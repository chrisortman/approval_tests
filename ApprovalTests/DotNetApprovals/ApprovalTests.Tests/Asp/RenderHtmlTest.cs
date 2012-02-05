using ApprovalTests.Asp;
using ApprovalTests.Reporters;
using Asp.Net.Demo.Orders;
using NUnit.Framework;

namespace ApprovalTests.Tests.Asp
{
	[TestFixture]
	[UseReporter(typeof(DiffReporter), typeof(FileLauncherReporter))]
	public class RenderHtmlTest
	{
		[Test]
		public void TestSimpleInvoice()
		{
			AspApprovals.VerifyAspPage(new InvoiceView().TestSimpleInvoice);
			//  -- These are the same thing
			//AspApprovals.VerifyUrl("http://localhost:1359/Orders/InvoiceView.aspx?TestSimpleInvoice");
		}
	}
}
