using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ApprovalTests.Approvers;
using ApprovalTests.Core;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;
using ApprovalUtilities.CallStack;
using ApprovalUtilities.Persistence;
using BinaryWriter = ApprovalTests.Writers.BinaryWriter;
using System.Linq;

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
			return GetReporter(new QuietReporter());
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

		public static UseReporterAttribute GetFirstFrameForAttribute(Caller caller, Type attribute)
		{
			//find the first attribute on a method
			//if empty, then find the first attribute on a class
			//if empty, then find the first attribute on an assembly
			var useReporter = FindFirstFor(caller,attribute);
			if (useReporter == null)
			{
				useReporter = (UseReporterAttribute)caller.Methods.SelectMany(m => m.DeclaringType.GetCustomAttributes(attribute, true)).FirstOrDefault();
				if (useReporter == null)
				{
					useReporter = (UseReporterAttribute)caller.Methods.SelectMany(m => m.DeclaringType.Assembly.GetCustomAttributes(attribute, true)).FirstOrDefault();
				
				}
			}
			return useReporter;

			
		}

		private static UseReporterAttribute FindFirstFor(Caller caller, Type attribute)
		{
			return (UseReporterAttribute)caller.Methods.SelectMany(m => m.GetCustomAttributes(attribute, true)).FirstOrDefault();
		
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