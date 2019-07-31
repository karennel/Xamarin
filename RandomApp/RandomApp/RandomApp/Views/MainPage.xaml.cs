using System.ComponentModel;
using Xamarin.Forms;

using RandomApp.ViewModel;

namespace RandomApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainPageViewModel viewmodel)
		{
			InitializeComponent();
			BindingContext = viewmodel;
		}
	}
}
