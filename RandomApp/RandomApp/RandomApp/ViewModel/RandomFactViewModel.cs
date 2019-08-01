using RandomApp.Controller;
using RandomApp.Services;
using System.Windows.Input;

namespace RandomApp.ViewModel
{


	public class RandomFactViewModel : ViewModel
	{

		IRandomFactController _randomFactController;

		private string randomfacttext;
		public string RandomFactText
		{
			get => randomfacttext;
			set => SetObservableProperty(randomfacttext, value, () => randomfacttext = value);
		}

		public RandomFactViewModel
				(
					INavigator navigator, 
					IRandomFactController randomFactController
				) : base(navigator)
		{
			_randomFactController = randomFactController;
		}

		ICommand randomfactCommand;
		public ICommand RandomFactCommand => randomfactCommand = randomfactCommand ?? XFHelper.CreateCommand(RandomFactCommandExecute);

		/*async*/ void RandomFactCommandExecute()
		{
			_randomFactController.Test();
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
