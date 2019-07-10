using System;

namespace UIKit
{
	public class UIViewAndLayoutAttribute
	{
		public UIView View { get; }

		public NSLayoutAttribute Attribute { get; }

		public UIViewAndLayoutAttribute(UIView view, NSLayoutAttribute attribute)
		{
			View = view;
			Attribute = attribute;
		}

		public FluentLayout EqualTo(nfloat constant = default(nfloat)) => new FluentLayout(View, Attribute, NSLayoutRelation.Equal, constant);
	}
}