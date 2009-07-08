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
		public Model Model2 { get; set; }

		public Controller()
		{
			Model2 = new Model();
		}

		public void Action()
		{
			model.Call1();
			model.Call2();

			Model2.Call1();
			Model2.Call2();
		}
	}
}
