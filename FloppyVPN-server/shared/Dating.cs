using System.Globalization;

namespace FloppyVPN
{
	public static class Dating
	{
		public static readonly string dateTimeString = "yyyy'.'MM'.'dd' 'HH':'mm':'ss";
		public static readonly string dateString = "yyyy'.'MM'.'dd";
		public static readonly string timeString = "HH':'mm':'ss";

		public static DateTime ToDate(this string s)
		{
			return DateTime.ParseExact(s, dateString, CultureInfo.InvariantCulture);
		}

		public static DateTime ToDateTime(this string s)
		{
			return DateTime.ParseExact(s, dateTimeString, CultureInfo.InvariantCulture);
		}

		public static string ToDate(this DateTime dt)
        {
            return dt.ToString(dateString);
        }

        public static string ToDateTime(this DateTime dt)
        {
            return dt.ToString(dateTimeString);
        }

		public static long UnixTimeNow()
		{
			return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		}
	}
}