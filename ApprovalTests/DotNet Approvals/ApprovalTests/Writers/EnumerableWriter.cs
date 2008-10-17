using System;
using System.Collections;
using System.Text;

namespace ApprovalTests.Writers
{
	public class EnumerableWriter
	{
		public static string write(String label, IEnumerable enumerable)
		{
			if (enumerable == null)
				return string.Format("{0} is empty", label);

			StringBuilder sb = new StringBuilder();
			int i = 0;

			foreach (var item in enumerable)
			{
				sb.AppendLine(string.Format("{0}[{1}] = {2}", label, i, item));
				i++;
			}

			if (sb.Length == 0)
				return string.Format("{0} is empty", label);

			return sb.ToString();
		}
	}
}