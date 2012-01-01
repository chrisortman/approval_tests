using System;
using System.Windows;

namespace ApprovalTests.Wpf
{
	public class Approvals
	{
		public static void Approve(Window window)
		{
			ApprovalTests.Approvals.Approve(new ApprovalWpfWindowWriter(window));
		}

		public static void Approve(Func<Window> action)
		{
			ApprovalTests.Approvals.Approve(new WindowWpfWriter(action));
		}
	}
}