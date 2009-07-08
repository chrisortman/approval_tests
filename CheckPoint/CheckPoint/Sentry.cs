using System.Collections.Generic;
using TypeMock;
using System;
using System.Reflection;
using System.Text;

namespace CheckPoint
{
	public class Sentry
	{
		private readonly List<string> methodCalls = new List<string>();

		public string[] Calls
		{
			get { return methodCalls.ToArray(); }
		}

		public void Call(object sender, MockMethodCallEventArgs args)
		{
			methodCalls.Add(String.Format("{0}.{1}", args.CalledType, args.CalledMethodName));
		}

		public string Results
		{
			get
			{
				var sb = new StringBuilder();
				foreach (var call in Calls)
				{
					sb.AppendLine(call);
				}
				return sb.ToString();
			}
		}
	}
}