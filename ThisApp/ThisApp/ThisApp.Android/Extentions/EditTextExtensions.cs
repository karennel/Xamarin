﻿using Android.Graphics;
using Android.Widget;

namespace ThisApp.Droid.Extensions
{
	public static class EditTextExtensions
	{
		public static void RemoveBottomLine(this EditText control)
		{
			try
			{
				control?.SetBackgroundColor(Color.Transparent);
			}
			catch
			{
			}
		}
	}
}
