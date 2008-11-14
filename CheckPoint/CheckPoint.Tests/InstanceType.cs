using CheckPoint.Extensions;

namespace CheckPoint.Tests
{
	public class InstanceType
	{
		public bool MethodReturningPrimitive()
		{
			return StaticClass.StaticMethodReturningPrimitive();
		}

		public Thing MethodReturningType()
		{
			return StaticClass.StaticMethodReturningType();
		}

		public bool MethodWithExplicitXRay()
		{
			return StaticClass.MethodWithExplicitXRay();
		}

		public bool MethodWithExplicitXRayConvertToXML()
		{
			return StaticClass.MethodWithExplicitXRayConvertToXML();
		}
	}
}