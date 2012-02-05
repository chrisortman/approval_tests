using System;
using System.Windows;

namespace ApprovalTests.Wpf
{
	public class WpfApprovals
	{
		public static void Verify(Window window)
		{
			ApprovalTests.Approvals.Verify(new ApprovalWpfWindowWriter(window));
		}

		public static void Verify(Func<Window> action)
		{
			ApprovalTests.Approvals.Verify(new WindowWpfWriter(action));
		}
	}
}