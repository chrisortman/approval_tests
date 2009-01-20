using NUnit.Framework;

namespace ApprovalTests.Extensions.Tests
{
	[TestFixture]
	public class EnumerableExtensionTests
	{
		[Test]
		public void EnumerableMatchesApprovalExtension()
		{
			new[] { "abc", "123", "!@#" }.ShouldBeApproved("collection");
		}

		[Test]
		public void ApproveWithFormatter()
		{
			new[] { "one", "two", "three", "four" }.ShouldBeApproved(s => "{" + s + "}");
		}

		[Test]
		public void ApproveWithLabelAndFormatter()
		{
			new[] { "one", "two", "three", "four" }.ShouldBeApproved("Number", s => "" + s.Length);
		}
	}
}