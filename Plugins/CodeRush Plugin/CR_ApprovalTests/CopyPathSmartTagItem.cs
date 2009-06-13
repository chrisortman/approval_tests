using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CR_ApprovalTests
{
	public class CopyPathSmartTagItem : SmartTagItem
	{
		public CopyPathSmartTagItem(string name, string path)
			: base(name)
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
