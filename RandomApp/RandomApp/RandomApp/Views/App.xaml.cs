using Ninject.Modules;
using System.Collections.Generic;
using Xamarin.Forms;

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
			var navigator = ObjectFactory.Get<INavigator>();
			navigator.Initialize(navigation);
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
