namespace FloppyVPN
{
	/// <summary>
	/// A class to manage and regulate access to APIs. 
	/// Includes request counting, filtering system, checking.
	/// </summary>
	internal static class Karma
	{
		/// <summary>
		/// Adds a request to the table of requests
		/// </summary>
		public static void LogRequest()
		{

		}

		public static void CheckIpForMisusageAndTakeActions(string hashed_ip_address)
		{

		}

		public static bool IsIpBanned(string hashed_ip_address)
		{
			DateTime banned_till = (DateTime)(DB.GetValue($"SELECT `banned_till` FROM `karma` " +
				$"WHERE `hashed_ip_address` = @hashed_ip_address;", 
				new Dictionary<string, object>()
				{
					{ "@hashed_ip_address", hashed_ip_address }
				}) ?? DateTime.MinValue);

			if (banned_till > DateTime.Now)
				return true;
			else
				return false;
		}
	}
}