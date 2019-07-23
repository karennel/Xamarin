using RandomApp.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomApp.Model.ERR
{
	public class ERRModel
	{
		public static ERRModel Create(string error, string message = null, Exception exception = null)
		{
			return new ERRModel
			{
				Error = "error", // TranslateExtension.Format(error),

				Message = "message", //TranslateExtension.Format(message),

				Exception = exception
			};
		}

		public static ERRModel Create(Exception ex)
		{
			//return Create(FormatMessage(ex), AppResources.TryAgainLater, ex);
			return Create(FormatMessage(ex), "TryAgainLater", ex);
		}

		static string FormatMessage(Exception ex)
		{
			if (ex.GetType() == typeof(ServiceTimeoutException))
				return ex.Message;
			else
				//return string.Format(AppResources.FollowingErrorOccurredFormat, ex.GetInnermostException());
				return string.Format("FollowingErrorOccurredFormat", ex.GetInnermostException());
		}

		public string Error { get; set; }

		public string Message { get; set; }

		public Exception Exception { get; set; }
	}
}
