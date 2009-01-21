using ApprovalTests.Extensions.WinForms;
using Machine.Specifications;
using NUnit.Framework;

namespace CR_ApprovalTests.Tests
{
	[TestFixture]
	public class aaaa
	{
		[Test]
		public void aaaaaa()
		{
			Assert.AreEqual("aaa", "aaa");

			var options = new Options();
			options.ShouldBeApproved();
		}
	}


	[Subject(typeof(Options))]
	public class when_displaying_defaults
	{
		Establish context =()=> options = new Options();
        It should_display_them =()=> options.ShouldBeApproved();

		static Options options;
	}
}