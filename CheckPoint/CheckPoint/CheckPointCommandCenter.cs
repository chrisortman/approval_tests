using System.Collections.Generic;
using System.Text;

namespace CheckPoint
{
	public class CheckPointCommandCenter
	{
		private readonly SortedDictionary<string, CheckPointWatch> checkPoints = new SortedDictionary<string, CheckPointWatch>();

		public CheckPointWatch this[object o]
		{
			get { return checkPoints.ContainsKey(o.ToString()) ? checkPoints[o.ToString()] : null; }
		}

		public void Watch(CheckPointWatch checkPoint)
		{
			checkPoints.Add(checkPoint.ID.ToString(), checkPoint);
		}

		public bool IsWatching(object checkPointID)
		{
			return this[checkPointID] != null;
		}

		public string Report()
		{
			var s = new StringBuilder();

			foreach (var i in checkPoints)
			{
				var c = i.Value;
				s.AppendLine(c.ID.ToString());
				s.Append("\tCalls: ");
				s.AppendLine(c.CallCount.ToString());
			}

			return s.ToString();
		}
	}
}