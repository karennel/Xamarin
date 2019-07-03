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
	public partial class ImagesScrollPage : ContentPage
	{
		ImagesScrollViewModel vm;
		public ImagesScrollPage()
		{
			vm = new ImagesScrollViewModel();
			BindingContext = vm;
			InitializeComponent();
		}

		public async void OnClicked(object o, EventArgs e)
		{
			var url = string.Format("https://picsum.photos/id/211/200/200");
			await vm.GetImageAsync(url);
		}
	}
}