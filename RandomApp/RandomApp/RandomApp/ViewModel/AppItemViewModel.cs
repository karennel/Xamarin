﻿using System.Windows.Input;
using Xamarin.Forms;
using RandomApp.Services;
using RandomApp.View;

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

		public AppItemViewModel(NavigationService navigationservice)
		{
			_navigationService = navigationservice;
		}

		ICommand randomfactCommand;
		public ICommand RandomFactCommand => randomfactCommand = randomfactCommand ?? XFHelper.CreateCommand(RandomFactCommandExecute);

		async void RandomFactCommandExecute()
		{
			RandomFactViewModel appitemvm = new RandomFactViewModel(_navigationService);
			await _navigationService.NavigateAsync(nameof(RandomFactPage)); ;
		}
	}
}

