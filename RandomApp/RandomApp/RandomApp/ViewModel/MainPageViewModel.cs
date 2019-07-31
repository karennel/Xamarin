using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

using RandomApp.Views;

namespace RandomApp.ViewModel
{
	public class MainPageViewModel : ViewModel
	{

		private string firstname;
		public string FirstName
		{
			get => firstname;
			set
			{
				SetObservableProperty(firstname, value, () => firstname = value);
				Fullnameparam = FirstName + " " + Surname;
				if (IsSubmitActive())
					(EnterCommand as Command).ChangeCanExecute();
			}
		}

		private string surname;
		public string Surname
		{
			get => surname;
			set
			{
				SetObservableProperty(surname, value, () => surname = value);
				Fullnameparam = FirstName + " " + Surname;
				if (IsSubmitActive())
					(EnterCommand as Command).ChangeCanExecute();
			}
		}

		private string fullnameparam;
		public string Fullnameparam
		{
			get => fullnameparam;
			set => SetObservableProperty(fullnameparam, value, () => fullnameparam = firstname + " " + surname);
		}

		public MainPageViewModel
		(
				INavigator navigator
		) : base (navigator) 
		{
		}

		bool IsSubmitActive() { return (((string.IsNullOrEmpty(firstname)) || (string.IsNullOrEmpty(surname))) ? false : true); }

		ICommand enterCommand;
		//public ICommand EnterCommand => enterCommand = enterCommand ?? XFHelper.CreateCommand(EnterCommandExecute, () => IsSubmitActive());

		public ICommand EnterCommand
		{
			get
			{
				return new Command<string>((FullName) => EnterCommandExecute(FullName));
			}
		}

		async void EnterCommandExecute(string fullname)
		{
			var navigator = ObjectFactory.Get<INavigator>();
			await navigator.PushFeature(Feature.AppItem);
		}
	}
}
