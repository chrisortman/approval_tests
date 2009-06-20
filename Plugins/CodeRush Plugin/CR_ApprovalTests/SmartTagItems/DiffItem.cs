using System.Diagnostics;
using System.IO;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.SmartTagItems
{
	public class DiffItem : SmartTagItem
	{
		private string imageDiffArgs = "/left:\"{0}\" /right:\"{1}\"";
		private string imageDiffTool = "tortoiseidiff";
		private string textDiffArgs = "\"{0}\" \"{1}\"";
		private string textDiffTool = "tortoisemerge";

		public DiffItem(string name, string received, string approved)
			: base(name)
		{
			Received = received;
			Approved = approved;
		}

		public string Approved { get; set; }
		public string Received { get; set; }

		protected override void OnExecute()
		{
			if (Path.GetExtension(Received).EndsWith("png"))
				Process.Start(imageDiffTool, string.Format(imageDiffArgs, Received, Approved));
			else
				Process.Start(textDiffTool, string.Format(textDiffArgs, Received, Approved));
		}
	}
}