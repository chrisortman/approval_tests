using System;
using System.Runtime.Serialization;

namespace ApprovalTests
{
	public class ApprovalException : Exception
	{
		private readonly string received;
		private readonly string approved;

		protected ApprovalException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
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
	}
}