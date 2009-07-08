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
			Sentry s = Monitor.Calls<Model>();

			var controller = new Controller();
			controller.Action();

			Approvals.Approve(s.Results);
		}

		[Test]
		[Isolated]
		public void GetInteractions()
		{
			Sentry s = Monitor.Interactions(typeof(Controller));

			var controller = new Controller();
			controller.Action();

			Approvals.Approve(s.Results);
		}
	}
}