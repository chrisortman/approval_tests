using System.Windows.Forms;
using NUnit.Framework;

namespace ApprovalTests.Extensions.WinForms.Tests
{
	[TestFixture]
	public class ControlExtensionTests
	{
		[Test]
		public void TestControlApprovedExtension()
		{
			new Label {Text = "approve this" }.ShouldBeApproved();
		}
	}
}