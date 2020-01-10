using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.Helpers
{
  public static class Helper
  {

    //static readonly Lazy<ILauncher> Launcher = new Lazy<ILauncher>(() => ObjectFactory.Get<ILauncher>());

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
    //  return CreateCommand(async () => await NavigatorStatic.Instance.Value.PushFeature(feature));
    //}

    //public static ICommand CreateOpenUriCommand(string url)
    //{
    //  return CreateCommand(() => Launcher.Value.TryOpenAsync(url));
    //}

    //public static ICommand CreateMailToCommand(string url)
    //{
    //  return CreateOpenUriCommand($"{MailTo}:{url}");
    //}

    //public static ICommand CreateTelCommand(string url)
    //{
    //  return CreateOpenUriCommand($"{Tel}:{url}");
    //}

    //public static ObservableCollectionEx<T> CreateSynchronizedObservableCollection<T>()
    //{
    //  var result = new ObservableCollectionEx<T>();

    //  BindingBase.EnableCollectionSynchronization(result, null, ObservableCollectionCallback);

    //  return result;
    //}

    //static void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
    //{
    //  lock (collection)
    //    accessMethod?.Invoke();
    //}
  }
}
