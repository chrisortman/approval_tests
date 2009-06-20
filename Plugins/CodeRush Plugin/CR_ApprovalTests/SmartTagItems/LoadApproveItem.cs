using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.SmartTagItems
{
	public class LoadApproveItem : SmartTagItem
	{
		public LoadApproveItem(string name, string approved) : base(name)
		{
			Approved = approved;
		}

		public string Approved { get; set; }

		protected override void OnExecute()
		{
			PromptForFileAndCopyToApproval(Approved);
		}

		public static void PromptForFileAndCopyToApproval(string approved)
		{
			var d = new OpenFileDialog();
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (File.Exists(approved))
					File.Copy(d.FileName, approved, true);
				else
					File.Copy(d.FileName, String.Format("{0}{1}", approved, Path.GetExtension(d.FileName)), true);
				CodeRush.Command.Execute("Test.RunTestsInCurrentContext");
			}
		}
	}
}