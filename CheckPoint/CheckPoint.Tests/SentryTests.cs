using System;
using NUnit.Framework;
using ApprovalTests;
using TypeMock;
using System.Collections.Generic;
using System.Reflection;
using TypeMock.ArrangeActAssert;

namespace CheckPoint.Tests
{
	[TestFixture]
	public class SentryTests
	{
		[Test]
		[Isolated]
		public void GetListOfCalls()
		{
			Sentry s = Monitor.Calls(typeof(Model));

			var controller = new Controller();
			controller.Action();

			Approvals.Approve(s.Calls, "Call");
		}
	}

	public class Model
	{
		public void Call1()
		{
			
		}

		public void Call2()
		{
			
		}
	}

	public class Controller
	{
		private Model model = new Model();
		public void Action()
		{
			model.Call1();
			model.Call2();
		}
	}

	


}
