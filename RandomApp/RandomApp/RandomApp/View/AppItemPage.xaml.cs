using RandomApp.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppItemPage : ContentPage
	{
		public AppItemPage(AppItemPageViewModel viewmodel)
		{
			InitializeComponent();

			BindingContext = viewmodel;
		}
	}
}