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

		public class ImagesScrollViewModel : INotifyPropertyChanged
	{

		private string id;
		public string Id
		{
			get { return id; }
			set
			{
				id = value;
				NotifyPropertyChanged();
			}
		}

		private string author;
		public string Author
		{
			get { return author; }
			set
			{
				author = value;
				NotifyPropertyChanged();
			}
		}
		private int width;
		public int Width
		{
			get { return width; }
			set
			{
				width = value;
				NotifyPropertyChanged();
			}
		}

		private int height;
		public int Height
		{
			get { return height; }
			set
			{
				height = value;
				NotifyPropertyChanged();
			}
		}
		private Uri uri;
		public Uri Uri
		{
			get { return uri; }
			set
			{
				uri = value;
				NotifyPropertyChanged();
			}
		}

		private Uri download_uri;
		public Uri DownloadUri
		{
			get { return download_uri; }
			set
			{
				download_uri = value;
				NotifyPropertyChanged();
			}
		}

		public async Task GetImageAsync(string url)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(url);
			var response = await client.GetAsync(client.BaseAddress);
			response.EnsureSuccessStatusCode();
			var JsonResult = response.Content.ReadAsStringAsync().Result;
			Image image = JsonConvert.DeserializeObject<Image>(JsonResult);
			SetValues(image);
		}

		private void SetValues(Image image)
		{
			Uri url = image.url;
			Uri image_download = image.download_url;
			var id = image.id;
			var author = image.author;
			var width = image.width;
			var height = image.height;

			Uri = url;
			DownloadUri = image_download;
			Id = id;
			Author = author;
			Width = width;
			Height = height;
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
