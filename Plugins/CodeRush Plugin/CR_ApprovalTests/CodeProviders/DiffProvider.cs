using System.Diagnostics;
using System.IO;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.CodeProviders
{
	public class DiffProvider : ApproveCodeProvider
	{
		private readonly string imageDiffArgs;
		private readonly string imageDiffTool;
		private readonly string textDiffArgs;
		private readonly string textDiffTool;

		public DiffProvider(string textDiff, string textArgs, string imageDiff, string imageArgs)
		{
			textDiffTool = textDiff;
			textDiffArgs = textArgs;
			imageDiffArgs = imageArgs;
			imageDiffTool = imageDiff;
		}

		protected override void OnApply(object sender, ApplyContentEventArgs ea)
		{
			var files = new ApprovalArtifacts(ea.Element, ea.TextDocument.FullName);
			if (Path.GetExtension(files.Received).EndsWith("png"))
				Process.Start(imageDiffTool, string.Format(imageDiffArgs, files.Approved, files.Received));
			else
				Process.Start(textDiffTool, string.Format(textDiffArgs, files.Approved, files.Received));
		}
	}
}