using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApiReporter
{
	public class ApiNamespaceReporter
	{
		private readonly Assembly asm;

		public ApiNamespaceReporter(Type t)
		{
			asm = Assembly.GetAssembly(t);
		}

		public Type[] FindClassesForNamespace(string nameSpace)
		{
			List<Type> returnList = new List<Type>();
			foreach (Type type in asm.GetTypes())
			{
				if (type.Namespace.StartsWith(nameSpace))
					returnList.Add(type);
			}
			returnList.Sort((x, y) => FormatClassName(x).CompareTo(FormatClassName(y)));
			return returnList.ToArray();
			;
		}

		public string GenerateReport(string nameSpace)
		{
			Type[] types = FindClassesForNamespace(nameSpace);
			StringBuilder builder = new StringBuilder();
			foreach (Type t in types)
				ReportType(t, builder);
			return builder.ToString();
		}

		private void ReportType(Type t, StringBuilder builder)
		{
			builder.AppendLine(FormatClassName(t));
			MethodInfo[] methods = t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
			Array.Sort(methods, (x, y) => FormatMethodName(x.Name).CompareTo(FormatMethodName(y.Name)));
			foreach (MethodInfo m in methods)
				ReportMethod(m, builder);
		}

		public static string FormatClassName(Type t)
		{
			string name = t.Name;

			if (t.IsGenericType)
				name = name.Substring(0, name.IndexOf('`'));
			
			if (t.IsInterface && name.StartsWith("I"))
				name = name.Substring(1);
			
			return name;
		}

		private void ReportMethod(MethodInfo m, StringBuilder builder)
		{
			builder.Append("\t" + FormatMethodName(m.Name));
			builder.Append("(");
			foreach (ParameterInfo p in m.GetParameters())
				ReportParameter(p, builder);
			if (m.GetParameters().Length != 0)
				builder.Remove(builder.Length - 1, 1);
			builder.AppendLine(")");
		}

		private string FormatMethodName(string name)
		{
			name = name.Replace("get_", "Get");
			name = name.Replace("set_", "Set");
			return name;
		}

		private void ReportParameter(ParameterInfo p, StringBuilder builder)
		{
			builder.Append(FormatClassName(p.ParameterType));
			builder.Append(",");
		}
	}
}