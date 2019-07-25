using Ninject.Modules;
using RandomApp.Model;
using RandomApp.Services;
using RandomApp.View;
using RandomApp.ViewModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomApp
{
	public partial class App : Application
	{

		List<INinjectModule> modules;

		public App()
		{
			InitializeComponent();

			navigationService.Configure("MainPage", typeof(MainPage));
			navigationService.Configure("AppItemPage", typeof(AppItemPage));
			navigationService.Configure("RandomFactPage", typeof(RandomFactPage));

			modules = new List<INinjectModule>();

			modules.AddRange
				(
					new INinjectModule[]
					{
						new RandomAppModules()
					}
				);

			ObjectFactory.Initialize(modules);

			MainPageViewModel mainpagevm = new MainPageViewModel(navigationService);
			var mainPage = ((NavigationService)navigationService).SetRootPage("MainPage");
			mainPage.BindingContext = mainpagevm; 
			MainPage = mainPage;
		}

		public static NavigationService navigationService { get; } = new NavigationService();

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
