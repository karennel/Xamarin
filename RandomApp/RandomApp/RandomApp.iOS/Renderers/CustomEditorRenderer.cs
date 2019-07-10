using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RandomApp.iOS.Extensions;
using System.ComponentModel;

using RandomApp.Controls;
using RandomApp.iOS.Renderers;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]

namespace RandomApp.iOS.Renderers
{
	public class CustomEditorRenderer : EditorRenderer
	{
		CustomEditor ElementEx => (CustomEditor)Element;

		UILabel _placeholderLabel;

		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
				Control.Ended -= Control_Ended;
				Control.Changed -= Control_Changed;
			}

			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers
				CreatePlaceholderLabel();

				Control.Ended += Control_Ended;
				Control.Changed += Control_Changed;

				SetTextColor();
			}
		}

		void Control_Ended(object sender, EventArgs e)
		{
			if (!((UITextView)sender).HasText && _placeholderLabel != null)
				_placeholderLabel.Hidden = false;
		}

		void Control_Changed(object sender, EventArgs e)
		{
			if (_placeholderLabel != null)
				_placeholderLabel.Hidden = ((UITextView)sender).HasText;
		}

		void CreatePlaceholderLabel()
		{
			_placeholderLabel = new UILabel
			{
				BackgroundColor = UIColor.Clear,
				Font = UIFont.FromName(ElementEx.FontFamily, (nfloat)ElementEx.FontSize)
			};

			UpdatePlaceholder();
			UpdatePlaceholderColor();

			_placeholderLabel.SizeToFit();

			Control.AddSubview(_placeholderLabel);

			Control.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			Control.AddConstraints
				(
					_placeholderLabel.AtLeftOf(Control, 7),
					_placeholderLabel.WithSameCenterY(Control)
				);

			Control.LayoutIfNeeded();

			_placeholderLabel.Hidden = Control.HasText;
		}

		void UpdatePlaceholder()
		{
			_placeholderLabel.Text = ElementEx.Placeholder;
		}

		void UpdatePlaceholderColor()
		{
			_placeholderLabel.TextColor = ElementEx.PlaceholderColor.ToUIColor();
		}

		void SetTextColor()
		{
			Control.TextColor = Element.TextColor.ToUIColor();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == CustomEditor.PlaceholderProperty.PropertyName)
				UpdatePlaceholder();
			else if (e.PropertyName == CustomEditor.PlaceholderColorProperty.PropertyName)
				UpdatePlaceholderColor();
			else if
				(
					e.PropertyName == Editor.TextColorProperty.PropertyName ||
					e.PropertyName == VisualElement.IsEnabledProperty.PropertyName
				)
				SetTextColor();
		}
	}
}