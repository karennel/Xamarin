using RandomApp.Model;
using RandomApp.Services;
using RandomApp.View;
using RandomApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			navigationService.Configure("MainPage", typeof(MainPage));
			navigationService.Configure("RandomFactPage", typeof(RandomFactPage));


			MainPageViewModel mainpagevm = new MainPageViewModel(navigationService);
			var mainPage = ((Services.NavigationService)navigationService).SetRootPage("MainPage");
			mainPage.BindingContext = mainpagevm; 


			MainPage = mainPage;
		}

		public static NavigationService navigationService { get; } = new Services.NavigationService();

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
