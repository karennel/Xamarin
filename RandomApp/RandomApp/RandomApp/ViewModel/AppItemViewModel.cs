﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

using RandomApp.Model;
using RandomApp.Models;
using RandomApp.Services;

namespace RandomApp.ViewModels
{
	public class AppItemViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public List<PageItem> PageItemList { get; set; }
		private Person person = new Person();


		public AppItemViewModel()
		{
			PageItemService pageitemserivce = new PageItemService();
			PageItemList = pageitemserivce.CreatePageItemList();
		}

		public Person Person
		{
			get { return person; }
			set
			{
				person.FirstName = value.FirstName;
				person.LastName = value.LastName;
				person.FullName = person.FirstName + " " + person.LastName;
				NotifyPropertyChanged();
			}
		}

		public PageItem PageItem;

		private PageItem pageitem
		{
			get { return pageitem; }

			set
			{
				pageitem.ItemName = value.ItemName;
				pageitem.ItemImage = value.ItemImage;

				NotifyPropertyChanged();
			}
		}

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}




//	private string name;
//	public string Name
//{
//		get { return name; }

//		set {
//			name = value;
//			NotifyPropertyChanged();
//		}
//	}

//	private string surname;
//	public string Surname
//	{
//		get { return surname; }

//		set
//		{
//			surname = value;
//			NotifyPropertyChanged();
//		}
//	}

//	private string fullname;
//	public string FullName
//	{
//		get { return name + " " + surname;  }

//		set
//		{
//			fullname = name + " " + surname;
//			NotifyPropertyChanged();
//		}
//	}