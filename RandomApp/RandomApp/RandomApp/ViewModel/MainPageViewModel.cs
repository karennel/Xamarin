using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

		public MainPageViewModel(NavigationService navigationService)
		{
			_navigationService = navigationService;
		}
			

		bool IsSubmitActive() { return (((string.IsNullOrEmpty(FirstName)) || (string.IsNullOrEmpty(Surname))) ? false : true); } 

		ICommand enterCommand;
		public ICommand EnterCommand => enterCommand = enterCommand ?? XFHelper.CreateCommand(EnterCommandExecute, () => (((string.IsNullOrEmpty(FirstName)) || (string.IsNullOrEmpty(Surname))) ? false : true));

		async void EnterCommandExecute()
		{
			await _navigationService.NavigateAsync(nameof(RandomFactPage), null); ;
		}
	}
}
