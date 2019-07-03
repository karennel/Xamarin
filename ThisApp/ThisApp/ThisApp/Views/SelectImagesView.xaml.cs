using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThisApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectImagesView : ContentPage
	{

		//List<ImageItem> imagelist = new List<ImageItem>();
		//ImageItem imageitem = new ImageItem();
		public SelectImagesView ()
		{
			InitializeComponent ();
		}
		void OnPickerSelectedIndexChanged(object sender, EventArgs e)
		{
			//var picker = (Picker)sender;
			//int selectedIndex = picker.SelectedIndex;

			//if (selectedIndex != -1)
			//{
			//	ImageCount.Text = picker.Items[selectedIndex];
			//}

			//LoadImages();

			//ImagesPage imagespage = new ImagesPage();

			//imagespage.BindingContext = imagelist;
		}

		async void OnImagesViewClicked(object sender, EventArgs e)
		{

			//LoadImages();

			//ImagesPage imagesview = new ImagesPage();

			//imagesview.BindingContext = imageitem;

			//await Navigation.PushAsync(imagesview);
		}
		protected void LoadImages()
		{
			//imageitem.imagesource = new Uri("https://images.dog.ceo/breeds/hound-basset/n02088238_13908.jpg");
			//imageitem.imagestatus = "Success";
			//imagelist.Add(imageitem);
		}
	}
}