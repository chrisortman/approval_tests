using System;
using System.Data.Objects;
using System.Linq;

namespace ApprovalUtilities.Persistence.EntityFramework
{
	public class Loaders
	{
		public static LamdaArrayLoader<T,C> Create<T,C>(C modelContainer, Func<C, IQueryable<T>> func)
			where C : ObjectContext
		{
			return new LamdaArrayLoader<T,C>(modelContainer, func);
		}

		public static LamdaArrayLoader<T,C> Create<T,C>(Func<C> modelContainer, Func<C, IQueryable<T>> func)
			where C : ObjectContext
		{
			return new LamdaArrayLoader<T,C>(modelContainer, func);
		}

	}
}