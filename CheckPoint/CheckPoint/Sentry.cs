using System.Collections.Generic;
using TypeMock;

namespace CheckPoint
{
	public class Sentry
	{
		private readonly List<string> methodCalls = new List<string>();

		public Sentry(Mock mock)
		{
			Mock = mock;
		}

		public Mock Mock { get; set; }

		public string[] Calls
		{
			get { return methodCalls.ToArray(); }
		}

		public void Call(object sender, MockMethodCallEventArgs args)
		{
			methodCalls.Add(args.CalledMethodName);
		}
	}
}