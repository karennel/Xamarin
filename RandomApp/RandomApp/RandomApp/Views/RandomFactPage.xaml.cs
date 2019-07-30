using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RandomApp.ViewModel;
using RandomApp.Controls;

namespace RandomApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RandomFactPage : ContentPage
	{

		RandomFactViewModel vm;

		public RandomFactPage(RandomFactViewModel viewmodel)
		{
			InitializeComponent();
			BindingContext = viewmodel;
		}
	}
}