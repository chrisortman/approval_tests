using System;
using System.Runtime.Serialization;

namespace ApprovalTests.Exceptions
{
	[Serializable]
	public class ApprovalException : Exception
	{
		private readonly string received;
		private readonly string approved;

		public ApprovalException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			approved = info.GetString("Approved");
			received = info.GetString("Received");
		}

		public string Received
		{
			get { return received; }
		}

		public string Approved
		{
			get { return approved; }
		}

		public ApprovalException(string received, string approved)
		{
			this.received = received;
			this.approved = approved;
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue("Approved", Approved);
			info.AddValue("Received", Received);
		}
	}
}