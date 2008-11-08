using System.IO;
using DevExpress.CodeRush.StructuralParser;

namespace CR_ApprovalTests
{
	public class ApprovalArtifacts
	{
		public ApprovalArtifacts(LanguageElement element, string name)
		{
			Element = element;
			Name = name;
		}

		public string Name { get; set; }
		public LanguageElement Element { get; set; }

		public string Received
		{
			get
			{
				string[] files = Directory.GetFiles(GetDirectory(Name), Path.GetFileName(GetBaseName(Name, Element)) + ".received*");
				return files.Length != 0 ? files[0] : null;
			}
		}

		public string Approved
		{
			get
			{
				if (Received != null)
					return GetBaseName(Name, Element) + ".approved" + Path.GetExtension(Received);

				string[] files = Directory.GetFiles(GetDirectory(Name), Path.GetFileName(GetBaseName(Name, Element)) + ".approved*");
				return files.Length != 0 ? files[0] : null;
			}
		}

		public bool HasReceivedFile
		{
			get { return File.Exists(Received); }
		}

		public bool HasApprovedFile
		{
			get { return File.Exists(Approved); }
		}

		private static string GetDirectory(string fullName)
		{
			return Path.GetDirectoryName(fullName);
		}

		private static string GetBaseName(string fullName, LanguageElement element)
		{
			return GetDirectory(fullName) + "\\" + element.GetClass().Name + "." + element.GetParentMethod().Name;
		}
	}
}