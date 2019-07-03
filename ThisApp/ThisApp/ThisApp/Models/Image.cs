using System;
using System.Collections.Generic;
using System.Text;

namespace ThisApp.Models
{
	public class Image
	{
		public string id { get; set; }
		public string author { get; set; }
		public int width { get; set; }
		public int height { get; set; }
		public Uri url { get; set; }
		public Uri download_url { get; set; }

	}
}
