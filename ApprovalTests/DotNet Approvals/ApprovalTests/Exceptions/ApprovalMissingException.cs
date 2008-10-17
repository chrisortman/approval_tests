namespace ApprovalTests
{
	public class ApprovalMissingException : ApprovalException
	{
		public ApprovalMissingException(string received, string approved) : base(received, approved)
		{
		}

		public override string Message
		{
			get { return string.Format("Failed Approval: Approval File \"{0}\" Not Found.", Approved); }
		}
	}
}