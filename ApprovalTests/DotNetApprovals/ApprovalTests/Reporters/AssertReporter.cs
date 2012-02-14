using System;
using System.IO;
using System.Reflection;
using ApprovalTests.Core;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Reporters
{
	public class AssertReporter : IEnvironmentAwareReporter
	{
		private readonly string assertClass;
		private readonly string areEqual;
		public AssertReporter(string assertClass, string areEqual)
		{
			this.assertClass = assertClass;
			this.areEqual = areEqual;
		}
		public virtual void Report(string approved, string received)
		{

			AssertFileContents(approved, received);
		}
		public bool IsWorkingInThisEnvironment()
		{
			return ExceptionUtilities.GetException(() => Type.GetType(assertClass)) == null;

		}

		public void AssertFileContents(string approved, string received)
		{
			var a = File.Exists(approved) ? File.ReadAllText(approved) : "";
			var r = File.ReadAllText(received);

			QuietReporter.DisplayCommandLineApproval(approved, received);
			try
			{
				Type.GetType(assertClass).InvokeMember(areEqual,
																							 BindingFlags.InvokeMethod | BindingFlags.Public |
																							 BindingFlags.Static, null, null, new[] { a, r });
			}
			catch (TargetInvocationException e)
			{
				throw e.GetBaseException();
			}
		}
	}
}