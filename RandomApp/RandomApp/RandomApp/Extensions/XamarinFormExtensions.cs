using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Xamarin.Forms
{
	public static class XamarinFormsExtensions
	{
		public static T GetValue<T>(this BindableObject bindableObject, BindableProperty property)
		{
			return (T)bindableObject.GetValue(property);
		}
	}
}
