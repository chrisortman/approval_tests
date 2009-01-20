using System;
using System.Collections.Generic;
using ApprovalTests.Writers;

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

		public static void ShouldBeApproved<T>(this IEnumerable<T> e, string label, EnumerableWriter.CustomFormatter<T> formatter)
		{
			Approvals.Approve(e, label, formatter);
		}
		
		public static void ShouldBeApproved<T>(this IEnumerable<T> e, EnumerableWriter.CustomFormatter<T> formatter)
		{
			Approvals.Approve(e, formatter);
		}
	}
}