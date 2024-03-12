namespace FloppyVPN
{
	/// <summary>
	/// A class to manage and regulate access to APIs. 
	/// Includes request counting, filtering system, checking.
	/// </summary>
	internal static class Karma
	{



		/// <summary>
		/// Adds a request to the table of requests.
		/// Also, if this ip address has no karma record yet, create one
		/// </summary>
		public static void LogRequest(string hashed_ip_address, string requested_resource)
		{
			
		}

		private static void CheckIpForMisusageAndTakeActions(string hashed_ip_address)
		{
			long failedRequestsThreshold = 50;

			long requests = long.Parse((DB.GetValue($"", 
				new Dictionary<string, object>()
				{
					{ "@hashed_ip_address", hashed_ip_address }
				}) ?? "0").ToString());


			if (requests > failedRequestsThreshold) //exceeded => ban!
			{
				Ban(hashed_ip_address);
			}
		}

		/// <summary>
		/// Bans a user in a smart way depending on his previous reputation (amount of bans in the past).
		/// First few bans are quite short but the following ones are extremely strict
		/// </summary>
		private static void Ban(string hashed_ip_address)
		{
			DataTable userKarma = DB.GetDataTable("SELECT * FROM `karma` " +
				$"WHERE `hashed_ip_address` = {hashed_ip_address};");

			if (userKarma.Rows.Count <= 0)
				return;

			Dictionary<byte, double> banLengthsInHoursDependingOnTimesBanned = new()
			{
				{ 0, 0.15 },
				{ 1, 0.4  },
				{ 2, 2    },
				{ 3, 12   },
				{ 4, 24   },
				{ 5, 48   },
				{ 6, 200  },
				{ 7, 9999 },
			};

			byte timesBanned = byte.Parse(userKarma.Rows[0][""].ToString());
			DateTime bannedTill = DateTime.Now.AddSeconds(-1);

			if (banLengthsInHoursDependingOnTimesBanned.ContainsKey(timesBanned))
			{
				double hoursToBanFor = banLengthsInHoursDependingOnTimesBanned[timesBanned];
				bannedTill.AddHours(hoursToBanFor);
			}
			else //if possible amount of bans exceeded - ban forever
			{
				bannedTill = DateTime.MaxValue;
			}

			//write new ban time of the user to the table:
			DB.Execute("UPDATE `karmas` SET `banned_till` = @bannedtill WHERE `hashed_ip_address` = @hashed_ip_address", 
				new Dictionary<string, object>()
				{
					{ "@bannedtill", bannedTill },
					{ "@hashed_ip_address", hashed_ip_address }
				});
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