using ThisApp.Controls;
using ThisApp.iOS.Renderers;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ThisApp.iOS.Extensions;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace ThisApp.iOS.Renderers
{
	public class CustomEntryRenderer : EntryRenderer
	{
		IKeyboardToolbar KeyboardToolbar => Element as IKeyboardToolbar;

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
				Control.DisposeCustomKeyboard();

				if (KeyboardToolbar != null)
					KeyboardToolbar.OnResetKeyboard -= Element_OnResetKeyboard;
			}

			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers
				Control.BorderStyle = UITextBorderStyle.None;

				Control.AddToolbar(KeyboardToolbar);

				if (KeyboardToolbar != null)
					KeyboardToolbar.OnResetKeyboard += Element_OnResetKeyboard;
			}
		}

		void Element_OnResetKeyboard(object sender, EventArgs e)
		{
			Control.DisposeCustomKeyboard();
			Control.AddToolbar(KeyboardToolbar);
		}
	}
}