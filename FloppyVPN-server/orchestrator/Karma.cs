namespace FloppyVPN
{
	/// <summary>
	/// A class to regulate access to APIs. 
	/// Includes request counting, filtering system, checking for misusage, banning.
	/// </summary>
	internal class Karma
	{
		/// <summary>
		/// For request logging
		/// </summary>
		public enum LogRequestResources
		{
			idk,
			registration,
			login
		}

		string hashed_ip_address;
		DataRow karmaData;

		/// <summary>
		/// Last hours during which misusage will be checked.
		/// Not recommended to set more than 24 or less than 1.
		/// Must be negative
		/// </summary>
		readonly double LastHoursToCheckMisusageIn = -24;

		/// <summary>
		/// How many failed requests per check period are allowed until user gets a ban
		/// </summary>
		readonly ulong MaximumFailedRequestsAllowed = 12;

		/// <summary>
		/// How many registrations per check period are allowed until user gets a softban
		/// </summary>
		readonly byte MaximumRegistrationsAllowedPerPeriod = 10;

		public Karma(string hashed_ip_address)
		{
			this.hashed_ip_address = hashed_ip_address;
			RefreshKarmaDataAndCreateIfNotExistsYet();
		}

		private void RefreshKarmaDataAndCreateIfNotExistsYet()
		{
			DataTable karmas = DB.GetDataTable("SELECT * FROM `karma` " +
				"WHERE `hashed_ip_address` = @hashed_ip_address;", 
				new Dictionary<string, object>()
				{
					{ "@hashed_ip_address", hashed_ip_address },
				});

			if (karmas.Rows.Count <= 0) //create karma for user if not exist yet:
			{
				ulong newKarmaID = DB.InsertAndGetID("INSERT INTO karmas " +
					"(hashed_ip_address, banned_till, times_banned) " +
					"VALUES(@hashed_ip_address, @banned_till, @times_banned);", 
					new Dictionary<string, object>()
					{
						{ "@hashed_ip_address", hashed_ip_address },
						{ "@banned_till", DateTime.MinValue },
						{ "@times_banned", (byte)0 }
					});

				this.karmaData = DB.GetDataTable($"SELECT * FROM `karmas` WHERE `id` = {newKarmaID};").Rows[0];
			}
			else //if exists - just grab info
			{
				this.karmaData = karmas.Rows[0];
			}
		}


		/// <summary>
		/// Adds a request to the table of requests
		/// </summary>
		public void LogRequest(LogRequestResources requestedResource, bool isRequestSuccessful = true)
		{
			DB.Execute("INSERT INTO `requests` (`date_time`, hashed_ip_address, `successful`, `request`) " +
				"VALUES(@date_time, @hashed_ip_address, @successful, @request);", 
				new Dictionary<string, object>()
				{
					{ "@date_time", DateTime.Now },
					{ "@hashed_ip_address", (ulong)karmaData["id"] },
					{ "@successful", isRequestSuccessful },
					{ "@request", requestedResource.ToString() },
				});

			CheckIpForMisusageAndTakeActions();
		}

		/// <summary>
		/// Not just performs check but also bans if misuage is detected
		/// </summary>
		private void CheckIpForMisusageAndTakeActions()
		{
			//if user already banned, return.
			if (IsBanned())
				return;

			ulong failedRequestsAmount = GetRegistrationsCount(DateTime.Now.AddHours(LastHoursToCheckMisusageIn), DateTime.Now);
			ulong failedRequestsThreshold = 5;

			ulong registrationsCount = GetFailedRequestsCount(DateTime.Now.AddHours(LastHoursToCheckMisusageIn), DateTime.Now);


			//limits exceeding leads to ban:
			if ((failedRequestsAmount > MaximumFailedRequestsAllowed) || (registrationsCount > MaximumRegistrationsAllowedPerPeriod))
			{
				Ban(hashed_ip_address);
				RefreshKarmaDataAndCreateIfNotExistsYet();
			}
		}


		ulong GetFailedRequestsCount(DateTime periodFrom, DateTime periodTo)
		{
			string query = "SELECT COUNT(*) AS record_count FROM `requests` " +
				"WHERE `hashed_ip_address` = @hashed_ip_address AND `successful` = 0 AND `date_time` >= @start_datetime AND `date_time` <= @end_datetime;";

			Dictionary<string, object> parameters = new()
				{
					{ "@hashed_ip_address", (ulong)karmaData["id"] },
					{ "@start_datetime", periodFrom },
					{ "@end_datetime", periodTo }
				};

			return Convert.ToUInt64(DB.GetValue(query, parameters));
		}

		ulong GetRegistrationsCount(DateTime periodFrom, DateTime periodTo)
		{
			string query = "SELECT COUNT(*) AS record_count FROM `requests` " +
				"WHERE `hashed_ip_address` = @hashed_ip_address AND `request` = @request AND `date_time` >= @start_datetime AND `date_time` <= @end_datetime;";

			Dictionary<string, object> parameters = new()
				{
					{ "@request", LogRequestResources.registration.ToString() },
					{ "@hashed_ip_address", (ulong)karmaData["id"] },
					{ "@start_datetime", periodFrom },
					{ "@end_datetime", periodTo }
				};

			return Convert.ToUInt64(DB.GetValue(query, parameters));
		}

		/// <summary>
		/// Bans a user in a smart way depending on his previous reputation.
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

			byte timesBanned = byte.Parse(karmaData["times_banned"].ToString());
			DateTime bannedTill = DateTime.Now;

			if (banLengthsInHoursDependingOnTimesBanned.ContainsKey(timesBanned))
			{
				double hoursToBanFor = banLengthsInHoursDependingOnTimesBanned[timesBanned];
				bannedTill = bannedTill.AddHours(hoursToBanFor);

				if (hoursToBanFor < LastHoursToCheckMisusageIn)
					ClearRequestsOfCheckPeriod(); //read the summary of the method
			}
			else //if possible amount of bans exceeded - ban forever
			{
				bannedTill = DateTime.MaxValue;
			}

			//write new ban time of the user to the table:
			DB.Execute("UPDATE `karmas` SET `banned_till` = @bannedtill, `times_banned` = @times_banned " +
				"WHERE `hashed_ip_address` = @hashed_ip_address",
				new Dictionary<string, object>()
				{
					{ "@times_banned", timesBanned + 1 },
					{ "@bannedtill", bannedTill },
					{ "@hashed_ip_address", hashed_ip_address }
				});

			RefreshKarmaDataAndCreateIfNotExistsYet();
		}

		public void SoftBan(string hashed_ip_address)
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

			byte timesBanned = byte.Parse(karmaData["times_banned"].ToString());
			DateTime bannedTill = DateTime.Now;

			if (banLengthsInHoursDependingOnTimesBanned.ContainsKey(timesBanned))
			{
				double hoursToBanFor = banLengthsInHoursDependingOnTimesBanned[timesBanned];
				bannedTill = bannedTill.AddHours(hoursToBanFor);

				if (hoursToBanFor < LastHoursToCheckMisusageIn)
					ClearRequestsOfCheckPeriod(); //read the summary of the method
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

			RefreshKarmaDataAndCreateIfNotExistsYet();
		}

		public bool IsBanned()
		{
			DateTime banned_till = (DateTime)karmaData["banned_till"];

			if (banned_till > DateTime.Now)
				return true;
			else
				return false;
		}

		public bool IsSoftBanned()
		{
			DateTime banned_till = (DateTime)karmaData["softbanned_till"];

			if (banned_till > DateTime.Now)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Clears requests of past check period to avoid double-banning a user right after he gets unbanned
		/// </summary>
		void ClearRequestsOfCheckPeriod()
		{
			DateTime periodFrom = DateTime.Now.AddHours(LastHoursToCheckMisusageIn);
			DateTime periodTo = DateTime.Now;

			string query = "DELETE FROM `requests` WHERE `hashed_ip_address` = @hashed_ip_address " +
				"AND `date_time` >= @start_datetime AND `date_time` <= @end_datetime;";

			Dictionary<string, object> parameters = new()
				{
					{ "@hashed_ip_address", (ulong)karmaData["id"] },
					{ "@start_datetime", periodFrom },
					{ "@end_datetime", periodTo }
				};

			DB.Execute(query, parameters);
		}

	}
}