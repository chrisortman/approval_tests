using System;
using System.Collections.Generic;
using System.Text;
using TypeMock;

namespace CheckPoint
{
	public class Sentry
	{
		private readonly List<string> methodCalls = new List<string>();

		public string[] Calls
		{
			get { return methodCalls.ToArray(); }
		}

		public string Report
		{
			get
			{
				var sb = new StringBuilder();
				foreach (string call in Calls)
				{
					sb.AppendLine(call);
				}
				return sb.ToString();
			}
		}

		public void Call(object sender, MockMethodCallEventArgs args)
		{
			methodCalls.Add(String.Format("{0}.{1}()", args.CalledType, args.CalledMethodName));
		}

		public void Call(object sender, MockMethodCallEventArgs args, string name)
		{
			methodCalls.Add(String.Format("({0}) {1}.{2}()", args.CalledType, name, args.CalledMethodName));
		}
	}
}