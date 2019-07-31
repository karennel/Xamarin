using System.Windows.Input;
using RandomApp.Services;

namespace RandomApp.ViewModel
{
	public class RandomFactViewModel : ViewModel
	{

		IRandomFactManager _randomFactManager;

		private string randomfacttext;
		public string RandomFactText
		{
			get => randomfacttext;
			set => SetObservableProperty(randomfacttext, value, () => randomfacttext = value);
		}

		public RandomFactViewModel
			(
				INavigator navigator,
				IRandomFactManager randomFactManager
			) : base(navigator)
		{
			_randomFactManager = randomFactManager;
		}

		ICommand randomfactCommand;
		public ICommand RandomFactCommand => randomfactCommand = randomfactCommand ?? XFHelper.CreateCommand(RandomFactCommandExecute);

		async void RandomFactCommandExecute()
		{
			await _randomFactManager.RandomFact();
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
