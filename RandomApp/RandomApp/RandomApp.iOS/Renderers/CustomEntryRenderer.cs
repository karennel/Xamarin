using RandomApp.Controls;
using RandomApp.iOS.Renderers;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RandomApp.iOS.Extensions;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace RandomApp.iOS.Renderers
{
	public class CustomEntryRenderer : EntryRenderer
	{
		IKeyboardToolbar KeyboardToolbar => Element as IKeyboardToolbar;

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			//if (Control != null)
			//{
			//	Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
			//	Control.BorderStyle = UITextBorderStyle.Line;
			//}

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
				Control.DisposeCustomKeyboard();

				if (KeyboardToolbar != null)
					KeyboardToolbar.OnResetKeyboard -= Element_OnResetKeyboard;

				//Control.BackgroundColor = UIColor.FromRGB(13, 13, 13);
			}

			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers
				Control.BorderStyle = UITextBorderStyle.None;

				Control.AddToolbar(KeyboardToolbar);

				if (KeyboardToolbar != null)
					KeyboardToolbar.OnResetKeyboard += Element_OnResetKeyboard;

				//ontrol.BackgroundColor = UIColor.FromRGB(100, 100, 100);

			}
		}

		void Element_OnResetKeyboard(object sender, EventArgs e)
		{
			Control.DisposeCustomKeyboard();
			Control.AddToolbar(KeyboardToolbar);
		}
	}
}