using System.Windows;
using System.Windows.Controls;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using NUnit.Framework;

namespace ApprovalTests.Tests.Wpf
{
	[TestFixture]
	[UseReporter(typeof(ImageReporter))]
	public class ApprovalsTest
	{
		[Test]
		public void TestFormApproval()
		{
			var button = new Button { Content = "Hello" };
			var window = new Window { Content = button, Width = 200, Height = 200 };
			WpfApprovals.Verify(window);
		}
	}
}