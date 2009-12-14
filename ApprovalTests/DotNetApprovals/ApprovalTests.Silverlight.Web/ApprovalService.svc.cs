using ApprovalTests.Core;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;

namespace ApprovalTests.Silverlight.Web
{
	public class ApprovalService : IApprovalService
	{
		public void Approve(string path, string testName, byte[] content)
		{
			IApprovalNamer namer = new SimpleNamer(path, testName);
			IApprovalWriter writer = new BinaryWriter(content, "png");
			IApprovalFailureReporter reporter = new ImageReporter();
			Approvals.Approve(writer, namer, reporter);
		}
	}

	public class SimpleNamer : IApprovalNamer
	{
		private readonly string path;
		private readonly string name;

		public SimpleNamer(string path, string name)
		{
			this.path = path;
			this.name = name;
		}

		public string SourcePath
		{
			get { return path; }
		}

		public string Name
		{
			get { return name; }
		}
	}
}
