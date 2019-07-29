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

		public RandomFactPage()
		{
			vm = new RandomFactViewModel();
			BindingContext = vm;
			CustomEditor editor = new CustomEditor();
			editor.IsVisible = true;
			InitializeComponent();
		}

		public async void OnClicked(object o, EventArgs e)
		{
			var url = "https://randomuselessfact.appspot.com/random.json?language=en";
			await vm.GetRandomFactAsync(url);
		}
	}
}