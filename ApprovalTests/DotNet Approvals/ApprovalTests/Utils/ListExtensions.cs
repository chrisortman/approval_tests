using System.Collections;
using System.Collections.Generic;

namespace ApprovalTests.Utils
{
	public static class ListExtensions
	{
		public static bool IsEmpty<T>(this List<T> list)
		{
			return list.Count == 0;
		}

		public static void Push<T>(this List<T> list, T item)
		{
			list.Insert(0, item);
		}

		public static void Pop<T>(this List<T> list)
		{
			list.RemoveAt(0);
		}
	}
}