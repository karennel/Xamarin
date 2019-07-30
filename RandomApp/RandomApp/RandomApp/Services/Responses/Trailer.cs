using Newtonsoft.Json;

namespace RandomApp.Services.Responses
{
	public class Trailer
	{
		[JsonProperty("StatusCode")]
		public int StatusCode { get; set; }

		[JsonProperty("StatusDesc")]
		public string StatusDesc { get; set; }
	}
}
