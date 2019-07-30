using Newtonsoft.Json;

namespace RandomApp.Services.Responses
{
	public interface IResponse
	{
		Trailer Trailer { get; set; }
	}

	public class Response : IResponse
	{
		[JsonProperty("Trailer")]
		public Trailer Trailer { get; set; }
	}
}
