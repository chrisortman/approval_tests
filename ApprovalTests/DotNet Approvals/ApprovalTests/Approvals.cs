using System;
using System.Collections.Generic;
using System.Diagnostics;
using ApprovalTests.Approvers;
using ApprovalTests.StackTraceParsers;
using ApprovalTests.Writers;

namespace ApprovalTests
{
    public class Approvals
    {
        private static readonly List<IApprovalFailureReporter> reporters = new List<IApprovalFailureReporter>();

        public static void Approve(string data)
        {
            Approve(new ApprovalTextWriter(data), new StackTraceNamer(), GetDefaultReporter());
        }

        public static void Approve(IApprovalWriter writer, IApprovalNamer namer, IApprovalFailureReporter reporter)
        {
            Approve(new FileApprover(writer, namer), reporter);
        }

        public static void Approve(IApprovalApprover approver, IApprovalFailureReporter reporter)
        {
            if (approver.Approve())
                approver.CleanUpAfterSucess();
            else
            {
                approver.ReportFailure(reporter);

                if (reporter.ApprovedWhenReported())
                    approver.CleanUpAfterSucess();
                else
                    approver.Fail();
            }
        }

        public static void Approve<T>(IEnumerable<T> enumerable, string label)
        {
            Approve(EnumerableWriter.Write(enumerable, label));
        }

        public static void Approve<T>(IEnumerable<T> enumerable, string label,
                                      EnumerableWriter.CustomFormatter<T> formatter)
        {
            Approve(EnumerableWriter.Write(enumerable, label, formatter));
        }

        public static void Approve<T>(IEnumerable<T> enumerable, EnumerableWriter.CustomFormatter<T> formatter)
        {
            Approve(EnumerableWriter.Write(enumerable, formatter));
        }

        public static IApprovalFailureReporter GetDefaultReporter()
        {
            IApprovalFailureReporter rep = GetReporterFromAttribute();
            if (rep != null)
            {
                return rep;
            }
            return reporters.Count == 0 ? QuietReporter.Instance : reporters[0];
        }

        private static IApprovalFailureReporter GetReporterFromAttribute()
        {
            var frame = GetFirstFrameForAttribute(new StackTrace(true).GetFrames(), typeof (UseReporterAttribute));
            if (frame != null)
            {
                return (IApprovalFailureReporter) Activator.CreateInstance((frame).reporter);
            }
            return null;
        }

        public static UseReporterAttribute GetFirstFrameForAttribute(StackFrame[] frames, Type attribute)
        {
            if (frames == null)
                return null;


            for (int i = 0; i < frames.Length; i++)
            {
                
                var attributes = frames[i].GetMethod().GetCustomAttributes(attribute, true);
                if (attributes.Length != 0)
                {
                    return (UseReporterAttribute) attributes[0];
                }

                attributes = frames[i].GetMethod().ReflectedType.GetCustomAttributes(attribute, true);
                if (attributes.Length != 0)
                {
                    return (UseReporterAttribute)attributes[0];
                }
            }

            return null;
        }


        public static void RegisterReporter(IApprovalFailureReporter reporter)
        {
            reporters.Insert(0, reporter);
            ;
        }

        public static void UnregisterReporter(IApprovalFailureReporter reporter)
        {
            reporters.Remove(reporter);
        }

        public static void UnregisterLastReporter()
        {
            reporters.RemoveAt(0);
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class UseReporterAttribute : Attribute
    {
        private Type _reporter;

        public Type reporter
        {
            set { _reporter = value; }
            get { return _reporter; }
        }
    }
}