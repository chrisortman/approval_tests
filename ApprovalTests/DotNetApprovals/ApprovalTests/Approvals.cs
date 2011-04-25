using System;
using System.Collections.Generic;
using System.Diagnostics;
using ApprovalTests.Approvers;
using ApprovalTests.Core;
using ApprovalTests.Namers;
using ApprovalTests.Persistence;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;

namespace ApprovalTests
{
    public class Approvals
    {
        #region Text

        public static void Approve(string text)
        {
            Approve(new ApprovalTextWriter(text), GetDefaultNamer(), GetReporter());
        }

    	public static IApprovalNamer GetDefaultNamer()
    	{
    		return new UnitTestFrameworkNamer();
    	}

    	public static void Approve(object text)
        {
            Approve(new ApprovalTextWriter("" + text), GetDefaultNamer(), GetReporter());
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
            UseReporterAttribute frame = GetFirstFrameForAttribute(
                new StackTrace(true).GetFrames(),
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

        public static void Approve(IExecutableQuery query)
        {
            Approve(new ApprovalTextWriter(query.GetQuery()), GetDefaultNamer(),
                    new ExecutableQueryFailure(query));
        }
    }
}