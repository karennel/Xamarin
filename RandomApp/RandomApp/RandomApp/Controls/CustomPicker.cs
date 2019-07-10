using System;
using Xamarin.Forms;

namespace RandomApp.Controls
{
	public class CustomPicker : Picker, IKeyboardToolbar
	{
		public static BindableProperty PlaceholderProperty =
			BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(CustomPicker), default(string));

		public static BindableProperty PlaceholderColorProperty =
			BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(CustomPicker), Color.Default);

		public string Placeholder
		{
			get => this.GetValue<string>(PlaceholderProperty);
			set => SetValue(PlaceholderProperty, value);
		}

		public Color PlaceholderColor
		{
			get => this.GetValue<Color>(PlaceholderColorProperty);
			set => SetValue(PlaceholderColorProperty, value);
		}

		public Action<bool> IsSelected { get; set; }

		public VisualElement Previous { get; set; }

		public VisualElement Next { get; set; }

		public Func<VisualElement> PreviousAction { get; set; }

		public Func<VisualElement> NextAction { get; set; }

		public event EventHandler OnResetKeyboard;

		public CustomPicker()
		{
			SelectedIndexChanged += CustomPicker_SelectedIndexChanged;
		}

		void CustomPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			IsSelected?.Invoke(SelectedIndex != -1);
		}

		public void InvokeResetKeyboard()
		{
			OnResetKeyboard?.Invoke(this, EventArgs.Empty);
		}
	}
}