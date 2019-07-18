using RandomApp.Model;
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

			MainPageViewModel mainpagevm = new MainPageViewModel();
			//mainpagevm.Person = new Person();
			MainPage = new NavigationPage(new MainPage());

			//TestCommandView testcommandview = new TestCommandView();
			//MainPage = new NavigationPage(new TestCommandView());
		}

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
