using System;
using System.Collections.Generic;
using System.Text;

namespace RandomApp
{
	public static class ConfigStatic
	{
		public static Lazy<IBateleurConfig> Instance = new Lazy<IBateleurConfig>(() => ObjectFactory.Get<IBateleurConfig>());
	}
}
