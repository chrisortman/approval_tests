using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using ApprovalTests;
using ApprovalTests.Approvers;
using CheckPoint.Extensions;
using CheckPoint.Namers;
using CheckPoint.Reporters;
using TypeMock;

namespace CheckPoint
{
	public class CheckPoints : IDisposable
	{
		private static object testID;

		private static object TestID
		{
			get { return testID; }
		}

		private static IApprovalFailureReporter reporter;

		public static IApprovalFailureReporter Reporter
		{
			get { return reporter ?? new DebugOutputReporter(); }
			set { reporter = value; }
		}

		private static CheckPointCommandCenter commandCenter;

		public CheckPoints()
		{
			Initialize();
		}

		public CheckPoints(IApprovalFailureReporter approvalReporter)
		{
			reporter = approvalReporter;
			Initialize();
		}

		private void Initialize()
		{
			testID = GetTestID();
			commandCenter = new CheckPointCommandCenter();
		}

		private static object GetTestID()
		{
			MethodBase m = new StackFrame(3).GetMethod();
			return String.Format(@"{0}\{1}", m.DeclaringType.Name, m.Name);
		}

		public void WatchAfter(Expression<Action> expression)
		{
			SetupCheckPoint(((MethodCallExpression)expression.Body).Method, null);
		}

		public void WatchAfter(Expression<Action> expression, Func<object, string> approveFunction)
		{
			SetupCheckPoint(((MethodCallExpression)expression.Body).Method, approveFunction);
		}

		public void WatchAfter<T>(Expression<Action<T>> expression)
		{
			SetupCheckPoint(((MethodCallExpression)expression.Body).Method, null);
		}

		public void WatchAfter<T>(Expression<Action<T>> expression, Func<object, string> approveFunction)
		{
			SetupCheckPoint(((MethodCallExpression)expression.Body).Method, approveFunction);
		}

		public void WatchAfter(string checkPointID)
		{
			commandCenter.Watch(new CheckPointWatch(checkPointID));
		}

		private void SetupCheckPoint(MethodInfo method, Func<object, string> approveFunction)
		{
			Type type = method.DeclaringType;
			string checkPointID = type.Name + "." + method.Name;
			commandCenter.Watch(new CheckPointWatch(checkPointID));
			DynamicReturnValue returnValue = (parameters, context) => CheckPointCall(method, checkPointID, parameters, context, approveFunction);
			MockManager.Mock(type, Constructor.NotMocked).AlwaysReturn(method.Name, returnValue);
		}

		public object CheckPointCall(MethodInfo method, object checkPointID, object[] parameters, object context, Func<object, string> approveFunction)
		{
			object r = method.Invoke(context, parameters);
			if (approveFunction != null)
				r = approveFunction.Invoke(r);

			return r.XRay(checkPointID);
		}

		public static void Approve<T>(T o, object checkPointID)
		{
			if (!BeingWatched(checkPointID))
				return;

			CheckPointWatch watch = commandCenter[checkPointID];
			watch.Called();

			try
			{
				var textWriter = new ApprovalTextWriter(o.ToString());
				var namer = new CheckPointApprovalNamer(checkPointID, TestID, commandCenter[checkPointID]);
				Approvals.Approve(textWriter, namer, Reporter);
			}
			catch
			{

			}
		}

		private static bool BeingWatched(object checkPointID)
		{
			return commandCenter.IsWatching(checkPointID);
		}

		public void Dispose()
		{
			var n = new CheckPointCommandCenterApprovalNamer(TestID);
			Approvals.Approve(new ApprovalTextWriter(commandCenter.Report()), n, Reporter);
		}
	}
}