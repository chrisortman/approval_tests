using System;
using System.Reflection;
using TypeMock;
using TypeMock.ArrangeActAssert;

namespace CheckPoint
{
	public class Monitor
	{
		public static Sentry Calls<T>()
		{
			var fake = Isolate.Fake.Instance<T>(Members.ReturnRecursiveFakes);
			Isolate.Swap.NextInstance<T>().With(fake);
			Mock<T> mock = MockManager.GetMockOf(fake);
			var sentry = new Sentry();
			mock.MockMethodCalled += (sender, args) => sentry.Call(sender, args);
			return sentry;
		}

		private static FieldInfo[] GetAllFields(Type type)
		{
			return type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		public static Sentry Interactions(Type type)
		{
			var sentry = new Sentry();
			foreach (FieldInfo field in GetAllFields(type))
			{
				if (MockManager.IsTypeMocked(field.FieldType)) continue;
				try
				{
					WatchType(field.FieldType, sentry);
				}
				catch (TypeMockException)
				{
					// Probably trying to mock a type defined in mscorlib which we can ignore.
				}
			}

			return sentry;
		}

		private static void WatchType(Type type, Sentry sentry)
		{
			Mock mock = MockManager.MockAll(type);
			mock.MockMethodCalled += (sender, args) => sentry.Call(sender, args);

			foreach (MethodInfo methodInfo in type.GetMethods())
			{
				try
				{
					if (methodInfo.ReturnType == typeof(void))
						mock.ExpectAlways(methodInfo.Name);
					else
						mock.AlwaysReturn(methodInfo.Name, MockManager.MockObject(methodInfo.ReturnType));
				}
				catch (TypeMockException)
				{
					// Probably trying to mock a method defined in mscorlib which we can ignore.
				}
			}
		}
	}
}