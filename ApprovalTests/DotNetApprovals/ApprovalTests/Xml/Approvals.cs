using System;
using ApprovalUtilities.Xml;

namespace ApprovalTests.Xml
{
	[Obsolete("Use XmlApprovals instead")]
	public class Approvals
	{
		public static void ApproveXml(string xml)
		{
			XmlApprovals.VerifyXml(xml);
		}

		public static void ApproveText(string text, string fileExtensionWithoutDot, bool safely)
		{
			XmlApprovals.VerifyText(text,fileExtensionWithoutDot,safely);
		}


		/// <summary>
		/// 	Throws exception if Xml is incorrectly formatted
		/// </summary>
		public static void ApproveXmlStrict(string xml)
		{
			XmlApprovals.VerifyXml(xml);
		}
	}

	public class XmlApprovals
	{
		public static void VerifyXml(string xml)
		{
			VerifyText(xml, "xml", true);
		}

		public static void VerifyText(string text, string fileExtensionWithoutDot, bool safely)
		{
			text = XmlUtils.FormatXml(text, safe: safely);
			ApprovalTests.Approvals.Approve(new ApprovalTextWriter(text, fileExtensionWithoutDot));
		}


		/// <summary>
		/// 	Throws exception if Xml is incorrectly formatted
		/// </summary>
		public static void VerifyXmlStrict(string xml)
		{
			VerifyText(xml, "xml", false);
		}
	}
}