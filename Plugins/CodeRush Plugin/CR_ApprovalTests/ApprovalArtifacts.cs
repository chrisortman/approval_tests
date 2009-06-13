using System.IO;
using DevExpress.CodeRush.StructuralParser;

namespace CR_ApprovalTests
{
	public enum TestStatus
	{
		NeverRun,
		NeverApproved,
		Approved,
		Failed
	}

	public class ApprovalArtifacts
	{
		public ApprovalArtifacts(Method method)
		{
			MethodName = method.Name;
			ClassName = method.Parent.Name;
			SourcePath = Path.GetDirectoryName(method.FileNode.FilePath);
		}

		public string ClassName { get; private set; }
		public string MethodName { get; private set; }
		public string SourcePath { get; set; }

		public string Received
		{
			get
			{
				string[] files = Directory.GetFiles(SourcePath, Path.GetFileName(GetBaseName()) + ".received*");
				return files.Length != 0 ? files[0] : null;
			}
		}

		public string Approved
		{
			get
			{
				string[] files = Directory.GetFiles(SourcePath, Path.GetFileName(GetBaseName()) + ".approved*");
				return files.Length != 0 ? files[0] : GetBaseName() + ".approved";
			}
		}

		public TestStatus TestStatus
		{
			get { return GetTestStatusFor(HasReceivedFile(), HasApprovalFile()); }
		}

		public bool HasReceivedFile()
		{
			return File.Exists(Received);
		}

		public bool HasApprovalFile()
		{
			return File.Exists(Approved);
		}

		private TestStatus GetTestStatusFor(bool received, bool approved)
		{
			if (approved)
				return received ? TestStatus.Failed : TestStatus.Approved;
			else
				return received ? TestStatus.NeverApproved : TestStatus.NeverRun;
		}

		private string GetBaseName()
		{
			return SourcePath + "\\" + ClassName + "." + MethodName;
		}
	}
}