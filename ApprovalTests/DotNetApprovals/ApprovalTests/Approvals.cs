using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ApprovalTests.Approvers;
using ApprovalTests.Core;
using ApprovalTests.Html;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;
using ApprovalTests.Xml;
using ApprovalUtilities.CallStack;
using ApprovalUtilities.Persistence;
using BinaryWriter = ApprovalTests.Writers.BinaryWriter;

namespace ApprovalTests
{
	public class Approvals
	{
		#region Obsolete
		[Obsolete("Use Verify instead")]
		public static void Approve(string text)
		{
			Verify(text);
		}

		[Obsolete("Use Verify instead")]
		public static void Approve(object text)
		{
			Verify(text);
		}

		[Obsolete("Use VerifyAll instead")]
		public static void Approve<T>(IEnumerable<T> enumerable, string label)
		{
			VerifyAll(enumerable, label);
		}

		[Obsolete("Use VerifyAll instead")]
		public static void Approve<T>(IEnumerable<T> enumerable, string label,
																	EnumerableWriter.CustomFormatter<T> formatter)
		{
			VerifyAll(enumerable, label, formatter);
		}

		[Obsolete("Use VerifyAll instead")]
		public static void Approve<T>(String header, IEnumerable<T> enumerable, EnumerableWriter.CustomFormatter<T> formatter)
		{
			VerifyAll(header, enumerable, formatter);
		}

		[Obsolete("Use VerifyAll instead")]
		public static void Approve<T>(IEnumerable<T> enumerable, EnumerableWriter.CustomFormatter<T> formatter)
		{
			VerifyAll(enumerable, formatter);
		}

		[Obsolete("Use VerifyBinaryFile instead")]
		public static void ApproveBinaryFile(byte[] bytes, string fileExtensionWithoutDot)
		{
			VerifyBinaryFile(bytes, fileExtensionWithoutDot);
		}

		[Obsolete("Use VerifyHtml instead")]
		public static void ApproveHtml(string html)
		{
			VerifyHtml(html);
		}

		[Obsolete("Use VerifyXml instead")]
		public static void ApproveXml(string xml)
		{
			VerifyXml(xml);
		}

		[Obsolete("Use Verify instead")]
		public static void Approve(IApprovalWriter writer, IApprovalNamer namer, IApprovalFailureReporter reporter)
		{
			Verify(writer, namer, reporter);
		}

		[Obsolete("Use Verify instead")]
		public static void Approve(IExecutableQuery query)
		{
			Verify(query);
		}
		[Obsolete("Use Verify instead")]
		public static void Approve(IApprovalWriter writer)
		{
			Verify(writer);
		}
		[Obsolete("Use VerifyFile instead")]
		public static void ApproveFile(string file)
		{
			VerifyFile(file);
		}
		[Obsolete("Use Verify instead")]
		public static void Approve(FileInfo file)
		{
			Verify(file);
		}
		#endregion
		#region Text
		public static void Verify(string text)
		{
			Verify(new ApprovalTextWriter(text));
		}

		public static IApprovalNamer GetDefaultNamer()
		{
			return new UnitTestFrameworkNamer();
		}

		public static void Verify(object text)
		{
			Verify(new ApprovalTextWriter("" + text));
		}
		#endregion
		#region Enumerable
		public static void VerifyAll<T>(String header, IEnumerable<T> enumerable, string label)
		{
			Verify(header + "\r\n\r\n" + EnumerableWriter.Write(enumerable, label));
		}

		public static void VerifyAll<T>(IEnumerable<T> enumerable, string label)
		{
			Verify(EnumerableWriter.Write(enumerable, label));
		}

		public static void VerifyAll<T>(IEnumerable<T> enumerable, string label,
																		EnumerableWriter.CustomFormatter<T> formatter)
		{
			Verify(EnumerableWriter.Write(enumerable, label, formatter));
		}

		public static void VerifyAll<T>(String header, IEnumerable<T> enumerable,
																		EnumerableWriter.CustomFormatter<T> formatter)
		{
			Verify(header + "\r\n\r\n" + EnumerableWriter.Write(enumerable, formatter));
		}

		public static void VerifyAll<T>(IEnumerable<T> enumerable, EnumerableWriter.CustomFormatter<T> formatter)
		{
			Verify(EnumerableWriter.Write(enumerable, formatter));
		}

		public static void VerifyBinaryFile(byte[] bytes, string fileExtensionWithoutDot)
		{
			Verify(new BinaryWriter(bytes, fileExtensionWithoutDot));
		}

		public static void VerifyHtml(string html)
		{
			HtmlApprovals.VerifyHtml(html);
		}

		public static void VerifyXml(string xml)
		{
			XmlApprovals.VerifyXml(xml);
		}
		#endregion
		public static void Verify(IApprovalWriter writer, IApprovalNamer namer, IApprovalFailureReporter reporter)
		{
			Core.Approvals.Verify(new FileApprover(writer, namer), reporter);
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
			var useReporter = GetFirstFrameForAttribute(new Caller(), typeof(UseReporterAttribute));
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

		public static void Verify(IExecutableQuery query)
		{
			Verify(new ApprovalTextWriter(query.GetQuery()), GetDefaultNamer(),
						 new ExecutableQueryFailure(query, GetReporter()));
		}

		public static void Verify(IApprovalWriter writer)
		{
			Verify(writer, GetDefaultNamer(), GetReporter());
		}

		public static void VerifyFile(string file)
		{
			Verify(new ExistingFileWriter(file));
		}

		public static void Verify(FileInfo file)
		{
			VerifyFile(file.FullName);
		}
		public static void VerifyWithCallback(object text, Action<string> callBackOnFailure)
		{
			Verify(new ExecutableLambda("" + text, callBackOnFailure));
		}
		public static void VerifyWithCallback(object text, Func<string, string> callBackOnFailure)
		{
			Verify(new ExecutableLambda("" + text, callBackOnFailure));
		}
	}
}