using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CR_ApprovalTests
{
	public class SetApprovalSmartTagItem : SmartTagItem
	{
		public SetApprovalSmartTagItem(string name, string approved)
			: base(name)
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
