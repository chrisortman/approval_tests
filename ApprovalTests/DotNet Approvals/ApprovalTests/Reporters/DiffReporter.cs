﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public struct LaunchArgs
	{
		private string arguments;
		private string program;

		public LaunchArgs(string program, string arguments)
		{
			this.program = program;
			this.arguments = arguments;
		}

		public string Program
		{
			get { return program; }
		}

		public string Arguments
		{
			get { return arguments; }
		}
	}

	public class DiffReporter : IApprovalFailureReporter
	{
		private string imageDiffArgs = "/left:\"{0}\" /right:\"{1}\"";
		private string imageDiffTool = "tortoiseidiff";
		private string textDiffArguments = "/base:\"{0}\" /mine:\"{1}\"";
		private string textDiffProgram = "tortoisemerge.exe";


		private Dictionary<string, LaunchArgs> types = new Dictionary<string, LaunchArgs>();

		public DiffReporter()
		{
			var tortoise = new LaunchArgs(textDiffProgram, textDiffArguments);
			types.Add("*", tortoise);
			types.Add(".png", new LaunchArgs(imageDiffTool, imageDiffArgs));
		}

		#region IApprovalFailureReporter Members

		public void Report(string approved, string received)
		{
			Launch(GetLaunchArguments(approved, received));
		}

		public bool ApprovedWhenReported()
		{
			return false;
		}

		#endregion

		public LaunchArgs GetLaunchArguments(string approved, string received)
		{
			if (!File.Exists(approved))
				File.Create(approved);
			LaunchArgs args = GetLaunchArgumentsForFile(approved);
			return new LaunchArgs(args.Program, string.Format(args.Arguments, received, approved));
		}

		private LaunchArgs GetLaunchArgumentsForFile(string approved)
		{
			string ext = Path.GetExtension(approved);
			if (types.ContainsKey(ext))
				return types[ext];
			return types["*"];
		}

		public void Launch(LaunchArgs launchArgs)
		{
			Process.Start(launchArgs.Program, launchArgs.Arguments);
		}
	}
}