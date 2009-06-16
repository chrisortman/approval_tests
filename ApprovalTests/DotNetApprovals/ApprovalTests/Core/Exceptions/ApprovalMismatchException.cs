namespace ApprovalTests.Core.Exceptions
{
	public class ApprovalMismatchException : ApprovalException
	{
		public ApprovalMismatchException(string received, string approved) : base(received, approved)
		{
		}

		public override string Message
		{
			get { return string.Format("Failed Approval: Received file {0} does not match approved file {1}.", Received, Approved); }
		}
	}
}