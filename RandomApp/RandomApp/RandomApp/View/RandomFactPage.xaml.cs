using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RandomApp.ViewModel;
using RandomApp.Controls;

namespace RandomApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RandomFactPage : ContentPage
	{
		public RandomFactPage(RandomFactViewModel viewmodel)
		{
			InitializeComponent();
			BindingContext = viewmodel;
		}
	}
}