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

			pageItemList.Add(new PageItem { ItemImage = "factimage", ItemName = "Random Fact" });
			pageItemList.Add(new PageItem { ItemImage = "ItemImage2", ItemName = "ItemName2" });
			pageItemList.Add(new PageItem { ItemImage = "ItemImage3", ItemName = "ItemName3" });
			pageItemList.Add(new PageItem { ItemImage = "ItemImage4", ItemName = "ItemName4" });
			pageItemList.Add(new PageItem { ItemImage = "ItemImage5", ItemName = "ItemName5" });

			return pageItemList;
		}



	}
}
