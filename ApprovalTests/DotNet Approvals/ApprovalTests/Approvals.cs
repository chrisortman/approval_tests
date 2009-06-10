using System;
using System.Collections.Generic;
using System.Diagnostics;
using ApprovalTests.Approvers;
using ApprovalTests.Core;
using ApprovalTests.Core;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;

namespace ApprovalTests
{
	public class Approvals
	{
		#region Text

		/// <summary>
		/// Approves the provided text. Produces a .txt file as an artifact.
		/// </summary>
		/// <param name="text">Text to approve.</param>
		public static void Approve(string text)
		{
			Approve(new ApprovalTextWriter(text), new UnitTestFrameworkNamer(), GetReporter());
		}

		#endregion

		#region Enumerable

		public static void Approve<T>(IEnumerable<T> enumerable)
		{
			Approve(EnumerableWriter.Write(enumerable));
		}

		public static void Approve<T>(IEnumerable<T> enumerable, string label)
		{
			Approve(EnumerableWriter.Write(enumerable, label));
		}

		public static void Approve<T>(IEnumerable<T> enumerable, string label, EnumerableWriter.CustomFormatter<T> formatter)
		{
			Approve(EnumerableWriter.Write(enumerable, label, formatter));
		}

		public static void Approve<T>(IEnumerable<T> enumerable, EnumerableWriter.CustomFormatter<T> formatter)
		{
			Approve(EnumerableWriter.Write(enumerable, formatter));
		}

		#endregion

		public static void Approve(IApprovalWriter writer, IApprovalNamer namer, IApprovalFailureReporter reporter)
		{
			ApprovalTests.Core.Approvals.Approve(new FileApprover(writer, namer), reporter);
		}

		public static IApprovalFailureReporter GetReporter()
		{
			return GetReporterFromAttribute() ?? new QuietReporter();
		}

		private static IApprovalFailureReporter GetReporterFromAttribute()
		{
			UseReporterAttribute frame = GetFirstFrameForAttribute(new StackTrace(true).GetFrames(),
			                                                       typeof (UseReporterAttribute));
			if (frame != null)
			{
				return (IApprovalFailureReporter) Activator.CreateInstance((frame).Reporter);
			}
			return null;
		}

		public static UseReporterAttribute GetFirstFrameForAttribute(StackFrame[] frames, Type attribute)
		{
			if (frames == null)
				return null;

			for (int i = 0; i < frames.Length; i++)
			{
				object[] attributes = frames[i].GetMethod().GetCustomAttributes(attribute, true);
				if (attributes.Length != 0)
				{
					return (UseReporterAttribute) attributes[0];
				}

				attributes = frames[i].GetMethod().DeclaringType.GetCustomAttributes(attribute, true);
				if (attributes.Length != 0)
				{
					return (UseReporterAttribute) attributes[0];
				}
			}

			return null;
		}
	}

	[AttributeUsage(AttributeTargets.All)]
	public class UseReporterAttribute : Attribute
	{
		public Type Reporter { set; get; }
	}
}