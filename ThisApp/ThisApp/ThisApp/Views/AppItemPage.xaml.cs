using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ThisApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppItemPage : ContentPage
	{
		public AppItemPage ()
		{
			InitializeComponent ();
		}

		private void OnRandomFactPageClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new RandomFactPage());
		}
	}
}