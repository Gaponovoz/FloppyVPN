namespace FloppyVPN
{
	/// <summary>
	/// Used for creating aliases for account. 
	/// They are disposable yet are stored and can be used forever, 
	/// so you have as many aliases as you needed
	/// </summary>
	internal static class Aliasing
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="alias"></param>
		/// <returns>User login if such exists, null otherwise</returns>
		public static string? GetLoginFromAlias(string alias)
		{
			DataTable _loginFromAlias = DB.GetDataTable("SELECT `login` FROM `aliases` WHERE `alias` = @alias", 
				new Dictionary<string, object>()
				{
					{ "@alias", alias }
				});
			
			if (_loginFromAlias.Rows.Count <= 0)
				return null;
			else
				return _loginFromAlias.Rows[0][0].ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="login"></param>
		/// <returns></returns>
		public static string NewAliasForLogin(string login)
		{
			string new_alias = "";
			const string dic = "qazxcswedrfvgtbyhnujmkipol_";

			for (uint u = 0; u < uint.MaxValue; u++) //limit attempts to avoid forever loop
			{
				string try_alias = Cryption.GenerateRandomString(24, dic);

				DataTable aliasExistance = DB.GetDataTable("SELECT * FROM `aliases` WHERE `alias` = @try_alias;",
					new Dictionary<string, object>()
					{
						{ "@try_alias", try_alias }
					});

				if (aliasExistance.Rows.Count == 0)
				{
					new_alias = try_alias;

					DB.Execute("INSERT INTO `aliases` (`alias`, `login`) " +
						"VALUES (@alias, @login);",
						new Dictionary<string, object>()
						{
							{ "@alias", new_alias },
							{ "@login", login }
						});

					break;
				}
			}

			if (new_alias == "")
				throw new Exception("Could not manage to create a unique alias.");
			else
				return new_alias;
		}
	}
}