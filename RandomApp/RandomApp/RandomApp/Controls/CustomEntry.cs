using System;
using Xamarin.Forms;

namespace RandomApp.Controls
{
	public class CustomEntry : Entry, IKeyboardToolbar
	{
		public VisualElement Previous { get; set; }

		public VisualElement Next { get; set; }

		public Func<VisualElement> PreviousAction { get; set; }

		public Func<VisualElement> NextAction { get; set; }

		public event EventHandler OnResetKeyboard;

		public void InvokeResetKeyboard()
		{
			OnResetKeyboard?.Invoke(this, EventArgs.Empty);
		}
	}
}
