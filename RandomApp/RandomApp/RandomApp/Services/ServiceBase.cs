using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RandomApp.Services
{
	public abstract class ServiceBase
	{
		protected static readonly HttpClient _httpClient;
		protected static readonly JsonSerializer _serializer;

		static ServiceBase()
		{
			_httpClient = new HttpClient();
			_httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

			_serializer = new JsonSerializer();
		}

		protected abstract string GetEndPoint();

		protected static async Task<HttpResponseMessage> ExecuteWithRetry(string methodName, Func<Task<HttpResponseMessage>> httpAction)
		{
			var retryCount = 0;

			Retry:

			try
			{
#if DEBUG
				Debug.WriteLine($">>> {methodName}: {nameof(ExecuteWithRetry)} [{retryCount}]");
#endif

				var stopWatch = Stopwatch.StartNew();

				var result = await httpAction();

				stopWatch.Stop();


#if DEBUG
				Debug.WriteLine($">>> {methodName}: {stopWatch.Elapsed.ToLogString()}");
#endif

				return result;
			}
			catch (OperationCanceledException ex)
			{
				retryCount++;

#if DEBUG
				Debug.WriteLine($">>> {methodName} timed out... retry count: {retryCount}");
#endif

				if (retryCount < 4)
					goto Retry;

				throw CreateAndTrackServiceException(methodName, innerException: ex);
			}
			catch (Exception ex)
			{
				throw CreateAndTrackServiceException(methodName, innerException: ex);
			}
		}

		protected static async Task<HttpResponseMessage> Execute(string methodName, Func<Task<HttpResponseMessage>> httpAction)
		{
			try
			{
#if DEBUG
				Debug.WriteLine($">>> {methodName}: {nameof(Execute)}");
#endif

				var stopWatch = Stopwatch.StartNew();

				var result = await httpAction();

				stopWatch.Stop();


#if DEBUG
				Debug.WriteLine($">>> {methodName}: {stopWatch.Elapsed.ToLogString()}");
#endif

				return result;
			}
			catch (Exception ex)
			{
				throw CreateAndTrackServiceException(methodName, innerException: ex);
			}
		}

		protected static Exception CreateAndTrackServiceException
			(
				string methodName,
				int code = ServiceException.GenericErrorCode,
				string description = null,
				Exception innerException = null
			)
		{
			var ex = new ServiceException(methodName, code, description, innerException);

			if (innerException == null)
				TrackException(methodName, ex);
			else
			{
				TrackException(methodName, innerException);

				if (IsTimeout(innerException))
					return new ServiceTimeoutException("The system has timed out while trying to connect.");
			}

			return ex;
		}

		// TODO: Ugly, but will do for now.
		static bool IsTimeout(Exception ex)
		{
			return
				ex.GetType() == typeof(OperationCanceledException);// ||
				//ex.Message.ContainsIgnoreCase("timed out") || // iOS
				//ex.Message.ContainsIgnoreCase("timeout");     // Droid
		}

		static void TrackException(string methodName, Exception ex)
		{
			//if (!InsightsClientStatic.Instance.Value.IsEnabled)
				return;

			//Task.Run(() => InsightsClientStatic.Instance.Value.TrackException($"ServiceException.{methodName}", ex));
		}

		protected static async Task<T> AssertResponseFast<T>(HttpResponseMessage response)
		{
			response.EnsureSuccessStatusCode();

			using (var stream = await response.Content.ReadAsStreamAsync())
			using (var reader = new StreamReader(stream))
			using (var json = new JsonTextReader(reader))
				return _serializer.Deserialize<T>(json);
		}
	}
}
