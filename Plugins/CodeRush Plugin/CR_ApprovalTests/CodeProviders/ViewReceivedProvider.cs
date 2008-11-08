using System.Diagnostics;
using CR_ApprovalTests.CodeProviders;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests
{
	public class ViewReceivedProvider : ApproveCodeProvider
	{
		protected override void OnApply(object sender, ApplyContentEventArgs ea)
		{
			Process.Start(new ApprovalArtifacts(ea.Element, ea.TextDocument.FullName).Received);
		}
	}
}