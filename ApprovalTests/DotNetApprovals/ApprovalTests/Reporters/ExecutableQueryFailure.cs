using System;
using System.IO;
using ApprovalTests.Core;
using ApprovalTests.Persistence;

namespace ApprovalTests.Reporters
{
    public class ExecutableQueryFailure : IApprovalFailureReporter
    {
        private readonly IExecutableQuery query;

        public ExecutableQueryFailure(IExecutableQuery query)
        {
            this.query = query;
        }

        public void Report(string approved, string received)
        {
            string r = RunQueryAndGetPath(received);
            string a = RunQueryAndGetPath(approved);
            new DiffReporter().Report(a, r);
        }

        private string RunQueryAndGetPath(string fileName)
        {
            if (!File.Exists(fileName)) return fileName;

            var newQuery = File.ReadAllText(fileName).Trim();
            var newResult = query.ExecuteQuery(newQuery);
            string newFileName = fileName + ".queryresults.txt";
            File.WriteAllText( newFileName, string.Format("query:\r\n{0}\r\nresult:\r\n{1}", newQuery, newResult));
            return newFileName;
        }

      
    }
}