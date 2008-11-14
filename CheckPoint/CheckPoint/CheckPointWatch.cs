namespace CheckPoint
{
	public class CheckPointWatch
	{
		private int callCount;
		private readonly object id;

		public object ID
		{
			get { return id; }
		}

		public CheckPointWatch(object checkPointID)
		{
			id = checkPointID;
		}

		public void Called()
		{
			callCount++;
		}

		public object CallCount
		{
			get { return callCount; }
		}
	}
}