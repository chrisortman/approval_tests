using System;
using System.Reflection;
using TypeMock;
using System.Collections.Generic;

namespace CheckPoint
{
	public class Monitor
	{
		public static Sentry Calls(Type t)
		{
			Mock mock = MockManager.Mock(t);
			var report = new Sentry(mock);
			mock.MockMethodCalled += (sender, args) => report.Call(sender, args);
			foreach (MethodInfo method in t.GetMethods())
			{
				try
				{
					mock.AlwaysReturn(method.Name, MockManager.CONTINUE_WITH_METHOD);
				}
				catch
				{
				}
			}

			return report;
		}
	}

	
}