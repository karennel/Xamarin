using ThisApp;
using ThisApp.Controls;
//using ThisApp.Services.DeviceInfo;
using CoreAnimation;
using CoreGraphics;
using System;
using System.Drawing;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using ThisApp.Services.DeviceInfo;

namespace ThisApp.iOS.Extensions
{
	public static class UIKitExtensions
	{

		static Lazy<IDisplay> _display = new Lazy<IDisplay>(() => ObjectFactory.Get<IDisplay>());

		public static void DisposeCustomKeyboard(this UITextField textField)
		{
			if (textField == null)
				return;

			var toolbar = textField.InputAccessoryView;
			if (toolbar == null)
				return;

			try
			{
				toolbar.Dispose();

				textField.InputAccessoryView = null;
			}
			catch
			{
			}
		}

		public static void AddToolbar(this UITextField textField, IKeyboardToolbar keyboardToolbar)
		{
			if (textField == null)
				return;

			try
			{
				textField.KeyboardAppearance = UIKeyboardAppearance.Dark;

				var toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, _display.Value.Width, 44.0f))
				{
					TintColor = UIColor.White,
					BarStyle = UIBarStyle.Black,
					Translucent = true
				};

				var spaceButton = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
				var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { textField.ResignFirstResponder(); });

				var previous = keyboardToolbar?.GetPrevious();
				var next = keyboardToolbar?.GetNext();

				if (keyboardToolbar == null || (previous == null && next == null))
				{
					toolbar.Items = new UIBarButtonItem[]
					{
						spaceButton,
						doneButton
					};
				}
				else
				{
					if (previous == null)
						toolbar.Items = new UIBarButtonItem[]
						{
							doneButton,
							spaceButton,
							new UIBarButtonItem("Next", UIBarButtonItemStyle.Bordered, delegate { next.Focus(); })
						};
					else if (next == null)
						toolbar.Items = new UIBarButtonItem[]
						{
							spaceButton,
							new UIBarButtonItem("Prev", UIBarButtonItemStyle.Bordered, delegate { previous.Focus(); }),
							doneButton
						};
					else
						toolbar.Items = new UIBarButtonItem[]
						{
							doneButton,
							spaceButton,
							new UIBarButtonItem("Prev", UIBarButtonItemStyle.Bordered, delegate { previous.Focus(); }),
							new UIBarButtonItem("Next", UIBarButtonItemStyle.Bordered, delegate { next.Focus(); })
						};
				}

				textField.InputAccessoryView = toolbar;
			}
			catch
			{
			}
		}

		public static void SubviewsDoNotTranslateAutoresizingMaskIntoConstraints(this UIView view)
		{
			foreach (var subview in view.Subviews)
				subview.TranslatesAutoresizingMaskIntoConstraints = false;
		}

		static VisualElement GetPrevious(this IKeyboardToolbar keyboardToolbar)
		{
			return keyboardToolbar.PreviousAction == null ? keyboardToolbar.Previous : keyboardToolbar.PreviousAction();
		}

		static VisualElement GetNext(this IKeyboardToolbar keyboardToolbar)
		{
			return keyboardToolbar.NextAction == null ? keyboardToolbar.Next : keyboardToolbar.NextAction();
		}

	}
}