using NUnit.Framework;

namespace ApprovalTests.Extensions.Tests
{
	[TestFixture]
	public class StringExtensionTests
	{
		[Test]
		public void TextMatchesApprovalExtension()
		{
			"should be approved".ShouldBeApproved();
		}
	}
}
