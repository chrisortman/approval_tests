using System;
using System.IO;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.SmartTagItems
{
	public class ApproveItem : SmartTagItem
	{
		public ApproveItem(string name, string received, string approved) : base(name)
		{
			Approved = approved;
			Received = received;
		}

		public string Received { get; set; }
		public string Approved { get; set; }

		protected override void OnExecute()
		{
			if (File.Exists(Approved))
				File.Delete(Approved);
			if (Path.GetExtension(Received) != Path.GetExtension(Approved))
			{
				Approved = Path.GetFileNameWithoutExtension(Approved);
				if (!Approved.EndsWith("approved"))
					Approved += ".approved";
				Approved = String.Format("{0}/{1}{2}", Path.GetDirectoryName(Received), Approved, Path.GetExtension(Received));
			}
			File.Copy(Received, Approved, true);
			File.Delete(Received);

			CodeRush.Command.Execute("Test.RunTestsInCurrentContext");
		}
	}
}