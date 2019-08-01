using RandomApp.Controller;
using RandomApp.Services;
using RandomApp.Services.Responses;
using System.Windows.Input;

namespace RandomApp.ViewModel
{


	public class RandomFactViewModel : ViewModel
	{
		readonly IRandomFactServicesManagement _randomFactServicesManagement;

		public RandomFactViewModel
				(
					INavigator navigator,
					IRandomFactServicesManagement randomFactServicesManagement
				) : base(navigator)
		{
			_randomFactServicesManagement = randomFactServicesManagement;
		}

		private string randomfacttext;
		public string RandomFactText
		{
			get => randomfacttext;
			set => SetObservableProperty(randomfacttext, value, () => randomfacttext = value);
		}

		ICommand randomfactCommand;
		public ICommand RandomFactCommand => randomfactCommand = randomfactCommand ?? XFHelper.CreateCommand(RandomFactCommandExecute);

		async void RandomFactCommandExecute()
		{

			await _randomFactServicesManagement.RandomFact();
		}
	}
}


//	public async Task GetRandomFactAsync()
//	{

//		RandomFact randomresponse;
//		try
//		{

//			var url = "https://randomuselessfact.appspot.com/random.json?language=en";

//			HttpClient client = new HttpClient();
//			client.BaseAddress = new Uri(url);
//			var response = await client.GetAsync(client.BaseAddress);
//			response.EnsureSuccessStatusCode();
//			var JsonResult = response.Content.ReadAsStringAsync().Result;
//			randomresponse = JsonConvert.DeserializeObject<RandomFact>(JsonResult);
//			randomfacttext = randomresponse.Text;

//			//randomfact.Text = "This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. This is where the random fact will be displayed. ";
//		}
//		catch
//		{
//		}
//	}
