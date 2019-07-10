using System;
using Xamarin.Forms;


namespace RandomApp.Controls
{
	public interface IKeyboardToolbar
	{
		VisualElement Previous { get; set; }

		VisualElement Next { get; set; }

		Func<VisualElement> PreviousAction { get; set; }

		Func<VisualElement> NextAction { get; set; }

		event EventHandler OnResetKeyboard;

		void InvokeResetKeyboard();
	}
}
