using System.Linq;
using ApprovalUtilities.Persistence.EntityFramework;
using NUnit.Framework;

namespace ApprovalTests.Tests.EntityFramework
{
	[TestFixture]
	public class EntityFrameworkLoaderTest
	{
		[Test]
		public void Text()
		{
			Approvals.Approve(new CompanyLoaderByName("M"));
		}
	}

	public class CompanyLoaderByName : EntityFrameworkLoader<Company, Company[], ModelContainer>
	{
		private readonly string name;
		
		public CompanyLoaderByName(string name) : base(() => new ModelContainer())
		{
			this.name = name;
		}

		public override IQueryable<Company> GetLinqStatement()
		{
			return from c in GetDatabaseContext().Companies
			       where c.Name.StartsWith(name)
			       select c;
		}
		
		public override Company[] Load()
		{
			return GetLinqStatement().ToArray();
		}
	}
}