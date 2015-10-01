using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest
{
	public class Run
	{
		public static IPingAble p;
		private static Run instance;


		public static Run Instanse 
		{
			get
			{
				if (instance == null)
				{
					instance = new Run();
				}
				return instance;
			}
		}

		private Run():this(DependencyFactory.Resolve<PingClass>())
		{
 
		}

		public Run(IPingAble Ipingable)
		{
			p = Ipingable;
		}

		public bool Test()
		{
			return p.PingMethod("google.com");
		}

		public List<string> GetAll()
		{
			return p.GetAllPingableDestinations();
		}

		public bool MixMethods()
		{
			if (GetAll().Count == 0)
			{
				if (Test())
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}
}
