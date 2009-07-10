using System;
using NUnit.Framework;
using ApprovalTests;
using TypeMock;
using System.Collections.Generic;
using System.Reflection;
using TypeMock.ArrangeActAssert;

namespace CheckPoint.Tests
{
	public class Controller
	{
		private Model model = new Model();
		private Model Model2 { get; set; }

		public Controller()
		{
			Model2 = new Model();
		}

		public void Action()
		{
			model.Method1();
			model.Method2();

			Model2.Method1();
			Model2.Method2();

			Model.StaticMethod();
		}

		public void ActionsAgainstSystemTypes()
		{
			model.ReturnsSystemType();
			model.ReturnsInt();
			var s = model.SomeProperty;

			Model2.ReturnsSystemType();
			Model2.ReturnsInt();
			var s2 = model.SomeProperty;
		}
	}
}
