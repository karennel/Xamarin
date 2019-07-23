using System;
using System.Threading.Tasks;
using Xamarin.Forms;

using RandomApp.View;

namespace RandomApp
{
	public interface INavigator
	{
		Feature CurrentFeature { get; }

		bool IsHomeInStack { get; }

		void Initialize(INavigation navigation);

		Task PushAsync<TPage>(bool animated = true, string loadingText = null) where TPage : Page;
		Task PushAsync<TPage>(TPage page, bool animated = true) where TPage : Page;

		Task PushViewAsync<TView>(bool animated = true) where TView : IView;

		Task PopAsync(bool animated = true);
		Task PopToRootAsync(bool animated = true);
		Task PopModalAsync(bool animated = true);
		Task PopToTypeAsync(Type type, bool animated = true);
		Task PopToHomeAsync(bool animated = true);

		/// <summary>
		/// Removes all pages up to and including the <see cref="Type"/> specified in <paramref name="type"/>./>
		/// </summary>
		Task<bool> RemoveToType(Type type);

		Task PushFeature(Feature feature, bool animated = true);

		//Task PushError(ERRModel model, bool animated = true);
		//Task PushError(ERRModel model, ImageSource errorImage, string openSettingsButtonText, ICommand navigateCommand, bool closeWhenBackgroundIsClicked = true, bool animated = true);

		//Task PushModalError(ERRModel model, bool animated = true);

		Task ReplaceRoot<TPage>(bool animated = true) where TPage : Page;
		Task ReplaceRoot(Page newRootPage, bool animated = true);

		//Task PushAccessLocked(LockPayload lockResponse, bool animated = true);

		Task PushIAT(bool animated = true);
		Task PushIATConfirm();

		Task PushNotification(string text, bool animated = true);

		void RemovePageBeforeCurrent();
	}
}
