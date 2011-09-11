using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace ApprovalUtilities.Persistence.EntityFramework
{
	public class LamdaArrayLoader<T,C> : EntityFrameworkLoader<T, IEnumerable<T>, C>
		where C : ObjectContext
	{
		private readonly Func<C, IQueryable<T>> func;

		public LamdaArrayLoader( C context, Func<C, IQueryable<T>> func) : base(context)
		{
			this.func = func;
		}public LamdaArrayLoader( Func<C> context, Func<C, IQueryable<T>> func) : base(context)
		{
			this.func = func;
		}

		public override IQueryable<T> GetLinqStatement()
		{
			return func(GetDatabaseContext());
		}

		public override IEnumerable<T> Load()
		{
			return GetLinqStatement().ToArray();
		}
	}
}