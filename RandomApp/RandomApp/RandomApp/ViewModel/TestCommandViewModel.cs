using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomApp.ViewModel
{
	public class TestCommandViewModel : ViewModel
	{
		private bool submitbuttonenabled;
		public bool SubmitButtonEnabled
		{
			get { return submitbuttonenabled; }
			set { SetProperty(ref submitbuttonenabled, value); }
		}

		private string testvalue = "the start value";
		public string TestValue
		{
			get { return testvalue; }
			set { SetProperty(ref testvalue, value); }
		}

		private string placeholder = "placeholder";
		public string PlaceHolder
		{
			get	{ return placeholder; }
			set { SetProperty(ref placeholder, value); }
		}

		private string buttontext = "Submit Disabled";
		public string ButtonText
		{
			get	{ return buttontext; }
			set { SetProperty(ref buttontext, value); }
		}

		private string entrytext;
		public string EntryText
		{
			get
			{ return entrytext; }
			set 
			{ 
				SetProperty(ref entrytext, value);
				SetSubmitButtonEnabled();
			}
		}

		private string entrytextvalue;
		public string EntryTextValue
		{
			get
			{ return entrytextvalue; }
			set
			{
				SetProperty(ref entrytextvalue, value);
			}
		}

		bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (Object.Equals(storage, value))
				return false;

			storage = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		public ICommand TestCommand { private set; get; }
		public ICommand SubmitCommand { private set; get; }

		public event PropertyChangedEventHandler PropertyChanged;

		public TestCommandViewModel(Navigator navigator) : base (navigator)
		{
			TestCommand = new Command(
				execute: () =>
				{
					TestValue = "the TestValue has changed";
					submitbuttonenabled = false;
				},
				canExecute: () =>
				{
					return true;
				});

				SubmitCommand = new Command(
				execute: () =>
				{
					TestValue = "the submit button was pressed";
					SetEntryTextValue();
				},
				canExecute: () =>
				{
					return submitbuttonenabled;
				});
		}

		void SetSubmitButtonEnabled()
		{
			ButtonText = "Submit Enabled";
			submitbuttonenabled = true;
			(SubmitCommand as Command).ChangeCanExecute();
		}

		void SetEntryTextValue()
		{
			EntryTextValue = "The entry text value is " + EntryText;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
