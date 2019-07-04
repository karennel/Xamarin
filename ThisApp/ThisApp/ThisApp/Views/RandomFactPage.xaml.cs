using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThisApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RandomFactPage : ContentPage
	{

		RandomFactViewModel vm;
		public RandomFactPage ()
		{
			vm = new RandomFactViewModel();
			BindingContext = vm;
			InitializeComponent ();
		}

		public async void OnClicked (object o, EventArgs e)
		{
			var url = "https://randomuselessfact.appspot.com/random.json?language=en";
			await vm.GetRandomFactAsync(url);
		}
	}
}