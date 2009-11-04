using ApprovalTests.Persistence;
using NUnit.Framework;

namespace ApprovalTests.Tests.Persistence
{
    [TestFixture]
    public class DatabaseTest
    {
        [Test]
        public void TestQuery()
        {
            Approvals.Approve(new CustomerLoader());
        }
    }
    internal class CustomerLoader : IExecutableQuery
    {
        public string GetQuery()
        {
            return "SELECT * FROM Customer";
        }

        public string ExecuteQuery(string query)
        {
            //SqlDataConne;
        }
    }
}