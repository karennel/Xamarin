using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using RandomApp.Models;
using RandomApp.Views;

namespace RandomApp
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}



		async void OnEnterButtonClicked(object sender, EventArgs e)
		{

			Person person;

			person = new Person();
			person.FirstName = Name.Text;
			person.LastName = Surname.Text;

			AppItemPage itempage = new AppItemPage();
			itempage.BindingContext = person;

			await Navigation.PushAsync(itempage);
		}
	}
}
