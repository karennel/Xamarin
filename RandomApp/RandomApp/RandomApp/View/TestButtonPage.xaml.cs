using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestButtonPage : ContentPage
	{
		public TestButtonPage()
		{
			InitializeComponent();
		}

		async void TestButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TestEditorPage());
		}
	}
}