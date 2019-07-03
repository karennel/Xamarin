using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using ThisApp.Droid.Renderers;
using ThisApp.Controls;
using ThisApp.Droid.Extensions;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace ThisApp.Droid.Renderers
{
	public class CustomEntryRenderer : EntryRenderer
	{
		IKeyboardToolbar KeyboardToolbar => Element as IKeyboardToolbar;

		public CustomEntryRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
				if (KeyboardToolbar != null)
					KeyboardToolbar.OnResetKeyboard -= Element_OnResetKeyboard;
			}

			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers
				Control.RemoveBottomLine();

				Control.AddToolbar(Element, KeyboardToolbar);

				if (KeyboardToolbar != null)
					KeyboardToolbar.OnResetKeyboard += Element_OnResetKeyboard;
			}
		}

		void Element_OnResetKeyboard(object sender, System.EventArgs e)
		{
			Control.AddToolbar(Element, KeyboardToolbar);
		}
	}
}