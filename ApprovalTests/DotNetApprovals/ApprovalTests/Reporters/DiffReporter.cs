using System;
using System.Diagnostics;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Reporters
{
	public class DiffReporter : FirstWorkingReporter
	{
		public DiffReporter()
			: base(TortoiseDiffReporter.INSTANCE, 
			BeyondCompareReporter.INSTANCE, 
			WinMergeReporter.INSTANCE,
 			FrameworkAssertReporter.INSTANCE,
			QuietReporter.INSTANCE)
		{

		}


		public static void Launch(LaunchArgs launchArgs)
		{
			try
			{
				Process.Start(launchArgs.Program, launchArgs.Arguments);
			}
			catch (System.ComponentModel.Win32Exception e)
			{

				throw new Exception("Unable to launch: {0} with arguments {1}\nError Message: {2}".FormatWith(launchArgs.Program, launchArgs.Arguments, e.Message), e);
			}
		}
	}
}