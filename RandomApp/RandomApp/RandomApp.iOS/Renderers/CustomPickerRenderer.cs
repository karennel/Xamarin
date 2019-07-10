using RandomApp.Controls;
using RandomApp.iOS.Renderers;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RandomApp.iOS.Extensions;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]

namespace RandomApp.iOS.Renderers
{
	public class CustomPickerRenderer : PickerRenderer
	{
		CustomPicker ElementEx => Element as CustomPicker;

		IKeyboardToolbar KeyboardToolbar => Element as IKeyboardToolbar;

		UIColor _defaultTextColor;

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
				Control.DisposeCustomKeyboard();

				if (KeyboardToolbar != null)
					KeyboardToolbar.OnResetKeyboard -= Element_OnResetKeyboard;

				var customPicker = e.OldElement as CustomPicker;
				customPicker.IsSelected -= HandleIsSelected;

				var defaultTextColor = _defaultTextColor;
				if (defaultTextColor != null)
				{
					defaultTextColor.Dispose();
					_defaultTextColor = null;
				}
			}

			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers
				Control.BorderStyle = UITextBorderStyle.None;

				Control.AddToolbar(KeyboardToolbar);

				if (KeyboardToolbar != null)
					KeyboardToolbar.OnResetKeyboard += Element_OnResetKeyboard;

				_defaultTextColor = Control.TextColor;

				if (string.IsNullOrEmpty(Control.Text))
				{
					UpdatePlaceholder();
					UpdatePlaceholderColor();
				}

				var customPicker = e.NewElement as CustomPicker;
				customPicker.IsSelected += HandleIsSelected;
			}
		}

		void Element_OnResetKeyboard(object sender, EventArgs e)
		{
			Control.DisposeCustomKeyboard();
			Control.AddToolbar(KeyboardToolbar);
		}

		void UpdatePlaceholder()
		{
			var customPicker = ElementEx;
			if (customPicker == null)
				return;

			try { Control.Text = customPicker.Placeholder; } catch { }
		}

		void UpdatePlaceholderColor()
		{
			var customPicker = ElementEx;
			if (customPicker == null)
				return;

			try { Control.TextColor = customPicker.PlaceholderColor.ToUIColor(); } catch { }
		}

		void HandleIsSelected(bool isSelected)
		{
			if (isSelected)
				ResetTextColor();
			else
			{
				UpdatePlaceholder();
				UpdatePlaceholderColor();
			}
		}

		void ResetTextColor()
		{
			var defaultTextColor = _defaultTextColor;
			if (defaultTextColor == null)
				return;

			try { Control.TextColor = defaultTextColor; } catch { }
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == CustomPicker.PlaceholderProperty.PropertyName)
				UpdatePlaceholder();
			else if (e.PropertyName == CustomPicker.PlaceholderColorProperty.PropertyName)
				UpdatePlaceholderColor();
		}
	}
}