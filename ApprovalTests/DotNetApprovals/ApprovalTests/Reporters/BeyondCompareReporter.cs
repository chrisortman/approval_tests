using System;
using System.IO;

namespace ApprovalTests.Reporters
{
	public class BeyondCompareReporter:DiffReporter
	{
		public BeyondCompareReporter():base(new LaunchArgs(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Beyond Compare 3\BCompare.exe", "\"{0}\" \"{1}\""))
		{
			 
		}
	}
}