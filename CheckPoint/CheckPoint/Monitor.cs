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
			Isolate.Fake.StaticMethods(typeof (T));
			var fake = Isolate.Fake.Instance<T>(Members.ReturnRecursiveFakes);
			Isolate.Swap.NextInstance<T>().With(fake);
			Mock<T> mock = MockManager.GetMockOf(fake);
			var sentry = new Sentry();
			mock.MockMethodCalled += sentry.Call;
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
				//if (MockManager.IsTypeMocked(field.FieldType)) continue;
				try
				{
					WatchType(field.FieldType, sentry, field.Name);
				}
				catch (TypeMockException)
				{
					// Probably tried mocking a type defined in mscorlib which we can ignore.
				}
			}

			return sentry;
		}

		private static void WatchType(Type type, Sentry sentry, string fieldName)
		{
			Mock mock = MockManager.Mock(type);
			mock.MockMethodCalled += (sender, args) => sentry.Call(sender, args, fieldName);

			foreach (MethodInfo methodInfo in type.GetMethods())
			{
				try
				{
					if (methodInfo.ReturnType == typeof (void))
						mock.ExpectAlways(methodInfo.Name);
					else
					{
						if (methodInfo.ReturnType.IsPrimitive)
							mock.AlwaysReturn(methodInfo.Name, 0);
						else
							mock.AlwaysReturn(methodInfo.Name, MockManager.MockObject(methodInfo.ReturnType));
					}
				}
				catch (TypeMockException)
				{
					try
					{
						mock.AlwaysReturn(methodInfo.Name, null);
					}
					catch (TypeMockException)
					{
					}
				}
			}
		}
	}
}