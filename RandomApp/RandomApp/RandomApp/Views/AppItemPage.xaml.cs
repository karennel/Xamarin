﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppItemPage : ContentPage
	{
		public AppItemPage()
		{
			InitializeComponent();
		}

		private void OnRandomFactPageClicked(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new RandomFactPage());
		}
	}
}