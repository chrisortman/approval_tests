using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
    [TestFixture]
    [UseReporter(typeof (DiffReporter))]
    public class ApprovalsTest
    {
        private static readonly string[] text = new string[] {"abc", "123", "!@#"};

        [Test]
        public void Text()
        {
            Approvals.Approve("should be approved");
        }

        [Test]
        public void EnumerableWithLabel()
        {
            Approvals.Approve(text, "collection");
        }

        [Test]
        public void EnumerableWithLabelAndFormatter()
        {
            Approvals.Approve(text, "collection", (t) => "" + t.Length);
        }

        [Test]
        public void EnumerableWithFormatter()
        {
            Approvals.Approve(text, (t) => "" + t.Length);
        }
    }
}