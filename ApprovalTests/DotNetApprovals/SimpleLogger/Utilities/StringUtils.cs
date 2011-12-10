using System;
using System.Collections;
using System.Text;

namespace ApprovalUtilities.Utilities
{
	public static class StringUtils
	{
		public static string ToReadableString(this IEnumerable list)
		{
			var sb = new StringBuilder();
			sb.Append("[");
			foreach (object l in list)
			{
				sb.Append(l + ", ");
			}
			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 2, 2);
			}
			sb.Append("]");
			return sb.ToString();
		}

		public static string FormatWith(this string mask, params object[] parameters)
		{
			return String.Format(mask, parameters);
		}

		public static string FormatFrame(char frameMarker, params string[] lines)
		{
			var sb = new StringBuilder();
			const int totalWidth = 86;
			string lineBreakOut = "".PadLeft(totalWidth, frameMarker);
			string lineBreakIn = "{0}{1}{0}".FormatWith(frameMarker, "".PadLeft(totalWidth - 2, ' '));
			sb.AppendLine(lineBreakOut);
			sb.AppendLine(lineBreakIn);
			foreach (var line in lines)
			{
				sb.AppendLine("{1} {0}".FormatWith(line.Replace(Environment.NewLine, "{0}{1} ".FormatWith(Environment.NewLine, frameMarker)), frameMarker));
			}
			sb.AppendLine(lineBreakIn);
			sb.AppendLine(lineBreakOut);
			return sb.ToString().Trim();
		}
	}
}