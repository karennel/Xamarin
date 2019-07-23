using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using RandomApp.View;
using RandomApp.ViewModel;

namespace RandomApp
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage(MainPageViewModel viewmodel)
		{
			InitializeComponent();

			BindingContext = viewmodel;
		}

		public MainPage()
		{
			InitializeComponent();

		}
	}
}
