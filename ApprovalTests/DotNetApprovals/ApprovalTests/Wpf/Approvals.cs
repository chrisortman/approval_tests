using System;
using System.Windows;

namespace ApprovalTests.Wpf
{
	[Obsolete("Use WpfApprovals instead")]
	public class Approvals
	{
		public static void Approve(Window window)
		{
			WpfApprovals.Verify(window);
		}

		public static void Approve(Func<Window> action)
		{
			WpfApprovals.Verify(action);

		}
	}
}