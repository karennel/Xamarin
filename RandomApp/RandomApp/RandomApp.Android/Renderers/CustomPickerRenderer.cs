using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content.Res;

using RandomApp.Droid.Renderers;
using RandomApp.Controls;
using RandomApp.Droid.Extensions;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]

namespace RandomApp.Droid.Renderers
{
	public class CustomPickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
	{
		CustomPicker ElementEx => Element as CustomPicker;

		ColorStateList _defaultTextColor;

		public CustomPickerRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
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
				Control.RemoveBottomLine();

				_defaultTextColor = Control.TextColors;

				if (string.IsNullOrEmpty(Control.Text))
				{
					UpdatePlaceholder();
					UpdatePlaceholderColor();
				}

				var customPicker = e.NewElement as CustomPicker;
				customPicker.IsSelected += HandleIsSelected;
			}
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

			try { Control.SetTextColor(customPicker.PlaceholderColor.ToAndroid()); } catch { }
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

			try { Control.SetTextColor(defaultTextColor); } catch { }
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