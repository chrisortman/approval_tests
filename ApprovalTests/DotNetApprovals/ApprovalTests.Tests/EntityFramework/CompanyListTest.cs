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
		public void TestRoster()
		{
			var mockLoader = new MockLoader<IEnumerable<Company>>( new []{new Company(){Name = "Motorola"}});
			var html = CompanyList.GetCompanyRoster("M", mockLoader);
			ApprovalTests.Html.Approvals.ApproveHtml(html);
		}

		[Test]
		public void TestLoader()
		{
			Approvals.Approve(CompanyList.CompanyNameLoader("Mi").Singleton());
		}
	}
}