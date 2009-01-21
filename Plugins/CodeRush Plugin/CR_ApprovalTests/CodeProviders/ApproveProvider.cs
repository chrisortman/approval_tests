using System.Drawing;
using System.IO;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.CodeProviders
{
	public class ApproveProvider : ApproveCodeProvider
	{
		private readonly string unitTestCommand;
		private readonly ApprovalArtifacts files;

		public ApproveProvider(string runUnitTestCommand, ApprovalArtifacts files)
		{
			unitTestCommand = runUnitTestCommand;
			this.files = files;
		}

		protected override void OnApply(object sender, ApplyContentEventArgs ea)
		{
			if (!files.HasReceivedFile)
				return;

			File.Delete(files.Approved);
			File.Move(files.Received, files.Approved);
			RerunTests();
			CodeRush.ActionHint.PointToCaret("Approved", Color.Red);
		}

		private void RerunTests()
		{
			if (CodeRush.Command.Exists(unitTestCommand))
				CodeRush.Command.Execute(unitTestCommand);
		}
	}
}