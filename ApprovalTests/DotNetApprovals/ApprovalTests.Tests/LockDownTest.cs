using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class LockDownTests
    {
        public string ProcessCall(int i, string s)
        {
            return string.Format("[{0}, {1}]", i, s);
        }

        [Test]
        public void TestLockDown()
        {
            LockDown.Approvals.LockDown(ProcessCall, new[] {1, 2, 3, 4, 5},
                                        new[] {"a", "b", "c", "d"});
        }
    }
}