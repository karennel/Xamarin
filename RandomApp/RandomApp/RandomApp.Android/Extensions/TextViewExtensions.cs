using Android.Views.InputMethods;
using Android.Widget;
using Xamarin.Forms;

using RandomApp.Controls;

namespace RandomApp.Droid.Extensions
{
	public static class TextViewExtensions
	{
		public static void AddToolbar(this TextView control, Entry entry, IKeyboardToolbar keyboardToolbar)
		{
			try
			{
				var previous = keyboardToolbar?.GetPrevious();
				var next = keyboardToolbar?.GetNext();

				if (keyboardToolbar == null || (previous == null && next == null))
				{
					control.ImeOptions = ImeAction.Done;
					control.SetImeActionLabel("Done", ImeAction.Done);
				}
				else
				{
					if (previous == null)
					{
						control.ImeOptions = ImeAction.Next;
						control.SetImeActionLabel("Next", ImeAction.Next);
						control.EditorAction += (s, e) =>
						{
							entry.Unfocus();
							next.Focus();
						};
					}
					else if (next == null)
					{
						control.ImeOptions = ImeAction.Done;
						control.SetImeActionLabel("Done", ImeAction.Done);
						control.EditorAction += (s, e) =>
						{
							entry.Unfocus();
						};
					}
					else
					{
						control.ImeOptions = ImeAction.Next;
						control.SetImeActionLabel("Next", ImeAction.Next);
						control.EditorAction += (s, e) =>
						{
							entry.Unfocus();
							next.Focus();
						};
					}
				}
			}
			catch
			{
			}
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