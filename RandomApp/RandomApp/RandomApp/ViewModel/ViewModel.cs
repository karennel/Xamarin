using RandomApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RandomApp.ViewModel
{
	public abstract class ViewModel : IViewModel
	{

		public NavigationService navigationservice = null;

		public event PropertyChangedEventHandler PropertyChanged;

		bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set => SetObservableProperty(ref _isBusy, value);
		}

		string _title;
		public string Title
		{
			get => _title;
			set => SetObservableProperty(ref _title, value);
		}

		string _icon;
		public string Icon
		{
			get => _icon;
			set => SetObservableProperty(ref _icon, value);
		}

		protected bool SetObservableProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(field, value))
				return false;

			field = value;

			OnPropertyChanged(propertyName);

			return true;
		}

		protected bool SetObservableProperty<T>(T field, T value, Action setAction, [CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(field, value))
				return false;

			setAction();

			OnPropertyChanged(propertyName);

			return true;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
