using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest
{
	public class PingClass : IPingAble
	{
		public bool PingMethod(string uri)
		{
			bool pingable = false;
			System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();

			try
			{
				PingReply reply = p.Send(uri);
				pingable = reply.Status == IPStatus.Success;
			}
			catch (PingException)
			{
				// Discard PingExceptions and return false;
			}

			return pingable;
		}

		public List<string> GetAllPingableDestinations()
		{
			List<string> destinations = new List<string>()
			{
				"google.com",
				"facebook.com",
				"aftonbladet.se"
			};

			return destinations;
		}
	}
}
