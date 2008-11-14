namespace CheckPoint.Tests
{
	public class Thing
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public override string ToString()
		{
			return Description;
		}
	}
}