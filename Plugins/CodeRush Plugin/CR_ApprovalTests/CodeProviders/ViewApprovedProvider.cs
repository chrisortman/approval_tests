using System.Diagnostics;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.CodeProviders
{
	public class ViewApprovedProvider : ApproveCodeProvider
	{
		protected override void OnApply(object sender, ApplyContentEventArgs ea)
		{
			Process.Start(new ApprovalArtifacts(ea.Element, ea.TextDocument.FullName).Approved);
		}
	}
}