using System;

namespace RandomApp.Extensions
{
	public class ServiceTimeoutException : TimeoutException
	{
		public ServiceTimeoutException(string message)
			: base(message)
		{
		}
	}
}
