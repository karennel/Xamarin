using RandomApp.View;
using RandomApp.ViewModel;
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
	public partial class AppItemPage : ContentPage
	{
		public AppItemPage(AppItemViewModel viewmodel)
		{
			InitializeComponent();
            BindingContext = viewmodel;
		}
	}
}