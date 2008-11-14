using CheckPoint.Extensions;
using CheckPoint.Reporters;
using NUnit.Framework;

namespace CheckPoint.Tests
{
	[TestFixture]
	public class TestWatchAfterStaticCall
	{
		[Test]
		public void WatchReturningPrimitive()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter(() => StaticClass.StaticMethodReturningPrimitive());
				StaticClass.StaticMethodReturningPrimitive();
			}
		}

		[Test]
		public void WatchReturningPrimitiveTwice()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter(() => StaticClass.StaticMethodReturningPrimitive());
				StaticClass.StaticMethodReturningPrimitive();
				StaticClass.StaticMethodReturningPrimitive();
			}
		}

		[Test]
		public void WatchReturningType()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter(() => StaticClass.StaticMethodReturningType());
				StaticClass.StaticMethodReturningType();
			}
		}

		[Test]
		public void WatchReturningTypeConvertToXML()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter(() => StaticClass.StaticMethodReturningType(), o => o.ToXML());
				StaticClass.StaticMethodReturningType();
			}
		}

		[Test]
		public void MethodWithExplicitXRay()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter("Manually Defined Checkpoint");
				StaticClass.MethodWithExplicitXRay();
			}
		}

		[Test]
		public void MethodWithExplicitXRayConverToXML()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter("Manually Defined Checkpoint Convert To XML");
				StaticClass.MethodWithExplicitXRayConvertToXML();
			}
		}
	}
}