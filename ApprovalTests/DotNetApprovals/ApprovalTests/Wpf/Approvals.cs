using System.Windows;
using ApprovalTests.Namers;
using ApprovalTests.Writers;

namespace ApprovalTests.Wpf
{
	public class Approvals
	{
		public static void Approve(Window window)
		{
			ApprovalTests.Approvals.Approve(new ApprovalWpfWindowWriter(window), new UnitTestFrameworkNamer(),
			                                ApprovalTests.Approvals.GetReporter());
		}

		//public static void Approve(Control control)
		//{
		//    ApprovalTests.Approvals.Approve(new ApprovalControlWriter(control), new UnitTestFrameworkNamer(),
		//                                    ApprovalTests.Approvals.GetReporter());
		//}
	}
}