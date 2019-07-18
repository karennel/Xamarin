using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomApp
{
	public static class XFHelper
	{
		const string MailTo = "mailto";
		const string Tel = "tel";

		public static ICommand CreateCommand(Action action)
		{
			return new Command(action);
		}

		public static ICommand CreateCommand<T>(Action<T> action)
		{
			return new Command<T>(action);
		}

		public static ICommand CreateCommand<T>(Action<T> action, Func<T, bool> canExecute)
		{
			return new Command<T>(action, canExecute);
		}

		public static ICommand CreateCommand(Action action, Func<bool> canExecute)
		{
			return new Command(action, canExecute);
		}

		//public static ICommand CreatePushFeatureCommand(Feature feature)
		//{
		//	return CreateCommand(async () => await NavigatorStatic.Instance.Value.PushFeature(feature));
		//}

		public static ICommand CreateOpenUriCommand(string url)
		{
			return CreateCommand(() => Device.OpenUri(new Uri(url)));
		}

		public static ICommand CreateMailToCommand(string url)
		{
			return CreateOpenUriCommand($"{MailTo}:{url}");
		}

		public static ICommand CreateTelCommand(string url)
		{
			return CreateOpenUriCommand($"{Tel}:{url}");
		}
	}
}
