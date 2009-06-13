using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ApprovalTests;
using NUnit.Framework;
using TypeMock;
using TypeMock.ArrangeActAssert;
using CR=DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.Tests
{
	[TestFixture]
	[UseReporter(typeof (DiffReporter))]
	public class MenuTests
	{
		#region Setup/Teardown

		[NUnit.Framework.SetUp]
		public void Setup()
		{
			Isolate.WhenCalled(() => CR.CodeRush.Source.Active).ReturnRecursiveFake();
			Isolate.WhenCalled(() => CR.CodeRush.Documents.ActiveTextDocument.FullName).ReturnRecursiveFake();
			Isolate.WhenCalled(() => CR.CodeRush.Source.ActiveMethod).ReturnRecursiveFake();
		}

		#endregion

		private string ShowMenu(CR.ISmartTagItem item)
		{
			var sb = new StringBuilder();
			sb.AppendLine(item.Name);
			foreach (CR.ISmartTagItem sub in item.GetSubMenuItems())
			{
				sb.AppendLine("  " + sub.Name);
			}
			return sb.ToString();
		}


		[NUnit.Framework.Test]
		public void NoReceivedAndNoApproved()
		{
			var plugin = new ApprovalTestsPlugin();
			var args = new CR.GetSmartTagItemsEventArgs();
			Mock<ApprovalArtifacts> artifacts = MockManager.Mock<ApprovalArtifacts>();

			artifacts.AlwaysReturn("HasReceivedFile", false);
			artifacts.AlwaysReturn("HasApprovalFile", false);

			plugin.ConstructMenu(args);

			Approvals.Approve(args.Items, i => ShowMenu(i));
		}

		[NUnit.Framework.Test]
		public void WithApprovedFileNoReceivedFile()
		{
			var plugin = new ApprovalTestsPlugin();
			var args = new CR.GetSmartTagItemsEventArgs();
			Mock<ApprovalArtifacts> artifacts = MockManager.Mock<ApprovalArtifacts>();

			artifacts.AlwaysReturn("HasReceivedFile", false);
			artifacts.AlwaysReturn("HasApprovalFile", true);

			plugin.ConstructMenu(args);

			Approvals.Approve(args.Items, i => ShowMenu(i));
		}

		[NUnit.Framework.Test]
		public void WithReceivedFileAndApprovedFile()
		{
			var plugin = new ApprovalTestsPlugin();
			var args = new CR.GetSmartTagItemsEventArgs();
			Mock<ApprovalArtifacts> artifacts = MockManager.Mock<ApprovalArtifacts>();

			artifacts.AlwaysReturn("HasApprovalFile", true);
			artifacts.AlwaysReturn("HasReceivedFile", true);

			plugin.ConstructMenu(args);

			Approvals.Approve(args.Items, i => ShowMenu(i));
		}

		[NUnit.Framework.Test]
		public void WithReceivedFileNoApprovedFile()
		{
			var plugin = new ApprovalTestsPlugin();
			var args = new CR.GetSmartTagItemsEventArgs();
			Mock<ApprovalArtifacts> artifacts = MockManager.Mock<ApprovalArtifacts>();

			artifacts.AlwaysReturn("HasApprovalFile", false);
			artifacts.AlwaysReturn("HasReceivedFile", true);

			plugin.ConstructMenu(args);

			Approvals.Approve(args.Items, i => ShowMenu(i));
		}
	}
}