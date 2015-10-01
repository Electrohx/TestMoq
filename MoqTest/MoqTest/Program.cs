using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace MoqTest
{
	class Program
	{
		static void Main(string[] args)
		{
		    DependencyFactory.Container.RegisterType<IPingAble, PingClass>();

			var run = Run.Instanse.Test();
			var ListWithPingableDestinations = Run.Instanse.GetAll();
			foreach (var item in ListWithPingableDestinations)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine(String.Format("{0}", run?"Yes":"Nopes"));
			Console.ReadLine();
		}
	}
}
