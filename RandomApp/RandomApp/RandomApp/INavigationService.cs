using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomApp
{
	public interface INavigationService
	{
		string CurrentPageKey { get; }

        Task PushAsync<TPage>(TPage page, bool animated = true) where TPage : Page; 

        void Configure(string pageKey, Type pageType);
		Task GoBack();
		//Task NavigateAsync(string pageKey, bool animated = true);
		//Task NavigateAsync(string pageKey, object parameter, bool animated = true);
        void Initialize(INavigation navigation);
    }
}
