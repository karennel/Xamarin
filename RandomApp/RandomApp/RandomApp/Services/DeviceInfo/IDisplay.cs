
namespace RandomApp.Services.DeviceInfo
{
	public interface IDisplay
	{
		/// <summary>
		/// Gets the screen width in pixels.
		/// For iOS, needs to be called from within a Device.BeginInvokeOnMainThread().
		/// </summary>
		int Width { get; }

		/// <summary>
		/// Gets the screen height in pixels
		/// For iOS, needs to be called from within a Device.BeginInvokeOnMainThread().
		/// </summary>
		int Height { get; }
	}
}