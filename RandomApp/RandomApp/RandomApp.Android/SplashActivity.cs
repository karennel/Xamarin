using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;

namespace RandomApp.Droid
{

	[Activity
	 (
		 Label = "RandomApp",
		 MainLauncher = true,
		 NoHistory = true,
		 ScreenOrientation = ScreenOrientation.Portrait,
		 Icon = "@drawable/icon",
		 Theme = "@style/MainTheme.Splash"
	 )]

	public class SplashActivity : Activity
	{

		static readonly string TAG = "X:" + typeof(SplashActivity).Name;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		}

		// Launches the startup task
		protected override void OnResume()
		{
			base.OnResume();
			Task startupWork = new Task(() => { SimulateStartup(); });
			startupWork.Start();
		}

		// Prevent the back button from canceling the startup process
		public override void OnBackPressed() { }

		// Simulates background work that happens behind the splash screen
		async void SimulateStartup()
		{
			Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
			await Task.Delay(8000); // Simulate a bit of startup work.
			Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
			
		}

	}
}