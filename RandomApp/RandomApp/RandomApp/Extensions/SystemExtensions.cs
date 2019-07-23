using System;
using System.Text;

namespace RandomApp
{
	public static class SystemExtensions
	{
		public static void Invoke<T>(this EventHandler<EventArgs<T>> handler, object sender, T value)
		{
			handler?.Invoke(sender, new EventArgs<T>(value));
		}

		public static string ToLogString(this TimeSpan ts)
		{
			if (ts.TotalSeconds < 1)
				return string.Format("{0} milliseconds", Convert.ToInt32(ts.TotalMilliseconds));
			else
				return string.Format("{0:f4} seconds", ts.TotalSeconds);
		}

		public static string ToLogString(this Exception ex)
		{
			var sb = new StringBuilder();

			sb.AppendLine(ex.Message);

			if (ex.InnerException == null)
				return sb.ToString();

			sb.AppendLine(ex.InnerException.ToLogString());

			return sb.ToString();
		}

		public static DateTimeOffset? ToNullable(this DateTimeOffset offset)
		{
			return offset == DateTimeOffset.MinValue ? (DateTimeOffset?)null : offset;
		}

		public static DateTime? ToUtcDateTime(this DateTimeOffset? offset)
		{
			return offset.HasValue ? offset.Value.UtcDateTime : (DateTime?)null;
		}

		public static string ToDateTimeString(this DateTimeOffset offset)
		{
			return offset.ToString($"{ConfigStatic.Instance.Value.DateFormat} {ConfigStatic.Instance.Value.TimeFormat}");
		}

		public static int? ToNullableInt(this string value)
		{
			return int.TryParse(value, out int result) ? result : (int?)null;
		}

		public static string GetInnermostException(this Exception ex)
		{
			var innermostEx = ex;

			while (innermostEx.InnerException != null)
				innermostEx = innermostEx.InnerException;

			return innermostEx.Message;
		}
	}
}
