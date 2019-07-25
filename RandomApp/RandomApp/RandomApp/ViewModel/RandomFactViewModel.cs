using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RandomApp.Model;
using RandomApp.Services;

namespace RandomApp.ViewModel
{
	public class RandomFactViewModel : ViewModel
	{

		private RandomFact randomfact;
		public RandomFact Randomfact
		{
			get => randomfact;
			set
			{
				randomfact.Text = value.Text;
				randomfact.PermaLink = value.PermaLink;
				randomfact.SourceURL = value.SourceURL;
				randomfact.Language = value.Language;
				randomfact.Source = value.Source;
			}
		}


		public RandomFactViewModel() { }
        
		public async Task GetRandomFactAsync(string url)
		{

			try
			{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri(url);
				var response = await client.GetAsync(client.BaseAddress);
				response.EnsureSuccessStatusCode();
				var JsonResult = response.Content.ReadAsStringAsync().Result;
				randomfact = JsonConvert.DeserializeObject<RandomFact>(JsonResult);
				//randomfact.Text = "This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. ";
				Randomfact = randomfact;
			}			
			catch 
			{

				randomfact = new RandomFact();

				randomfact.PermaLink = "not found";
				randomfact.SourceURL = "not found";
				randomfact.Language = "not found";
				randomfact.Source = "not found";
				randomfact.Text = "Unable to get any random facts at the moment." + "/\n" + "Sorry!!!!";
				Randomfact = randomfact;	
			}
		}
	}
}
