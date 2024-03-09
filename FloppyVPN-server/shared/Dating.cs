using System.Globalization;

namespace FloppyVPN
{
	public static class Dating
	{
		public static readonly string dateTimeString = "yyyy'.'MM'.'dd' 'HH':'mm':'ss";
		public static readonly string dateString = "yyyy'.'MM'.'dd";
		public static readonly string timeString = "HH':'mm':'ss";

		public static string DateNow()
		{
			return DateTime.Now.ToString(dateString);
		}

		public static string DateTimeNow()
		{
			return DateTime.Now.ToString(dateTimeString);
		}

		public static string TimeNow()
		{
			return DateTime.Now.ToString(timeString);
		}

		public static DateTime ToDate(this string s)
		{
			return DateTime.Parse(s, CultureInfo.InvariantCulture);
		}

		public static DateTime ToDateTime(this string s)
		{
			return DateTime.Parse(s, CultureInfo.InvariantCulture);
		}

        public static string ToDate(this DateTime dt)
        {
            return dt.ToString(dateString);
        }

        public static string ToDateTime(this DateTime dt)
        {
            return dt.ToString(dateTimeString);
        }
    }
}