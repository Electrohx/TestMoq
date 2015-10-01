using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest
{
	public interface IPingAble
	{
		bool PingMethod(string uri);
		List<string> GetAllPingableDestinations();
	}
}
