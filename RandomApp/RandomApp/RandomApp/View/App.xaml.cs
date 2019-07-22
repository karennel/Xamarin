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
			//MainPage = new MainPage();
			//MainPage = new NavigationPage(new TestView());


			//mainpagevm.Person = new Person();
			//MainPage = new NavigationPage(new MainPage());

			//TestCommandView testcommandview = new TestCommandView();
			//MainPage = new NavigationPage(new TestCommandView());

			viewNavigationService.Configure("MainPage", typeof(MainPage));

			MainPageViewModel mainpagevm = new MainPageViewModel();
			mainpagevm.navigationservice = viewNavigationService; 
			var mainPage = ((Services.NavigationService)viewNavigationService).SetRootPage("MainPage");

			MainPage = mainPage;
			MainPage.BindingContext = mainpagevm;
		}

		public static NavigationService viewNavigationService { get; } = new Services.NavigationService();

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
