using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RandomApp
{
	public interface INavigationService
	{
		string CurrentPageKey { get; }

		void Configure(string pageKey, Type pageType);
		Task GoBack();
		Task NavigateAsync(string pageKey, bool animated = true);
		Task NavigateAsync(string pageKey, object parameter, bool animated = true);
	}
}
