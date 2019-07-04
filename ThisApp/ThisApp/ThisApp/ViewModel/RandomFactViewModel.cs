using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ThisApp.Models;

namespace ThisApp.ViewModel
{
	public class RandomFactViewModel : INotifyPropertyChanged
	{
	
		private string text;
		public string Text
		{
			get { return text; }
			set
			{
				text = value;
				NotifyPropertyChanged();
			}
		}

		private string permalink;
		public string PermaLink
		{
			get { return permalink; }
			set
			{
				permalink = value;
				NotifyPropertyChanged();
			}
		}

		private string sourceurl;
		public string SourceURL
		{
			get { return sourceurl; }
			set
			{
				sourceurl = value;
				NotifyPropertyChanged();
			}
		}

		private string language;
		public string Language
		{
			get { return language; }
			set
			{
				language = value;
				NotifyPropertyChanged();
			}
		}

		private string source;
		public string Source
		{
			get { return source; }
			set
			{
				source = value;
				NotifyPropertyChanged();
			}
		}

		public async Task GetRandomFactAsync(string url) 
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(url);
			var response = await client.GetAsync(client.BaseAddress);
			response.EnsureSuccessStatusCode();
			var JsonResult = response.Content.ReadAsStringAsync().Result;
			RandomFact randomfact = JsonConvert.DeserializeObject<RandomFact>(JsonResult);
			SetValues(randomfact);
		}

		private void SetValues(RandomFact randomfact)
		{
			var text = randomfact.text;
			var permalink = randomfact.permalink;
			var source_url = randomfact.source_url;
			var language = randomfact.language;
			var source = randomfact.source;

			Text = text;
			PermaLink = permalink;
			SourceURL = source_url;
			Language = language;
			Source = source;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")  
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
