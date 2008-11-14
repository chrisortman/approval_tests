using CheckPoint.Extensions;
using NUnit.Framework;

namespace CheckPoint.Tests
{
	[TestFixture]
	public class TestWatchAfterInstanceCall
	{
		[Test]
		public void WatchReturningPrimitive()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter<InstanceType>(t => t.MethodReturningPrimitive());
				var i = new InstanceType();
				i.MethodReturningPrimitive();
			}
		}

		[Test]
		public void WatchReturningPrimitiveTwice()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter<InstanceType>(t => t.MethodReturningPrimitive());
				var i = new InstanceType();
				i.MethodReturningPrimitive();
				i.MethodReturningPrimitive();
			}
		}

		[Test]
		public void WatchReturningType()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter<InstanceType>(t => t.MethodReturningType());
				var i = new InstanceType();
				i.MethodReturningType();
			}
		}

		[Test]
		public void WatchReturningTypeConvertToXML()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter<InstanceType>(t => t.MethodReturningType(), o => o.ToXML());
				var i = new InstanceType();
				i.MethodReturningType();
			}
		}

		[Test]
		public void MethodWithExplicitXRay()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter("Manually Defined Checkpoint");
				var i = new InstanceType();
				i.MethodWithExplicitXRay();
			}
		}

		[Test]
		public void MethodWithExplicitXRayConverToXML()
		{
			using (var c = new CheckPoints())
			{
				c.WatchAfter("Manually Defined Checkpoint Convert To XML");
				var i = new InstanceType();
				i.MethodWithExplicitXRayConvertToXML();
			}
		}
	}
}