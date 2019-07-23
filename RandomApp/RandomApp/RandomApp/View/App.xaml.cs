using System;
using Xamarin.Forms;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;

using RandomApp.View;

namespace RandomApp
{
	public partial class App : Application
	{

		static StandardKernel _container;

		public App()
		{
			InitializeComponent();

			// build modules list

			var modules = new List<INinjectModule>
			{
				new RandomAppModules()
			};

			if (modules.IsNullOrEmpty())
				throw new ArgumentNullException(nameof(modules));

			ObjectFactory.Initialize(modules);

			var mainPage = ((NavigationService)navigationService).SetRootPage("MainPage");
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
