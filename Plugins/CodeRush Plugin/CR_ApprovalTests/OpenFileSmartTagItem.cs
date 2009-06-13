using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests
{
	public class OpenFileSmartTagItem : SmartTagItem
	{
		public OpenFileSmartTagItem(string name, string path)
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
				Process.Start(Path);
		}
	}
}