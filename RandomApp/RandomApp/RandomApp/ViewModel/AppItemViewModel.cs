using System.Windows.Input;
using Xamarin.Forms;
using RandomApp.Controller;

namespace RandomApp.ViewModel
{
	public class AppItemViewModel : ViewModel
	{

		IAppItemPageController _appitempageController;

		public AppItemViewModel
					(
							INavigator navigator,
							IAppItemPageController appitempageController
					) : base (navigator)
		{
			_appitempageController = appitempageController;
		}

		private string fullname;
		public string FullName
		{
			get => fullname;
			set => SetObservableProperty(fullname, value, () => fullname = value);
		}

		ICommand randomfactCommand;
		public ICommand RandomFactCommand => randomfactCommand = randomfactCommand ?? XFHelper.CreateCommand(RandomFactCommandExecute);

		async void RandomFactCommandExecute()
		{

			//GetRandomFactAsync();
			var navigator = ObjectFactory.Get<INavigator>();
			await navigator.PushFeature(Feature.RandomFact);
		}
	}
}

