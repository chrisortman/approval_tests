using System.IO;
using System.Xml.Serialization;

namespace CheckPoint.Extensions
{
	public static class ObjectExtensions
	{
		public static string ToXML(this object o)
		{
			var w = new StringWriter();
			new XmlSerializer(o.GetType()).Serialize(w, o);
			return w.ToString();
		}
	}
}