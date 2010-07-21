using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Asp
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class RenderHtmlTest
    {
        [Test]
        public void TestRender()
        {
            ApprovalTests.Asp.Approvals.ApproveAspPage("Home/Index", "", @"..\..\..\MVCApplication");
        }
    }
}
