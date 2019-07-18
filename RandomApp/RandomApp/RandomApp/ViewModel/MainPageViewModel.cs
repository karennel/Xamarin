using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomApp.ViewModel
{
	public class MainPageViewModel : ViewModel
	{

		private string firstname;
		public string FirstName
		{
			get => firstname;
			set => SetObservableProperty(firstname, value, () => firstname = value);
		}

		private string surname;
		public string Surname
		{
			get => surname;
			set => SetObservableProperty(surname, value, () => surname = value);
		}

		private string fullname;
		public string FullName
		{
			get => fullname;
			set => SetObservableProperty(fullname, value, () => fullname = firstname + " " + surname);
		}

		//Func<bool> isactive = (((string.IsNullOrEmpty(FirstName)) || (string.IsNullOrEmpty(Surname))) ? false : true;

		ICommand enterCommand;
		public ICommand EnterCommand => enterCommand = enterCommand ?? XFHelper.CreateCommand(EnterAction);

		void EnterAction()
		{
			var thevalue = "stop";
		}
	}
}
