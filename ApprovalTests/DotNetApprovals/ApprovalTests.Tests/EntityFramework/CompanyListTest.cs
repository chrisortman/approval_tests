using System.Collections.Generic;
using ApprovalTests.Reporters;
using ApprovalUtilities.Persistence;
using NUnit.Framework;
using ApprovalUtilities.Persistence.EntityFramework;

namespace ApprovalTests.Tests.EntityFramework
{
	[TestFixture]
	//[UseReporter(typeof(FileLauncherReporter))]
	public class CompanyListTest
	{
		[Test]
		public void TestLoader()
		{
		Approvals.Approve(CompanyList.GetCompanyByName("m"));
		}
		[Test]
		public void TestLoader2()
		{
		Approvals.Approve(CompanyList.GetCompanyByName("mi"));
		}
	}
}