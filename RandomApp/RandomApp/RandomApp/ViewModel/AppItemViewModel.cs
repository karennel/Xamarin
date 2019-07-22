using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

using RandomApp.Model;
using RandomApp.Services;

namespace RandomApp.ViewModel
{
	public class AppItemViewModel : ViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public List<PageItem> PageItemList { get; set; }
		private Person person = new Person();

		public AppItemViewModel()
		{
			PageItemService pageitemserivce = new PageItemService();
			PageItemList = pageitemserivce.CreatePageItemList();
			Person = person;
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

