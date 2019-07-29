using System.Windows.Input;
using Xamarin.Forms;
using RandomApp.Services;

namespace RandomApp.ViewModel
{
	public class AppItemViewModel : ViewModel
	{

		private string fullname;
		public string FullName
		{
			get => fullname;
			set => SetObservableProperty(fullname, value, () => fullname = value);
		}

		public AppItemViewModel()
		{
		}
		

		ICommand randomfactCommand;
		public ICommand RandomFactCommand => randomfactCommand = randomfactCommand ?? XFHelper.CreateCommand(RandomFactCommandExecute);

		async void RandomFactCommandExecute()
		{
			//await _navigator.PushAsync(nameof(RandomFactPage)); ;
		}
	}
}

