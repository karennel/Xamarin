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

			modules = new List<INinjectModule>();

			modules.AddRange
				(
					new INinjectModule[]
					{
						new RandomAppModules()
					}
				);

			ObjectFactory.Initialize(modules);

			var mainPage = new NavigationPage(ObjectFactory.Get<MainPage>());

            InitNavigator(mainPage.Navigation);

            MainPage = mainPage;
		}
        static void InitNavigator(INavigation navigation)
        {
            var navigationservice = ObjectFactory.Get<INavigationService>();
            navigationservice = new NavigationService();
            navigationservice.Initialize(navigation);
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
