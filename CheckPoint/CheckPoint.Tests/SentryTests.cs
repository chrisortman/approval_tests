using ApprovalTests;
using NUnit.Framework;
using TypeMock.ArrangeActAssert;

namespace CheckPoint.Tests
{
	[TestFixture]
	public class SentryTests
	{
		[Test]
		[Isolated]
		public void GetInteractions()
		{
			Sentry s = Monitor.Interactions(typeof (Controller));

			var controller = new Controller();
			controller.Action();

			Approvals.Approve(s.Report);
		}

		[Test]
		[Isolated]
		public void GetInteractionsAgainstSystemTypes()
		{
			Sentry s = Monitor.Interactions(typeof (Controller));

			var controller = new Controller();
			controller.ActionsAgainstSystemTypes();

			Approvals.Approve(s.Report);
		}

		[Test]
		[Isolated]
		public void GetListOfCalls()
		{
			Sentry s = Monitor.Calls<Model>();

			var controller = new Controller();
			controller.Action();

			Approvals.Approve(s.Report);
		}
	}
}