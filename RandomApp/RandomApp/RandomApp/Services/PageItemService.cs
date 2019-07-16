using RandomApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomApp.Services
{
	public class PageItemService
	{

		private List<PageItem> pageItemList = new List<PageItem>();

		public List<PageItem> CreatePageItemList()
		{
			PageItem pageitem = new PageItem();
			pageitem.ItemName = "ItemName";
			pageitem.ItemImage = "ItemImage";

			pageItemList.Add(new PageItem { ItemImage = "factimage", ItemName = "Display Random Facts" });
			pageItemList.Add(new PageItem { ItemImage = "button", ItemName = "number2" });
			pageItemList.Add(new PageItem { ItemImage = "button", ItemName = "number2" });
			pageItemList.Add(new PageItem { ItemImage = "button", ItemName = "number2" });
			pageItemList.Add(new PageItem { ItemImage = "button", ItemName = "number2" });

			return pageItemList;
		}



	}
}
