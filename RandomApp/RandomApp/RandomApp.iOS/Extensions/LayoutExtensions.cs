using System;
using System.Collections.Generic;
using System.Linq;

namespace UIKit
{
	public static class LayoutExtensions
	{
		const float DefaultMargin = 0;

		public static FluentLayout AtTopOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Top().EqualTo().TopOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

		public static FluentLayout AtLeftOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Left().EqualTo().LeftOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

		public static FluentLayout AtRightOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Right().EqualTo().RightOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

		public static FluentLayout AtBottomOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Bottom().EqualTo().BottomOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

		public static FluentLayout Below(this UIView view, UIView previous, nfloat? margin = null) =>
			view.Top().EqualTo().BottomOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));

		public static FluentLayout Above(this UIView view, UIView previous, nfloat? margin = null) =>
			view.Bottom().EqualTo().TopOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));

		public static FluentLayout WithSameLeft(this UIView view, UIView previous) => view.Left().EqualTo().LeftOf(previous);

		public static FluentLayout WithSameTop(this UIView view, UIView previous) => view.Top().EqualTo().TopOf(previous);

		public static FluentLayout WithSameCenterX(this UIView view, UIView previous) => view.CenterX().EqualTo().CenterXOf(previous);

		public static FluentLayout WithSameCenterY(this UIView view, UIView previous) => view.CenterY().EqualTo().CenterYOf(previous);

		public static FluentLayout WithSameRight(this UIView view, UIView previous) => view.Right().EqualTo().RightOf(previous);

		public static FluentLayout WithSameWidth(this UIView view, UIView previous) => view.Width().EqualTo().WidthOf(previous);

		public static FluentLayout WithSameBottom(this UIView view, UIView previous) => view.Bottom().EqualTo().BottomOf(previous);

		public static UIViewAndLayoutAttribute Left(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.Left);

		public static UIViewAndLayoutAttribute Right(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.Right);

		public static UIViewAndLayoutAttribute Top(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.Top);

		public static UIViewAndLayoutAttribute Bottom(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.Bottom);

		public static UIViewAndLayoutAttribute Baseline(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.Baseline);

		public static UIViewAndLayoutAttribute Trailing(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.Trailing);

		public static UIViewAndLayoutAttribute Leading(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.Leading);

		public static UIViewAndLayoutAttribute CenterX(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.CenterX);

		public static UIViewAndLayoutAttribute CenterY(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.CenterY);

		public static UIViewAndLayoutAttribute Width(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.Width);

		public static UIViewAndLayoutAttribute Height(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.Height);

		public static UIViewAndLayoutAttribute WithLayoutAttribute(this UIView view, NSLayoutAttribute attribute) => new UIViewAndLayoutAttribute(view, attribute);

		public static UIViewAndLayoutAttribute LeadingMargin(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.LeadingMargin);

		public static UIViewAndLayoutAttribute TrailingMargin(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.TrailingMargin);

		public static UIViewAndLayoutAttribute TopMargin(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.TopMargin);

		public static UIViewAndLayoutAttribute BottomMargin(this UIView view) => view.WithLayoutAttribute(NSLayoutAttribute.BottomMargin);

		public static void AddConstraints(this UIView view, params FluentLayout[] fluentLayouts) => view.AddConstraints(fluentLayouts.AsEnumerable());

		public static void AddConstraints(this UIView view, IEnumerable<FluentLayout> fluentLayouts) => view.AddConstraints(fluentLayouts
			.Where(fluent => fluent != null)
			.Select(fluent => fluent.Constraint.Value)
			.ToArray());
	}
}