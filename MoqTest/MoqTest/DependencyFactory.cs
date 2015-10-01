using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MoqTest
{
	public class DependencyFactory
	{
		private static IUnityContainer _container;

		public static IUnityContainer Container
		{
			get
			{
				return _container;
			}
			private set
			{
				_container = value;
			}
		}


		static DependencyFactory()
		{
			IUnityContainer container = new UnityContainer();


			var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
			if (section != null)
			{
				section.Configure(container);
			}
			_container = container;
		}

		public static T Resolve<T>()
		{
			T ret = default(T);

			if (Container.IsRegistered(typeof(T)))
			{
				ret = Container.Resolve<T>();
			}

			return ret;
		}
	}
}
