using ApprovalTests.Namers;
using ApprovalTests.Reporters;

namespace ApprovalTests.Asp
{
    public static class Approvals
    {
        public static void ApproveAspPage(string page, string queryString, string relativePath)
        {
            var host = AppRenderer.GetHostRelativeToAssemblyPath(relativePath);
            var htmlResult = host.ExecuteMvcUrl(page, queryString);
            ApprovalTests.Approvals.Approve(new ApprovalTextWriter(htmlResult, "html"), new UnitTestFrameworkNamer(), ApprovalTests.Approvals.GetReporter(new OpenReceivedFileReporter()));
        }
    }
}
