using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using ApprovalUtilities.Persistence;
using ApprovalUtilities.Persistence.EntityFramework;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Tests.EntityFramework
{
	public class CompanyList
	{
		public static string GetCompanyRoster(string name)
		{
			return GetCompanyRoster(name, CompanyNameLoader(name));
		}

		public static LamdaArrayLoader<Company, ModelContainer> CompanyNameLoader(string name)
		{
			return LoaderUtils.Load((m) => (from c in m.Companies
			                                where c.Name.StartsWith(name)
			                                select c).Take(10));
		}


		public static string GetCompanyRoster(string name, ILoader<IEnumerable<Company>> loader)
		{
			var companies = loader.Load();
			StringBuilder b = new StringBuilder();
			b.Append("<html><body> <h1> Companies starting with '{0}'</h1>".FormatWith(name));
			foreach (var company in companies)
			{
				b.Append("<li>{0}</li>".FormatWith(company.Name));
			}
			b.Append("</body></html>");
			return b.ToString();
		}
	}
}