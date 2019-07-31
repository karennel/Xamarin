using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomApp.Services.Responses
{
	public class RandomAppResponse
	{
		[JsonProperty("Text")]
		public string Text { get; set; }

		[JsonProperty("PermaLink")]
		public string PermaLink { get; set; }

		[JsonProperty("SourceURL")]
		public string SourceURL { get; set; }

		[JsonProperty("Language")]
		public string Language { get; set; }

		[JsonProperty("Source")]
		public string Source { get; set; }
	}
}
