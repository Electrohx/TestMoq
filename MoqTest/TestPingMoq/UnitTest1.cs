using System;
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
			IUnityContainer container = new UnityContainer();
			var mock = new Mock<IPingAble>();
			mock.Setup(m => m.PingMethod(It.IsAny<string>())).Returns(true);
			mock.Setup(o => o.GetAllPingableDestinations()).Returns(new List<string>());

			Run run = new Run(mock.Object);

			var c = container.Resolve<Run>();

			container.RegisterType<Run>();
			container.RegisterInstance<Run>(run);		//Register the instance of run


			//unity.RegisterType<Run>();
			Run runner = container.Resolve<Run>();	//Gets the registrated instance of the class Run
			
			
			
			
			
			
			
			var mixedResult = runner.MixMethods();


			Assert.AreEqual(mixedResult, true);


			var abc = run.Test();
			var emptyList = run.GetAll();

			Assert.AreEqual(emptyList.Count, 0);
		}
	}
}
