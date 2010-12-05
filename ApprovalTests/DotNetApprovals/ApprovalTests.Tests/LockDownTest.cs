using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
    [TestFixture]
    [UseReporter(typeof (DiffReporter))]
    public class LockDownTests
    {
        public string Echo(params int[] i)
        {
            return StringUtils.ToReadableString(i);
        }

        [Test]
        public void TestLockDown()
        {
            int[] n = {1, 2};
            LockDown.Approvals.LockDown(n,n,n,n,n,n,n,n,n,(a,b,c,d,e,f,g,h,i)=>Echo(a,b,c,d,e,f,g,h,i));
        }
        [Test]
        public void TestLockDown8()
        {
            int[] n = { 1, 2 };
            LockDown.Approvals.LockDown(n, n, n, n, n, n, n, n, (a, b, c, d, e, f, g, h) => Echo(a, b, c, d, e, f, g, h));
        }
        [Test]
        public void TestLockDown2()
        {
            int[] n = { 1, 2 };
            LockDown.Approvals.LockDown(n, n,  (a, b) => Echo(a, b));
        }
    }
}