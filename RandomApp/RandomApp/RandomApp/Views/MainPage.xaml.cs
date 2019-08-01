using System.ComponentModel;
using Xamarin.Forms;

using RandomApp.ViewModel;
using RandomApp.EndPoints;

namespace RandomApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainPageViewModel viewmodel)
		{
			InitializeComponent();
			BindingContext = viewmodel;

			InitEndPointsManager();
		}


		void InitEndPointsManager()
		{
			ObjectFactory.Get<IEndPointsManager>().Init();
		}
	}
}
