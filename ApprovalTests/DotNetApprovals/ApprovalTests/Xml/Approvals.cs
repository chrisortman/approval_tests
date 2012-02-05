using System;

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
			XmlApprovals.VerifyText(text, fileExtensionWithoutDot, safely);
		}


		/// <summary>
		/// 	Throws exception if Xml is incorrectly formatted
		/// </summary>
		public static void ApproveXmlStrict(string xml)
		{
			XmlApprovals.VerifyXml(xml);
		}
	}
}