using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CR_ApprovalTests
{
	public class OpenInExplorerSmartTagItem : SmartTagItem
	{
		public OpenInExplorerSmartTagItem(string name, string path)
			: base(name)
		{
			Path = path;
		}

		public string Path { get; set; }

		protected override void OnExecute()
		{
			if (!File.Exists(Path))
			{
				if (
					MessageBox.Show("Approval doesn't exist would you like to copy one?", "Approval Not Found", MessageBoxButtons.YesNo) ==
					DialogResult.Yes)
					SetApprovalSmartTagItem.PromptForFileAndCopyToApproval(Path);
			}
			else
			Process.Start("explorer", String.Format("/select,{0}", Path));
		}
	}
}
