using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace ApprovalUtilities.Persistence.EntityFramework
{
	public class LamdaSingleLoader<T, C> : EntityFrameworkLoader<T, T, C>
		where C : ObjectContext
	{
		private readonly EntityFrameworkLoader<T, IEnumerable<T>, C> loader;


		public LamdaSingleLoader(EntityFrameworkLoader<T, IEnumerable<T>, C> loader)
			: base((C) null)
		{
			this.loader = loader;
		}

		public override IQueryable<T> GetLinqStatement()
		{
			return loader.GetLinqStatement().Take(1);
		}

		public override T Load()
		{
			return GetLinqStatement().FirstOrDefault();
		}

		public override string ExecuteQuery(string query)
		{
			return loader.ExecuteQuery(query);
		}
	}
}