using System;

namespace CheckPoint.Extensions
{
	public static class CheckPointExtensions
	{
		public static T XRay<T>(this T o, object id)
		{
			CheckPoints.Approve(o, id);
			return o;
		}

		public static T XRay<T>(this T o, object id, Func<object, string> approveFunction)
		{
			CheckPoints.Approve(approveFunction.Invoke(o), id);
			return o;
		}
	}
}