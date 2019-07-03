using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ThisApp.Behaviour
{
	public class AlphaEntryBehaviour : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry bindable)
		{
			base.OnAttachedTo(bindable);
			bindable.TextChanged += OnEntryTextChanged;
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			base.OnDetachingFrom(bindable);
			bindable.TextChanged -= OnEntryTextChanged;
		}


		void OnEntryTextChanged(object sender, TextChangedEventArgs e)
		{

			const string numberRegex = @"^[a-zA-Z]+$";
			bool IsValid = true;
			if (!string.IsNullOrWhiteSpace(e.NewTextValue))
			{
				IsValid = (Regex.IsMatch(e.NewTextValue, numberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
				((Entry)sender).Text = IsValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
			}
		}
	}
}
