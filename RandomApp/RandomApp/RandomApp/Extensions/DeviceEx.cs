using System;
using System.Threading.Tasks;

namespace Xamarin.Forms
{
	public static class DeviceEx
	{
		public static Task<bool> BeginInvokeOnMainThreadAsync(Action action)
		{
			var tcs = new TaskCompletionSource<bool>();

			Device.BeginInvokeOnMainThread(() =>
			{
				try
				{
					action();

					tcs.SetResult(true);
				}
				catch (Exception ex)
				{
					tcs.SetException(ex);
				}
			});

			return tcs.Task;
		}

		public static Task<bool> BeginInvokeOnMainThreadAsync(Task task)
		{
			var tcs = new TaskCompletionSource<bool>();

			Device.BeginInvokeOnMainThread(async () =>
			{
				try
				{
					await task;

					tcs.SetResult(true);
				}
				catch (Exception ex)
				{
					tcs.SetException(ex);
				}
			});

			return tcs.Task;
		}
	}
}