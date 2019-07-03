using Xamarin.Forms;

namespace ThisApp.Controls
{
	public class CustomEditor : Editor
	{
		public static readonly BindableProperty PlaceholderProperty =
			BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(CustomEditor));

		public static readonly BindableProperty PlaceholderColorProperty =
			BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(CustomEditor), Color.Gray);

		public string Placeholder
		{
			get { return this.GetValue<string>(PlaceholderProperty); }
			set { SetValue(PlaceholderProperty, value); }
		}

		public Color PlaceholderColor
		{
			get { return this.GetValue<Color>(PlaceholderColorProperty); }
			set { SetValue(PlaceholderColorProperty, value); }
		}

		public CustomEditor()
		{
			this.TextChanged += CustomEditor_TextChanged;
		}

		void CustomEditor_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.InvalidateMeasure();
		}
	}
}
