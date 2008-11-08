using System.Drawing;
using System.IO;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.CodeProviders
{
	public class ApproveProvider : ApproveCodeProvider
	{
		private readonly string unitTestCommand;

		public ApproveProvider(string runUnitTestCommand)
		{
			unitTestCommand = runUnitTestCommand;
		}

		protected override void OnApply(object sender, ApplyContentEventArgs ea)
		{
			var files = new ApprovalArtifacts(ea.Element, ea.TextDocument.FullName);
			File.Copy(files.Received, files.Approved, true);
			CodeRush.Command.Execute("TestDriven.NET.RunTests");
			CodeRush.Command.Execute(unitTestCommand);
			//CodeRush.Command.Execute("ReSharper.UnitTest_ContextRun");
			CodeRush.ActionHint.PointToCaret("Approved", Color.Red);
		}
	}
}