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
				if (IsEnterEnabled())
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
				if (IsEnterEnabled())
					(EnterCommand as Command).ChangeCanExecute();
			}
		}

		private string fullname;
		public string FullName
		{
			get => fullname;
			set => SetObservableProperty(fullname, value, () => fullname = firstname + " " + surname);
		}

		bool IsEnterEnabled() { bool ret =  (((string.IsNullOrEmpty(FirstName)) || (string.IsNullOrEmpty(Surname))) ? false : true); return ret; }

		ICommand enterCommand;
		public ICommand EnterCommand => enterCommand = enterCommand ?? XFHelper.CreateCommand(EnterAction);

		async void EnterAction()
		{
		
			//await viewNavigationService.NavigateAsync(nameof(RandomFactPage), "root page misses you"); ;
		}
	}
}
