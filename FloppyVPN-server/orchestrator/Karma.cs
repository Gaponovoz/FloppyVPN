namespace FloppyVPN
{
	/// <summary>
	/// A class to regulate access to APIs. 
	/// Includes request counting, filtering system, checking for misusage, banning.
	/// </summary>
	internal class Karma
	{
		/// <summary>
		/// For request logging and misusage determination
		/// </summary>
		public enum LogRequestResources
		{
			idk,
			registration,
			login,
			master_key_failed_usage
		}

		string hashed_ip_address;
		DataRow karmaData;

		/// <summary>
		/// Last hours during which misusage will be checked.
		/// Recommended to set between 24 and 1.
		/// Must be negative
		/// </summary>
		readonly double LastHoursToCheckMisusageIn = -8;

		/// <summary>
		/// How many failed requests per check period are allowed until user gets a ban
		/// </summary>
		readonly ulong MaximumFailedRequestsAllowed = 12;

		/// <summary>
		/// How many registrations per check period are allowed until user gets a softban
		/// </summary>
		readonly byte MaximumRegistrationsAllowedPerPeriod = 10;

		/// <summary>
		/// How many failed master key usages allowed until server gets a permanent ban
		/// </summary>
		readonly byte MaximumFailedMasterKeyUsages = 2;


		public Karma(string hashed_ip_address)
		{
			this.hashed_ip_address = hashed_ip_address;
			RefreshKarmaDataAndCreateIfNotExistsYet();
		}

		private void RefreshKarmaDataAndCreateIfNotExistsYet()
		{
			DataTable karmas = DB.GetDataTable("SELECT * FROM `karmas` " +
				"WHERE `hashed_ip_address` = @hashed_ip_address;", 
				new Dictionary<string, object>()
				{
					{ "@hashed_ip_address", hashed_ip_address },
				});

			if (karmas.Rows.Count <= 0) //create karma for user if not exist yet:
			{
				ulong newKarmaID = DB.InsertAndGetID("INSERT INTO karmas " +
					"(hashed_ip_address, times_banned, banned_till, softbanned_till) " +
					"VALUES(@hashed_ip_address, @times_banned, @banned_till, @softbanned_till);", 
					new Dictionary<string, object>()
					{
						{ "@hashed_ip_address", hashed_ip_address },
						{ "@times_banned", (byte)0 },
						{ "@banned_till", DateTime.MinValue },
						{ "@softbanned_till", DateTime.MinValue },
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
		public void LogRequest(LogRequestResources requestedResource, bool isRequestSuccessful)
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

		public void LogRequestAsync(LogRequestResources requestedResource, bool isRequestSuccessful = true)
		{
			new Task(() => LogRequest(requestedResource, isRequestSuccessful)).Start();
		}

		/// <summary>
		/// Not just performs check but also bans if misuage is detected
		/// </summary>
		private void CheckIpForMisusageAndTakeActions()
		{
			//if user already banned, return.
			if (IsBanned())
				return;

			ulong failedRequestsAmount = GetFailedRequestsCount(DateTime.Now.AddHours(LastHoursToCheckMisusageIn), DateTime.Now);
			ulong registrationsCount = GetRegistrationsCount(DateTime.Now.AddHours(LastHoursToCheckMisusageIn), DateTime.Now);
			ulong masterKeyFailedUsagesCount = GetMasterKeyFailedUsagesCount(DateTime.Now.AddHours(LastHoursToCheckMisusageIn), DateTime.Now);

			//limits exceeding leads to a ban or a softban:

			if (failedRequestsAmount > MaximumFailedRequestsAllowed)
			{
				Ban(hashed_ip_address);
				RefreshKarmaDataAndCreateIfNotExistsYet();
			}
			if (registrationsCount > MaximumRegistrationsAllowedPerPeriod)
			{
				SoftBan(hashed_ip_address);
				RefreshKarmaDataAndCreateIfNotExistsYet();
			}
			if (masterKeyFailedUsagesCount > MaximumFailedMasterKeyUsages)
			{
				EternalBan(hashed_ip_address);
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

		ulong GetMasterKeyFailedUsagesCount(DateTime periodFrom, DateTime periodTo)
		{
			string query = "SELECT COUNT(*) AS record_count FROM `requests` " +
				"WHERE `hashed_ip_address` = @hashed_ip_address AND `request` = @request AND `date_time` >= @start_datetime AND `date_time` <= @end_datetime;";

			Dictionary<string, object> parameters = new()
				{
					{ "@request", LogRequestResources.master_key_failed_usage.ToString() },
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
				{ 0, 0.06 },
				{ 1, 0.2  },
				{ 2, 0.3  },
				{ 3, 0.4  },
				{ 4, 1    },
				{ 5, 2    },
				{ 6, 4    },
				{ 7, 8    },
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
		
		public void EternalBan(string hashed_ip_address)
		{
			DateTime bannedTill = DateTime.MaxValue;

			//write new ban time of the user to the table:
			DB.Execute("UPDATE `karmas` SET `banned_till` = @bannedtill, `times_banned` = @times_banned " +
				"WHERE `hashed_ip_address` = @hashed_ip_address",
				new Dictionary<string, object>()
				{
					{ "@times_banned", (byte)7 },
					{ "@bannedtill", bannedTill },
					{ "@hashed_ip_address", hashed_ip_address }
				});

			DB.Log("EternalBan()", "A new user(server) has just got banned for eternity!");

			RefreshKarmaDataAndCreateIfNotExistsYet();
		}

		public void SoftBan(string hashed_ip_address)
		{
			if (IsBanned())
				return;

			Dictionary<byte, double> softBanLengthsInHoursDependingOnTimesBanned = new()
			{
				{ 0, 0.15 },
				{ 1, 0.4  },
				{ 2, 1    },
				{ 3, 3    },
				{ 4, 6    },
				{ 5, 12   },
				{ 6, 24   },
				{ 7, 48   },
				{ 8, 999  },
				{ 9, 9999 }
			};

			byte timesBanned = byte.Parse(karmaData["times_banned"].ToString());
			DateTime softbannedTill = DateTime.Now;

			if (softBanLengthsInHoursDependingOnTimesBanned.ContainsKey(timesBanned))
			{
				double hoursToBanFor = softBanLengthsInHoursDependingOnTimesBanned[timesBanned];
				softbannedTill = softbannedTill.AddHours(hoursToBanFor);

				if (hoursToBanFor < LastHoursToCheckMisusageIn)
					ClearRequestsOfCheckPeriod(); //read the summary of the method
			}
			else //if possible amount of bans exceeded - ban forever
			{
				softbannedTill = DateTime.MaxValue;
			}

			//write new ban time of the user to the table:
			DB.Execute("UPDATE `karmas` SET `softbanned_till` = @softbanned_till " +
				"WHERE `hashed_ip_address` = @hashed_ip_address",
				new Dictionary<string, object>()
				{
					{ "@softbanned_till", softbannedTill },
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