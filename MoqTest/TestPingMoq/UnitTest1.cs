using System;
using System.Net.NetworkInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqTest;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace TestPingMoq
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
            var testList = new List<String> {"test1", "test2"};

			var mock = new Mock<IPingAble>();
			mock.Setup(m => m.PingMethod(It.IsAny<string>())).Returns(true);
			mock.Setup(o => o.GetAllPingableDestinations()).Returns(testList);

		    DependencyFactory.Container.RegisterInstance<IPingAble>(mock.Object);

			var abc = Run.Instanse.Test();
			var emptyList = Run.Instanse.GetAll();

			Assert.AreEqual(abc, true);
            Assert.AreEqual(emptyList, testList);
		}
	}
}
