using CheckPoint.Extensions;

namespace CheckPoint.Tests
{
	public static class StaticClass
	{
		public static bool StaticMethodReturningPrimitive()
		{
			return false;
		}

		public static Thing StaticMethodReturningType()
		{
			return new Thing
			{
				Name = "Thing Name",
				Description = "Thing Description"
			};
		}

		public static bool MethodWithExplicitXRay()
		{
			new Thing
			{
				Name = "Data",
				Description = "Inside Method"
			}.XRay("Manually Defined Checkpoint");
			return StaticMethodReturningPrimitive();
		}

		public static bool MethodWithExplicitXRayConvertToXML()
		{
			new Thing
			{
				Name = "Data",
				Description = "Inside Method"
			}.XRay("Manually Defined Checkpoint Convert To XML", o => o.ToXML());
			return StaticMethodReturningPrimitive();
		}
	}
}