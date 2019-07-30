using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomApp
{
	public interface INavigator
	{

		Feature CurrentFeature { get; }

		bool IsHomeInStack { get; }

		void Initialize(INavigation navigation);

		Task PushAsync<TPage>(TPage page, bool animated = true) where TPage : Page;

		Task PushFeature(Feature feature, bool animated = true);

	}



}
