using RandomApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomApp
{
	public class  Navigator : INavigator
	{

		public Feature CurrentFeature { get; private set; }

		INavigation _navigation;

		public bool IsHomeInStack => GetIndexOfType(typeof(MainPage)) > -1;

		Dictionary<Type, Page> _pages;

		public void Initialize(INavigation navigation)
		{
			_navigation = navigation;
		}

		public Navigator()
		{
			_pages = new Dictionary<Type, Page>();
		}


		async Task PushAsyncSimple<TPage>(bool animated = true) where TPage : Page
		{
			await PushAsync(await ObjectFactory.GetAsync<TPage>(), animated);
		}

		public async Task PushAsync<TPage>(bool animated = true, string loadingText = null) where TPage : Page
		{
			//var retryCount = 0;

			//Retry:

			try
			{ 
				//	_hudProvider.DisplayProgress(loadingText ?? AppResources.Loading);  TODO

				await PushAsyncSimple<TPage>(animated);
			}
			catch (Exception ex)
			{
				//if (!IsServiceException(ex)) TODO
				//{
				//	retryCount++;

				//	if (retryCount < 4)
				//		goto Retry;

				//	TrackException(typeof(TPage).Name, ex);
				//}

				//await PushError(ERRModel.Create(ex));
			}
			finally
			{
				//_hudProvider.Dismiss(); TODO
			}
		}

		public async Task PushAsync<TPage>(TPage page, bool animated = true) where TPage : Page
		{
			if (_navigation == null)
				throw new Exception("Not initialized.");

			if (page == null)
				throw new Exception("Page may not be null.");

#if DEBUG
			System.Diagnostics.Debug.WriteLine($"]]] PushAsync {typeof(TPage).Name}");
#endif

			await DeviceEx.BeginInvokeOnMainThreadAsync(_navigation.PushAsync(page, animated));
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

		int GetIndexOfType(Type type)
		{
			for (int i = 0; i < _navigation.NavigationStack.Count; i++)
				if (_navigation.NavigationStack[i].GetType() == type)
					return i;

			return -1;
		}

	}
}
