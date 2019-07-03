using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

using ThisApp.Droid.Renderers;
using ThisApp.Controls;
using ThisApp.Droid.Extensions;


[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]

namespace ThisApp.Droid.Renderers
{
	public class CustomEditorRenderer : EditorRenderer
	{
		CustomEditor ElementEx => (CustomEditor)Element;

		public CustomEditorRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers
				Control.RemoveBottomLine();
				UpdatePlaceholder();
				UpdatePlaceholderColor();

				SetTextColor();
			}
		}

		void UpdatePlaceholder()
		{
			Control.Hint = ElementEx.Placeholder;
		}

		void UpdatePlaceholderColor()
		{
			Control.SetHintTextColor(ElementEx.PlaceholderColor.ToAndroid());
		}

		void SetTextColor()
		{
			Control.SetTextColor(Element.TextColor.ToAndroid());
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