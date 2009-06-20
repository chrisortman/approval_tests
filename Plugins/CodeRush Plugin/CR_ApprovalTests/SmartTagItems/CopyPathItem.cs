using System.Windows.Forms;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.SmartTagItems
{
	public class CopyPathItem : SmartTagItem
	{
		public CopyPathItem(string name, string path) : base(name)
		{
			Path = path;
		}

		public string Path { get; set; }

		protected override void OnExecute()
		{
			Clipboard.SetText(Path);
		}
	}
}