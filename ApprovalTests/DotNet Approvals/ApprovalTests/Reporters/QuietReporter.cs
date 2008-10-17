using System.Diagnostics;

namespace ApprovalTests
{
	public class QuietReporter : IApprovalReporter
	{
		public static QuietReporter Instance = new QuietReporter();


		public bool Report(string approved, string received)
		{
			Debug.WriteLine(string.Format("move /Y \"{0}\" \"{1}\"", received, approved));
			return false;
		}
	}
}