using System.ComponentModel;

using RandomApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(FocusEffect), nameof(FocusEffect))]

namespace RandomApp.Droid.Effects
{
	public class FocusEffect : PlatformEffect
	{
		Android.Graphics.Color backgroundcolor;

		protected override void OnAttached()
		{
			backgroundcolor = Android.Graphics.Color.CornflowerBlue;
			Control.SetBackgroundColor(backgroundcolor);
		}

		protected override void OnDetached()
		{

		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);

			if (args.PropertyName == "IsFocused")
			{
				if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == backgroundcolor)
				{
					Control.SetBackgroundColor(Android.Graphics.Color.White);
				}
				else
				{
					Control.SetBackgroundColor(backgroundcolor);
				}
			}
		}
	}
}
