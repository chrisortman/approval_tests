
using System;
using System.Collections.Generic;

namespace ApprovalTests.Extensions
{
	public static class ApprovalExtensions
	{
		public static void ShouldBeApproved<T>(this T o)
		{
			Approvals.Approve(o.ToString());
		}

		public static void ShouldBeApproved<T>(this IEnumerable<T> e, string label)
		{
			Approvals.Approve(e, label);
		}
		public static void ShouldBeApproved<T>(this IEnumerable<T> e, Func<T, string> formatter, string label)
		{
			Approvals.Approve(e, formatter, label);
		}
		public static void ShouldBeApproved<T>(this IEnumerable<T> e, Func<T, string> formatter)
		{
			Approvals.Approve(e, formatter);
		}
	}
}