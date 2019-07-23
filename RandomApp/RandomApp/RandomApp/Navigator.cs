using RandomApp.Model.ERR;
using RandomApp.Services;
using RandomApp.Services.HUD;
using RandomApp.View;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace RandomApp
{

	public static class NavigatorStatic
	{
		public static Lazy<INavigator> Instance = new Lazy<INavigator>(() => ObjectFactory.Get<INavigator>());
	}

	public class Navigator : INavigator
	{
		public Feature CurrentFeature { get; private set; }

		public bool IsHomeInStack => GetIndexOfType(typeof(MainPage)) > -1;

		INavigation _navigation;

		Dictionary<Type, Page> _pages;


		// end of remove

		readonly IHUDProvider _hudProvider;
		//readonly IProfileQuery _profileQuery;
		//readonly IPermissionsController _permissionsController;
		//readonly ISecurityLevelController _securityLevelController;

		public Navigator
			(
				IHUDProvider hudProvider//,
				//IProfileQuery profileQuery,
				//IPermissionsController permissionsController,
				//ISecurityLevelController securityLevelController
			)
		{
			_hudProvider = hudProvider;
			//_profileQuery = profileQuery;
			//_permissionsController = permissionsController;
			//_securityLevelController = securityLevelController;

			_pages = new Dictionary<Type, Page>();
		}

		public void Initialize(INavigation navigation)
		{
			_navigation = navigation;
		}

		//public async Task PushAsyncWithElevation<TPage>(string permissionCode, Feature feature, bool animated = true, string loadingText = null) where TPage : Page
		//{
		//	Permission permission = null;

		//	if (!string.IsNullOrEmpty(permissionCode))
		//		permission = _permissionsController.Get(permissionCode);

		//	if (permission == null)
		//	{
		//		await MessageDialogController.DisplayPrompt
		//		(
		//			AppResources.Permissions,
		//			AppResources.DoNotHavePermission,
		//			AppResources.Ok
		//		);
		//		return;
		//	}

		//	if (SecureCacheStatic.SecurityLevel < permission.SecurityLevel)
		//		await _securityLevelController.IncreaseSecurityLevel(permission.SecurityLevel, feature);
		//	else
		//		await PushAsync<TPage>(animated);
		//}

		public async Task PushAsync<TPage>(bool animated = true, string loadingText = null) where TPage : Page
		{
			var retryCount = 0;

			Retry:

			try
			{
				if (retryCount == 0)
					_hudProvider.DisplayProgress(loadingText ?? "Loading");

				await PushAsyncSimple<TPage>(animated);
			}
			catch (Exception ex)
			{
				if (!IsServiceException(ex))
				{
					retryCount++;

					if (retryCount < 4)
						goto Retry;

					TrackException(typeof(TPage).Name, ex);
				}

				await PushError(ERRModel.Create(ex));
			}
			finally
			{
				_hudProvider.Dismiss();
			}
		}

		static bool IsServiceException(Exception ex)
		{
			return
				ex is ServiceException ||
				ex is ServiceTimeoutException ||
				ex is HttpRequestException;
		}

		//static void TrackException(string pageTypeName, Exception ex)
		//{
		//	if (!InsightsClientStatic.Instance.Value.IsEnabled)
		//		return;

		//	Task.Run(() => InsightsClientStatic.Instance.Value.TrackException($"NavigationException.{pageTypeName}", ex));
		//}

		async Task PushAsyncSimple<TPage>(bool animated = true) where TPage : Page
		{
			await PushAsync(await ObjectFactory.GetAsync<TPage>(), animated);
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

		public async Task PushViewAsync<TView>(bool animated = true) where TView : IView
		{
			var retryCount = 0;

			Retry:

			try
			{
				if (retryCount == 0)
					_hudProvider.DisplayProgress(AppResources.Loading);

				var view = await ObjectFactory.GetAsync<TView>();

				await PushAsync(view as Page, animated);
			}
			catch (Exception ex)
			{
				if (!IsServiceException(ex))
				{
					retryCount++;

					if (retryCount < 4)
						goto Retry;

					TrackException(typeof(TView).Name, ex);
				}

				await PushError(ERRModel.Create(ex));
			}
			finally
			{
				_hudProvider.Dismiss();
			}
		}

		public async Task PopAsync(bool animated = true)
		{
			try
			{
				await PopDisposablePage(animated);
			}
			catch (Exception ex)
			{
				await PushError(ERRModel.Create(ex));
			}
		}

		async Task PopDisposablePage(bool animated)
		{
			DisposePage(await _navigation.PopAsync(animated));
		}

		static void DisposePage(Page page)
		{
			var disposablePage = page as IDisposablePage;
			disposablePage?.DisposeViewModel();
		}

		public async Task PopToRootAsync(bool animated = true)
		{
			try
			{
				await _navigation.PopToRootAsync(animated);
			}
			catch (Exception ex)
			{
				await PushError(ERRModel.Create(ex));
			}
		}

		public async Task PopModalAsync(bool animated = true)
		{
			try
			{
				await _navigation.PopModalAsync(animated);
			}
			catch (Exception ex)
			{
				await PushError(ERRModel.Create(ex));
			}
		}

		public async Task PopToTypeAsync(Type type, bool animated = true)
		{
			try
			{
				// Check if the Type is in the navigation stack...
				var index = GetIndexOfType(type);
				if (index == -1)
				{
					DisposeAllPagesExceptRoot();

					await _navigation.PopToRootAsync(animated);
					return;
				}

				// In order to Pop to the Type, we need to remove any pages between the Type and the last page on the stack.
				var numberOfPagesToRemove = ((_navigation.NavigationStack.Count - 1) - index) - 1;

				for (int i = 0; i < numberOfPagesToRemove; i++)
					RemoveDisposablePage(_navigation.NavigationStack[index + 1]); // We always remove the page just after the Type.

				// Then we can pop from the last page on the stack to the Type.
				await PopDisposablePage(animated);
			}
			catch (Exception ex)
			{
				await PushError(ERRModel.Create(ex));
			}
		}

		void DisposeAllPagesExceptRoot()
		{
			for (int i = 1; i < _navigation.NavigationStack.Count; i++)
				DisposePage(_navigation.NavigationStack[i]);
		}

		void RemoveDisposablePage(Page page)
		{
			DisposePage(page);

			_navigation.RemovePage(page);
		}

		public async Task PopToHomeAsync(bool animated = true)
		{
			await PopToTypeAsync(typeof(HOM001), animated);
		}

		int GetIndexOfType(Type type)
		{
			for (int i = 0; i < _navigation.NavigationStack.Count; i++)
				if (_navigation.NavigationStack[i].GetType() == type)
					return i;

			return -1;
		}

		public async Task<bool> RemoveToType(Type type)
		{
#if DEBUG
			PrintNavigationStack("--- NavigationStack before ---");
#endif

			// Check if the Type is in the navigation stack...
			var index = GetIndexOfType(type);
			if (index == -1)
				return false;

			var numberOfPagesToRemove = ((_navigation.NavigationStack.Count) - index);

			for (int i = 0; i < numberOfPagesToRemove; i++)
				await PopDisposablePage(false);

#if DEBUG
			PrintNavigationStack("--- NavigationStack after ---");
#endif

			return true;
		}

#if DEBUG
		void PrintNavigationStack(string header)
		{
			System.Diagnostics.Debug.WriteLine(header);

			foreach (var page in _navigation.NavigationStack)
				System.Diagnostics.Debug.WriteLine(page.GetType().Name);
		}
#endif

		public async Task PushFeature(Feature feature, bool animated = true)
		{
			CurrentFeature = feature;

			switch (feature)
			{
				// Customer value proposition
				case Feature.AppItems:
					await PushAsync<AppItemPage>(animated);
					break;
			}
		}

		TPage GetPageForType<TPage>() where TPage : Page
		{
			if (_pages.TryGetValue(typeof(TPage), out Page result))
				return result as TPage;
			else
			{
				var page = ObjectFactory.Get<TPage>();
				_pages.Add(typeof(TPage), page);
				return page;
			}
		}

		public async Task PushError(ERRModel model, bool animated = true)
		{
			if (IsSessionExpiredException(model.Exception))
			{
				var newModel = ERRModel.Create("SessionExpired", "LogInAgain");

				await PushError(newModel, AppImages.Exclamation.Value, "Ok", XFHelper.CreateCommand(LogoutAction), animated);
			}
			else
				await PushError(model, AppImages.Exclamation.Value, "Ok", XFHelper.CreateCommand(OkAction), animated);
		}

		static bool IsSessionExpiredException(Exception exception)
		{
			if (exception != null && exception is ServiceException serviceException)
				return serviceException.Code == 9999;
			else
				return false;
		}

		//static async void LogoutAction()
		//{
		//	await PopupNavigation.PopAsync();

		//	await ObjectFactory.Get<ILoginController>().PerformLogout();
		//}

		//static async void OkAction()
		//{
		//	await PopupNavigation.PopAsync();
		//}

		//public async Task PushError(ERRModel model, ImageSource errorImage, string buttonText, ICommand navigateCommand, bool closeWhenBackgroundIsClicked = true, bool animated = true)
		//{
		//	var viewModel = await ObjectFactory.GetAsync<ERR001ViewModel>();
		//	viewModel.Model = model;
		//	viewModel.ErrorImage = errorImage;
		//	viewModel.ButtonText = TranslateExtension.Format(buttonText);
		//	viewModel.NavigateCommand = navigateCommand;

		//	var errorPage = await ObjectFactory.GetAsync<ERR001>();
		//	errorPage.SetViewModel(viewModel);
		//	errorPage.CloseWhenBackgroundIsClicked = closeWhenBackgroundIsClicked;

		//	Device.BeginInvokeOnMainThread(async () => await PopupNavigation.PushAsync(errorPage, animated));
		//}

		//public async Task PushModalError(ERRModel model, bool animated = true)
		//{
		//	await PushError(model, AppImages.NoInternet.Value, null, null, false, animated);
		//}

		//public async Task ReplaceRoot<TPage>(bool animated = true) where TPage : Page
		//{
		//	try
		//	{
		//		_hudProvider.DisplayProgress(AppResources.Loading);

		//		await ReplaceRoot(await ObjectFactory.GetAsync<TPage>(), animated);
		//	}
		//	finally
		//	{
		//		_hudProvider.Dismiss();
		//	}
		//}

		//public async Task ReplaceRoot(Page newRootPage, bool animated = true)
		//{
		//	try
		//	{
		//		DisposeAllPages();

		//		var rootPage = _navigation.NavigationStack[0];

		//		await DeviceEx.BeginInvokeOnMainThreadAsync(async () =>
		//		{
		//			_navigation.InsertPageBefore(newRootPage, rootPage);
		//			await _navigation.PopToRootAsync(animated);
		//		});
		//	}
		//	catch (Exception ex)
		//	{
		//		await PushError(ERRModel.Create(ex));
		//	}
		//}

		public void DisposeAllPages()
		{
			foreach (var page in _navigation.NavigationStack)
				DisposePage(page);
		}

		//public async Task PushAccessLocked(LockPayload lockResponse, bool animated = true)
		//{
		//	var viewModel = await ObjectFactory.GetAsync<LINAccessLockedViewModel>();

		//	if (lockResponse.WaitMinutes == -1)
		//	{
		//		viewModel.Message = AppResources.LoginLocked;
		//		viewModel.ExpiryDate = null;
		//	}
		//	else
		//	{
		//		viewModel.Message = string.Format(AppResources.LoginLockedFormat, ToTimeString(lockResponse.WaitMinutes));
		//		viewModel.ExpiryDate = lockResponse.ExpiryDate;
		//	}

		//	var errorPage = await ObjectFactory.GetAsync<LINAccessLocked>();
		//	errorPage.SetViewModel(viewModel);

		//	Device.BeginInvokeOnMainThread(async () => await PopupNavigation.PushAsync(errorPage, animated));
		//}

		static string ToTimeString(int minutes)
		{
			var ts = TimeSpan.FromMinutes(minutes);

			if (ts.TotalHours < 1)
				return $"{ts.TotalMinutes} minutes";
			else
				return $"{ts.TotalHours} hours";
		}

		//async Task NavigateToAccountOptions()
		//{
		//	var pageTypeName = string.Empty;

		//	try
		//	{
		//		_hudProvider.DisplayProgress(AppResources.Loading);

		//		var person = await GetPerson();
		//		if (person == null)
		//			return;

		//		MemoryCacheStatic.IsLocalResident = person.IsLocalResident;

		//		if (person.Age < SecureCacheStatic.TenantLegalAge)
		//		{
		//			pageTypeName = typeof(ACC002).Name;
		//			await PushAsyncSimple<ACC002>();
		//		}
		//		else
		//		{
		//			pageTypeName = typeof(ACC001).Name;
		//			await PushAsyncSimple<ACC001>();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		TrackException(pageTypeName, ex);

		//		await PushError(ERRModel.Create(ex));
		//	}
		//	finally
		//	{
		//		_hudProvider.Dismiss();
		//	}
		//}

		//async Task<Person> GetPerson()
		//{
		//	return await _profileQuery.GetPersonalDetails
		//		(
		//			ProfileControllerStatic.Instance.Value.ControlId,
		//			BateleurConfigStatic.Instance.Value.TenantCode,
		//			ProfileControllerStatic.Instance.Value.ContextId
		//		);
		//}

		//public async Task PushIAT(bool animated = true)
		//{
		//	var view = await ObjectFactory.GetAsync<IAT001>();

		//	var viewModel = await ObjectFactory.GetAsync<IAT001ViewModel>();

		//	view.SetViewModel(viewModel);

		//	await PushAsync(view, animated);

		//	viewModel.FromAccount = viewModel.FromAccounts.FirstOrDefault(x => x.AccountNumber == MemoryCacheStatic.FromAccountNumber);

		//	viewModel.ToAccount = viewModel.ToAccounts.FirstOrDefault(x => !x.Equals(viewModel.FromAccount));
		//}

		//public async Task PushIATConfirm()
		//{
		//	try
		//	{
		//		_hudProvider.DisplayProgress(AppResources.Loading);

		//		var view = await ObjectFactory.GetAsync<IAT002>();

		//		var viewModel = await ObjectFactory.GetAsync<IAT002ViewModel>();

		//		view.SetViewModel(viewModel);

		//		await PushAsync(view);

		//		viewModel.FromAccount = MemoryCacheStatic.IAT.FromAccount;
		//		viewModel.ToAccount = MemoryCacheStatic.IAT.ToAccount;
		//	}
		//	finally
		//	{
		//		_hudProvider.Dismiss();
		//	}
		//}

		//public async Task PushNotification(string text, bool animated = true)
		//{
		//	var viewModel = await ObjectFactory.GetAsync<NotificationViewModel>();
		//	viewModel.Text = text;

		//	var notificationPopup = await ObjectFactory.GetAsync<NotificationPopup>();
		//	notificationPopup.SetViewModel(viewModel);

		//	Device.BeginInvokeOnMainThread(async () => await PopupNavigation.PushAsync(notificationPopup, animated));
		//}

		public void RemovePageBeforeCurrent()
		{
			var pageToRemove = _navigation.NavigationStack.ElementAtOrDefault(_navigation.NavigationStack.Count - 2);

			if (pageToRemove == null)
				return;

#if DEBUG
			System.Diagnostics.Debug.WriteLine($"]]] RemovePageBeforeCurrent {pageToRemove.GetType().Name}");
#endif

			RemoveDisposablePage(pageToRemove);
		}
	}
}
