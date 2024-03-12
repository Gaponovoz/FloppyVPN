using Org.BouncyCastle.Asn1.Ocsp;

namespace FloppyVPN
{
	/// <summary>
	/// A class to regulate access to APIs. 
	/// Includes request counting, filtering system, checking for misusage, banning.
	/// </summary>
	internal class Karma
	{
		string hashed_ip_address;
		DataRow karmaRow;

		public Karma(string hashed_ip_address)
		{
			this.hashed_ip_address = hashed_ip_address;
			RefreshKarmaInfoAndCreateIfNotExistsYet();
		}

		private void RefreshKarmaInfoAndCreateIfNotExistsYet()
		{
			DataTable karmas = DB.GetDataTable("SELECT * FROM `karma` " +
				"WHERE `hashed_ip_address` = @hashed_ip_address;", 
				new Dictionary<string, object>()
				{
					{ "@hashed_ip_address", hashed_ip_address },
				});

			if (karmas.Rows.Count <= 0)
			{
				//create karma for user because it does not exist yet:
				ulong newKarmaID = DB.InsertAndGetID("INSERT INTO karmas " +
					"(hashed_ip_address, banned_till, times_banned) " +
					"VALUES(@hashed_ip_address, @banned_till, @times_banned);", 
					new Dictionary<string, object>()
					{
						{ "@hashed_ip_address", hashed_ip_address },
						{ "@banned_till", DateTime.MinValue },
						{ "@times_banned", (byte)0 }
					});
			}
			else
			{
				this.karmaRow = karmas.Rows[0];
			}
		}


		/// <summary>
		/// Adds a request to the table of requests.
		/// Also, if this ip address has no karma record yet, create one
		/// </summary>
		public void LogRequest(string requested_resource)
		{
			
		}

		/// <summary>
		/// Checks
		/// </summary>
		/// <param name="hashed_ip_address"></param>
		private void CheckIpForMisusageAndTakeActions()
		{
			//if user already banned, return.
			DateTime bannedTill = (DateTime)karmaRow["banned_till"];

			ulong failedRequestsAmount = GetRegistrationsCount(DateTime.Now.AddHours(-24), DateTime.Now);
			ulong failedRequestsThreshold = 5;

			ulong registrationsCount = 0;
			ulong registrationsLimit = 10;




			if (failedRequestsAmount > failedRequestsThreshold) //exceeded => ban!
			{
				Ban(hashed_ip_address);
			}

			RefreshKarmaInfoAndCreateIfNotExistsYet();
		}


		ulong GetFailedRequestsCount(DateTime periodFrom, DateTime periodTo)
		{
			string query = "SELECT COUNT(*) AS record_count FROM `requests` " +
				"WHERE `date_time` >= @start_datetime AND `date_time` <= @end_datetime;";

			Dictionary<string, object> parameters = new()
				{
					{ "@start_datetime", periodFrom },
					{ "@end_datetime", periodTo }
				};

			return Convert.ToUInt64(DB.GetValue(query, parameters));
		}

		ulong GetRegistrationsCount(DateTime periodFrom, DateTime periodTo)
		{
			string query = "SELECT COUNT(*) AS record_count FROM `requests` " +
				"WHERE `date_time` >= @start_datetime AND `date_time` <= @end_datetime;";

			Dictionary<string, object> parameters = new()
				{
					{ "@start_datetime", periodFrom },
					{ "@end_datetime", periodTo }
				};

			return Convert.ToUInt64(DB.GetValue(query, parameters));
		}

		/// <summary>
		/// Bans a user in a smart way depending on his previous reputation (amount of bans in the past).
		/// First few bans are quite short but the following ones are extremely strict
		/// </summary>
		public void Ban(string hashed_ip_address)
		{
			if (IsBanned())
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

			byte timesBanned = byte.Parse(karmaRow["times_banned"].ToString());
			DateTime bannedTill = DateTime.Now;

			if (banLengthsInHoursDependingOnTimesBanned.ContainsKey(timesBanned))
			{
				double hoursToBanFor = banLengthsInHoursDependingOnTimesBanned[timesBanned];
				bannedTill = bannedTill.AddHours(hoursToBanFor);
			}
			else //if possible amount of bans exceeded - ban forever
			{
				bannedTill = DateTime.MaxValue;
			}

			//write new ban time of the user to the table:
			DB.Execute("UPDATE `karmas` SET `banned_till` = @bannedtill " +
				"WHERE `hashed_ip_address` = @hashed_ip_address", 
				new Dictionary<string, object>()
				{
					{ "@bannedtill", bannedTill },
					{ "@hashed_ip_address", hashed_ip_address }
				});

			RefreshKarmaInfoAndCreateIfNotExistsYet();
		}

		public bool IsBanned()
		{
			DateTime banned_till = (DateTime)karmaRow[""];

			if (banned_till > DateTime.Now)
				return true;
			else
				return false;
		}

	}
}