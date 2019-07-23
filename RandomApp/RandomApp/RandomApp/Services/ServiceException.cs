using System;

namespace RandomApp.Services
{
	public class ServiceException : Exception
	{
		public const int GenericErrorCode = 99999;

		public string MethodName { get; private set; }

		public int Code { get; private set; }

		public string Description { get; private set; }

		public ServiceException
			(
				string methodName,
				int code = GenericErrorCode,
				string description = null,
				Exception innerException = null
			)
			: base(FormatMessage(methodName, code, description), innerException)
		{
			MethodName = methodName;

			Code = code;

			Description = description;

#if DEBUG
			System.Diagnostics.Debug.WriteLine($"*** Service exception: {ToString()}");
#endif
		}

		static string FormatMessage(string methodName, int code, string description)
		{
			return description == null ? $"Error calling {methodName}! {code}" : $"Error calling {methodName}! {code}: {description}";
		}

		public override string ToString()
		{
			return Message;
		}
	}
}
