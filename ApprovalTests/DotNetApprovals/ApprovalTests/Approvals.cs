using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ApprovalTests.Approvers;
using ApprovalTests.Core;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;
using ApprovalUtilities.CallStack;
using ApprovalUtilities.Persistence;
using BinaryWriter = ApprovalTests.Writers.BinaryWriter;

namespace ApprovalTests
{
	public class Approvals
	{
		#region Text

		public static void Approve(string text)
		{
			Approve(new ApprovalTextWriter(text));
		}

		public static IApprovalNamer GetDefaultNamer()
		{
			return new UnitTestFrameworkNamer();
		}

		public static void Approve(object text)
		{
			Approve(new ApprovalTextWriter("" + text));
		}

		#endregion

		#region Enumerable

		public static void Approve<T>(IEnumerable<T> enumerable, string label)
		{
			Approve(EnumerableWriter.Write(enumerable, label));
		}

		public static void Approve<T>(IEnumerable<T> enumerable, string label,
		                              EnumerableWriter.CustomFormatter<T> formatter)
		{
			Approve(EnumerableWriter.Write(enumerable, label, formatter));
		}

		public static void Approve<T>(String header, IEnumerable<T> enumerable, EnumerableWriter.CustomFormatter<T> formatter)
		{
			Approve(header + "\r\n\r\n" + EnumerableWriter.Write(enumerable, formatter));
		}

		public static void Approve<T>(IEnumerable<T> enumerable, EnumerableWriter.CustomFormatter<T> formatter)
		{
			Approve(EnumerableWriter.Write(enumerable, formatter));
		}

		public static void ApproveBinaryFile(byte[] bytes, string fileExtensionWithoutDot)
		{
			Approve(new BinaryWriter(bytes, fileExtensionWithoutDot));
		}

		public static void ApproveHtml(string html)
		{
			Html.Approvals.ApproveHtml(html);
		}

		public static void ApproveXml(string xml)
		{
			Xml.Approvals.ApproveXml(xml);
		}

		#endregion

		public static void Approve(IApprovalWriter writer, IApprovalNamer namer, IApprovalFailureReporter reporter)
		{
			Core.Approvals.Approve(new FileApprover(writer, namer), reporter);
		}

		public static IApprovalFailureReporter GetReporter()
		{
			return GetReporter(new IntroductionReporter());
		}

		public static IApprovalFailureReporter GetReporter(IApprovalFailureReporter defaultIfNotFound)
		{
			return GetReporterFromAttribute() ?? defaultIfNotFound;
		}

		private static IApprovalFailureReporter GetReporterFromAttribute()
		{
			var useReporter = GetFirstFrameForAttribute(new Caller(), typeof (UseReporterAttribute));
			return useReporter != null ? useReporter.Reporter : null;
		}

		private static UseReporterAttribute GetFirstFrameForAttribute(Caller caller, Type attribute)
		{
			var attributeExtractors = new Func<MethodBase, Object[]>[]
			                          	{
			                          		m => m.GetCustomAttributes(attribute, true),
			                          		m => m.DeclaringType.GetCustomAttributes(attribute, true),
			                          		m => m.DeclaringType.Assembly.GetCustomAttributes(attribute, true)
			                          	};
			foreach (var attributeExtractor in attributeExtractors)
			{
				foreach (var method in caller.Methods)
				{
					var useReporters = attributeExtractor(method);
					if (useReporters.Length != 0)
					{
						return useReporters.First() as UseReporterAttribute;
					}
				}
			}
			return null;
		}

		public static void Approve(IExecutableQuery query)
		{
			Approve(new ApprovalTextWriter(query.GetQuery()), GetDefaultNamer(),
			        new ExecutableQueryFailure(query, GetReporter()));
		}

		public static void Approve(IApprovalWriter writer)
		{
			Approve(writer, GetDefaultNamer(), GetReporter());
		}

		public static void ApproveFile(string file)
		{
			Approve(new ExistingFileWriter(file));
		}

		public static void Approve(FileInfo file)
		{
			ApproveFile(file.FullName);
		}
	}
}