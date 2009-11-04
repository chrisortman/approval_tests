namespace ApprovalTests.Persistence
{
    public  interface IExecutableQuery
    {
        string GetQuery();
        string ExecuteQuery(string query);
    }
}