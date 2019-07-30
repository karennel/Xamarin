using System;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RandomApp.Services.Responses;

namespace RandomApp.Services
{
	public abstract class Service : ServiceBase
	{
		const string DecimalSeparator = ".";

		static readonly NumberFormatInfo _numberFormatInfo;
		static protected readonly JsonSerializerSettings _jsonSerializerSettings;

		static bool _isBearerSet;

		static readonly object _bearerLock = new object();

		public static void SetBearer(string token)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			_isBearerSet = true;
		}

		static Service()
		{
			_numberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = DecimalSeparator };
			_jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
		}

		readonly string _serviceName;

		protected Service()
		{
			_serviceName = GetType().Name;
		}

		protected async Task<TResponse> PostAsync<TResponse>(string methodName, string parameters = null, HttpContent content = null)
			where TResponse : IResponse
		{
			var result = await PostAsyncFast<TResponse>(methodName, parameters, content);

			AssertResult(methodName, result);

			return result;
		}

		static void AssertResult<TResponse>(string methodName, TResponse result)
			where TResponse : IResponse
		{
			if (result == null)
				throw CreateAndTrackServiceException(methodName, description: "Invalid response.");

			if (result.Trailer == null)
				throw CreateAndTrackServiceException(methodName, description: "Null response trailer.");

			if (result.Trailer.StatusCode == 0) // Success
				return;

			throw CreateAndTrackServiceException(methodName, result.Trailer.StatusCode, result.Trailer.StatusDesc);
		}

		protected async Task<string> PostAsync(string methodName, string parameters = null, HttpContent content = null)
		{
			//AssertBearer();

			var uriString = FormatUriString(methodName, parameters);

			var response = await Execute(methodName, () => _httpClient.PostAsync(uriString, content));

			return await AssertResponse(response);
		}

		protected async Task<TResponse> PostAsyncFast<TResponse>(string methodName, string parameters = null, HttpContent content = null)
			where TResponse : IResponse
		{
			//AssertBearer();

			var uriString = FormatUriString(methodName, parameters);

			var response = await Execute(methodName, () => _httpClient.PostAsync(uriString, content));

			return await AssertResponseFast<TResponse>(response);
		}

		//void AssertBearer()
		//{
		//	if (_isBearerSet)
		//		return;

		//	lock (_bearerLock)
		//	{
		//		if (_isBearerSet)
		//			return;

		//		SetBearerToken();
		//	}
		//}

//		void SetBearerToken()
//		{
//			try
//			{
//				var loginService = ObjectFactory.Get<ILoginService>();
//				var token = Task.Run(() => loginService.Login()).Result;
//				SetBearer(token);
//			}
//#if DEBUG
//			catch (Exception ex)
//			{
//				System.Diagnostics.Debug.WriteLine($"!!! {nameof(SetBearerToken)}: {ex.GetInnermostException()}");
//			}
//#else
//      catch { }
//#endif
//		}

		static async Task<string> AssertResponse(HttpResponseMessage response)
		{
			var resultString = await response.Content.ReadAsStringAsync();

			if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.Accepted)
				return resultString;

			if (string.IsNullOrEmpty(resultString))
				resultString = response.ReasonPhrase;

			throw new Exception(resultString);
		}

		string FormatUriString(string methodName, string parameters)
		{
			var uriString = $"{GetEndPoint()}/{_serviceName}/{methodName}";

			var result = string.IsNullOrEmpty(parameters) ? uriString : $"{uriString}?{EscapeParameters(parameters)}";

#if DEBUG
			System.Diagnostics.Debug.WriteLine($"@@@ {result}");
#endif

			return result;
		}

		static string EscapeParameters(string value)
		{
			return Uri.EscapeUriString(value).Replace("#", "%23");
		}

		protected async Task<TResponse> GetAsync<TResponse>(string methodName, string parameters = null)
			where TResponse : IResponse
		{
			var result = await GetAsyncFast<TResponse>(methodName, parameters);

			AssertResult(methodName, result);

			return result;
		}

		protected async Task<string> GetAsync(string methodName, string parameters)
		{
			//AssertBearer();

			var uriString = FormatUriString(methodName, parameters);

			var response = await ExecuteWithRetry(methodName, () => _httpClient.GetAsync(uriString));

			return await AssertResponse(response);
		}

		protected async Task<TResponse> GetAsyncFast<TResponse>(string methodName, string parameters)
			where TResponse : IResponse
		{
			//AssertBearer();

			var uriString = FormatUriString(methodName, parameters);

			var response = await ExecuteWithRetry(methodName, () => _httpClient.GetAsync(uriString));

			return await AssertResponseFast<TResponse>(response);
		}

		protected async Task<TResponse> PutAsync<TResponse>(string methodName, string parameters = null, HttpContent content = null)
			where TResponse : IResponse
		{
			var result = await PutAsyncFast<TResponse>(methodName, parameters, content);

			AssertResult(methodName, result);

			return result;
		}

		protected async Task<string> PutAsync(string methodName, string parameters = null, HttpContent content = null)
		{
			//AssertBearer();

			var uriString = FormatUriString(methodName, parameters);

			var response = await Execute(methodName, () => _httpClient.PutAsync(uriString, content));

			return await AssertResponse(response);
		}

		protected async Task<TResponse> PutAsyncFast<TResponse>(string methodName, string parameters = null, HttpContent content = null)
			where TResponse : IResponse
		{
			//AssertBearer();

			var uriString = FormatUriString(methodName, parameters);

			var response = await Execute(methodName, () => _httpClient.PutAsync(uriString, content));

			return await AssertResponseFast<TResponse>(response);
		}

		protected async Task<TResponse> DeleteAsync<TResponse>(string methodName, string parameters = null)
			where TResponse : IResponse
		{
			var result = await DeleteAsyncFast<TResponse>(methodName, parameters);

			AssertResult(methodName, result);

			return result;
		}

		protected async Task<string> DeleteAsync(string methodName, string parameters = null)
		{
			//AssertBearer();

			var uriString = FormatUriString(methodName, parameters);

			var response = await Execute(methodName, () => _httpClient.DeleteAsync(uriString));

			return await AssertResponse(response);
		}

		protected async Task<TResponse> DeleteAsyncFast<TResponse>(string methodName, string parameters = null)
			where TResponse : IResponse
		{
			//AssertBearer();

			var uriString = FormatUriString(methodName, parameters);

			var response = await Execute(methodName, () => _httpClient.DeleteAsync(uriString));

			return await AssertResponseFast<TResponse>(response);
		}

		protected static string FormatDate(DateTime date)
		{
			const string DateFormat = "yyyy-MM-dd";

			return date.ToString(DateFormat);
		}

		protected static string FormatDouble(double value)
		{
			return value.ToString(_numberFormatInfo);
		}
	}
}
