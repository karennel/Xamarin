using Foundation;
using System;

namespace UIKit
{
	public class FluentLayout
	{
		internal Lazy<NSLayoutConstraint> Constraint { get; }

		public UIView View { get; }

		public NSLayoutAttribute Attribute { get; private set; }

		public NSLayoutRelation Relation { get; private set; }

		nfloat _constant;
		public nfloat Constant
		{
			get { return _constant; }
			set
			{
				_constant = value;

				if (Constraint.IsValueCreated)
					Constraint.Value.Constant = _constant;
			}
		}

		float _priority;
		public float Priority
		{
			get { return _priority; }
			set
			{
				_priority = value;

				if (Constraint.IsValueCreated)
					Constraint.Value.Priority = _priority;
			}
		}

		string _identifier;
		public string Identifier
		{
			get { return _identifier; }
			set
			{
				_identifier = value;

				if (Constraint.IsValueCreated)
					Constraint.Value.SetIdentifier(_identifier);
			}
		}

		public NSObject SecondItem { get; private set; }

		public NSLayoutAttribute SecondAttribute { get; private set; }

		public nfloat Multiplier { get; private set; } = 1f;

		public FluentLayout
			(
				UIView view,
				NSLayoutAttribute attribute,
				NSLayoutRelation relation,
				nfloat constant = default(nfloat))
		{
			Constraint = new Lazy<NSLayoutConstraint>(CreateConstraint);
			View = view;
			Attribute = attribute;
			Relation = relation;
			Constant = constant;
			Priority = (float)UILayoutPriority.Required;
		}

		NSLayoutConstraint CreateConstraint()
		{
			var constraint = NSLayoutConstraint.Create
				(
					View,
					Attribute,
					Relation,
					SecondItem,
					SecondAttribute,
					Multiplier,
					Constant
				);

			constraint.Priority = Priority;

			if (!string.IsNullOrWhiteSpace(Identifier))
				constraint.SetIdentifier(Identifier);

			return constraint;
		}

		public FluentLayout LeftOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Left);

		public FluentLayout RightOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Right);

		public FluentLayout TopOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Top);

		public FluentLayout BottomOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Bottom);

		public FluentLayout BaselineOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Baseline);

		public FluentLayout TrailingOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Trailing);

		public FluentLayout LeadingOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Leading);

		public FluentLayout CenterXOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.CenterX);

		public FluentLayout CenterYOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.CenterY);

		public FluentLayout WidthOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Width);

		public FluentLayout HeightOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Height);

		public FluentLayout TrailingMarginOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.TrailingMargin);

		public FluentLayout LeadingMarginOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.LeadingMargin);

		public FluentLayout TopMarginOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.TopMargin);

		public FluentLayout BottomMarginOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.BottomMargin);

		FluentLayout SetSecondItem(NSObject view2, NSLayoutAttribute attribute2)
		{
			ThrowIfSecondItemAlreadySet();

			SecondItem = view2;
			SecondAttribute = attribute2;
			return this;
		}

		void ThrowIfSecondItemAlreadySet()
		{
			if (SecondItem != null)
				throw new Exception("You cannot set the second item in a layout relation more than once.");
		}

		public FluentLayout Plus(nfloat constant)
		{
			Constant += constant;
			return this;
		}

		public FluentLayout Minus(nfloat constant)
		{
			Constant -= constant;
			return this;
		}
	}
}