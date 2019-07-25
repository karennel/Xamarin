using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

using RandomApp.View;
using Ninject;

namespace RandomApp
{

    public static class NavigatorServiceStatic
    {
        public static Lazy<INavigationService> Instance = new Lazy<INavigationService>(() => ObjectFactory.Get<INavigationService>());
    }

    public class NavigationService : INavigationService
	{

        INavigation _navigation;

        private readonly object _sync = new object();
		private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
		private readonly Stack<NavigationPage> _navigationPageStack =
				new Stack<NavigationPage>();
		private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();

        public NavigationService()
        {
        }

        public void Initialize(INavigation navigation)
        {
            _navigation = navigation;
        }

        public void Configure(string pageKey, Type pageType)
		{
			lock (_sync)
			{
				if (_pagesByKey.ContainsKey(pageKey))
				{
					_pagesByKey[pageKey] = pageType;
				}
				else
				{
					_pagesByKey.Add(pageKey, pageType);
				}
			}
		}


        public async Task PushFeature(Feature feature, bool animated = true)
        {
            CurrentFeature = feature;

            switch (feature)
            {
                // Customer value proposition
                case Feature.AppItem:
                    await PushAsync<AppItemPage>(animated);
                    break;

                case Feature.RandomFact:
                    await PushAsync<RandomFactPage>(animated);
                    break;

            }
        }


        //public Page SetRootPage(string rootPageKey)
        //{
        //	var rootPage = GetPage(rootPageKey);
        //	_navigationPageStack.Clear();
        //	var mainPage = new NavigationPage(rootPage);
        //	_navigationPageStack.Push(mainPage);
        //	return mainPage;
        //}

        public string CurrentPageKey
		{
			get
			{
				lock (_sync)
				{
					if (CurrentNavigationPage?.CurrentPage == null)
					{
						return null;
					}

					var pageType = CurrentNavigationPage.CurrentPage.GetType();

					return _pagesByKey.ContainsValue(pageType)
							? _pagesByKey.First(p => p.Value == pageType).Key
							: null;
				}
			}	
		}

		public async Task GoBack()
		{
			var navigationStack = CurrentNavigationPage.Navigation;
			if (navigationStack.NavigationStack.Count > 1)
			{
				await CurrentNavigationPage.PopAsync();
				return;
			}

			if (_navigationPageStack.Count > 1)
			{
				_navigationPageStack.Pop();
				await CurrentNavigationPage.Navigation.PopModalAsync();
				return;
			}

			await CurrentNavigationPage.PopAsync();
		}
	    public async Task PushAsync<TPage>(TPage page, bool animated = true) where TPage : Page
        {
            var thepage = ObjectFactory._container.Get<TPage>();
            await CurrentNavigationPage.Navigation.PushAsync(thepage, animated);
		}
	}
}
