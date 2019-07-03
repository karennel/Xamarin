using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisApp.Models;
using Xamarin.Forms;

namespace ThisApp
{
	public partial class MainPage : ContentPage
	{

		Person person;
		
		public MainPage()
		{
			InitializeComponent();
		}


		async void OnEnterButtonClicked(object sender, EventArgs e)
		{
			person = new Person();
			person.FirstName = Name.Text;
			person.LastName = Surname.Text;

			AppItemPage itempage = new AppItemPage();
			itempage.BindingContext = person;

			await Navigation.PushAsync(itempage);
		}
	}
}
