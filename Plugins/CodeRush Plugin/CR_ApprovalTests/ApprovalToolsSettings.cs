using DevExpress.CodeRush.Core;
using System;

namespace CR_ApprovalTests
{
	public class ApprovalToolsSettings
	{
		public string DiffTextTool { get; set; }
		public string DiffTextToolArgs { get; set; }
		public string DiffImageTool { get; set; }
		public string DiffImageToolArgs { get; set; }
		public string UnitTestCommand { get; set; }

		public static ApprovalToolsSettings LoadFrom(DecoupledStorage storage)
		{
			var settings = new ApprovalToolsSettings
			               	{
			               		DiffTextTool = "TortoiseMerge.exe",
			               		DiffTextToolArgs = "\"{0}\" \"{1}\"",
			               		DiffImageTool = "TortoiseIDiff.exe",
			               		DiffImageToolArgs = "/left:\"{0}\" /right:\"{1}\"",
								UnitTestCommand = "TestDriven.NET.RunTests"
			               	};
			return settings;
		}
	}
}