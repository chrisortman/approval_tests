using System.IO;
using System.Windows.Forms;
using ApprovalTests.WinForms;
using NUnit.Framework;

namespace CR_ApprovalTests.Specs
{
	[TestFixture]
	public class FirstLoad
	{
		[Test]
		public void Test()
		{
			string file1 = "1.txt";
			string file2 = "2.txt";

			File.WriteAllText(file1, "1");
			File.WriteAllText(file2, "2");

			File.Delete(file2);
			File.Move(file1, file2);

			Assert.AreEqual("1", File.ReadAllText(file2));

			File.Delete(file1);
			File.Delete(file2);
		}

		[Test]
		public void Testdelete()
		{
			File.Delete("this file name will never exist.txt");
		}
	}
}