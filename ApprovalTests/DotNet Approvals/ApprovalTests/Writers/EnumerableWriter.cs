using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;

namespace ApprovalTests.Writers
{
	public class EnumerableWriter
	{
		public static string Write<T>(String label, IEnumerable<T> enumerable)
		{
			return Write(label, s => "" + s, enumerable);
		}
		public static string Write<T>(string label, Func<T, string> formatter, IEnumerable<T> enumerable)
		{
			return Write((i, s) => string.Format("{0}[{1}] = {2}" + Environment.NewLine, label, i, formatter(s)), enumerable, string.Format("{0} is empty", label));
		}
		public static string Write<T>(Func<T, string> formatter, IEnumerable<T> enumerable)
		{
			return Write((i, s) => formatter(s), enumerable, "Empty");
		}

		public static string Write<T>(Func<int, T,string> formatter, IEnumerable<T> enumerable, string emptyString)
		{
			if (enumerable == null)
				return emptyString; 

			StringBuilder sb = new StringBuilder();
			int i = 0;

			foreach (var item in enumerable)
			{
				sb.Append(formatter(i,item));
				i++;
			}

			if (sb.Length == 0)
				return emptyString; 

			return sb.ToString();
		}
	}
}