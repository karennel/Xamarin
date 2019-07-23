using System.Windows.Input;
using Xamarin.Forms;
using RandomApp.Services;
using RandomApp.View;

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
				FullName = FirstName + " " + Surname;
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
				FullName = FirstName + " " + Surname;
				if (IsSubmitActive())
					(EnterCommand as Command).ChangeCanExecute();
			}
		}

		private string fullname;
		public string FullName
		{
			get => fullname;
			set => SetObservableProperty(fullname, value, () => fullname = firstname + " " + surname);
		}

		public MainPageViewModel()
		{
		}

		public MainPageViewModel(NavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		bool IsSubmitActive() { return (((string.IsNullOrEmpty(firstname)) || (string.IsNullOrEmpty(surname))) ? false : true); } 

		ICommand enterCommand;
		public ICommand EnterCommand => enterCommand = enterCommand ?? XFHelper.CreateCommand(EnterCommandExecute, () => IsSubmitActive());

		async void EnterCommandExecute()
		{
			await _navigationService.NavigateAsync(nameof(AppItemPage));
		}
	}
}
