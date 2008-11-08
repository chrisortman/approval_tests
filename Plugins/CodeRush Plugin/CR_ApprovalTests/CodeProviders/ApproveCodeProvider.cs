using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests.CodeProviders
{
	public abstract class ApproveCodeProvider : CodeProvider
	{
		protected ApproveCodeProvider()
		{
			AutoActivate = true;
			AutoUndo = false;
			Register = true;

			Apply += OnApply;
			CheckAvailability += OnCheckAvailable;
		}

		private void OnCheckAvailable(object sender, CheckContentAvailabilityEventArgs ea)
		{
			ea.Available = true;
		}

		protected abstract void OnApply(object sender, ApplyContentEventArgs ea);
	}
}