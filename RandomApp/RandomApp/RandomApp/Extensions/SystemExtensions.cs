using System.Text;

namespace System
{
	public static class SystemExtensions
	{

		public static string ToLogString(this TimeSpan ts)
		{
			if (ts.TotalSeconds < 1)
				return string.Format("{0} milliseconds", Convert.ToInt32(ts.TotalMilliseconds));
			else
				return string.Format("{0:f4} seconds", ts.TotalSeconds);
		}

	}
}
