using System.Collections.Generic;
using System.Data.Objects;

namespace ApprovalUtilities.Persistence.EntityFramework
{
	public static class EntityFrameworkLoadersExtensions
	{
		public static LamdaSingleLoader<T, C> Singleton<T, C>(this EntityFrameworkLoader<T, IEnumerable<T>, C> otherLoader)
			where C : ObjectContext
		{
			return new LamdaSingleLoader<T, C>(otherLoader);
		}
	}
}