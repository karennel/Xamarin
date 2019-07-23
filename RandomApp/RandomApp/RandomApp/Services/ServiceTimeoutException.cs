using System;

namespace RandomApp.Services
{
	public class ServiceTimeoutException : TimeoutException
	{
		public ServiceTimeoutException(string message)
			: base(message)
		{
		}
	}
}
