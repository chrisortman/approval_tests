using System;
using System.Linq;
using ApprovalUtilities.Persistence;
using ApprovalUtilities.Persistence.EntityFramework;
using NUnit.Framework;

namespace ApprovalTests.Tests.EntityFramework
{
	[TestFixture]
	public class EntityFrameworkLoaderTest
	{
		[Test]
		public void FromInheritence()
		{
			Approvals.Approve(new CompanyLoaderByName2("M1"));
		}

		[Test]
		public void FromLambda()
		{
			Approvals.Approve(CreateCompanyLoaderByName("Mic"));
		}

		private LamdaArrayLoader<Company, ModelContainer> CreateCompanyLoaderByName(string name)
		{
			return LoaderUtils.Load(db => (from c in db.Companies
												 where c.Name.StartsWith(name)
												 select c).Take(10));
		}

		[Test]
		public void FromSingleLambda()
		{
			var loader1 = CreateCompanyLoaderByName("Mic");
			IExecutableLoader<Company> loader = loader1.Singleton();
			Approvals.Approve(loader);
		}

	}
}