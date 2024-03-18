using System.Security.Cryptography;

namespace FloppyVPN
{
	public class Account
	{
		public bool exists = false;
		public string login;
		public DateTime date_registered;
		public DateTime paid_till;   //if "paid_till" equals "date_registered" - the account is just created
		public int days_left;

		public DataRow? accountData = null;

		public Account(string login)
		{
			//login can be entered either with or without the delimiting symbol
			login = login.Replace("-", "");
			login = login.Insert(login.Length / 2, "-");

			this.login = login;

			//check if account exists
			DataTable accounts = DB.GetDataTable($"SELECT * FROM `accounts` WHERE `login` = @login;", 
				new Dictionary<string, object>()
				{
					{ "@login", login }
				});

			if (accounts.Rows.Count == 1)
			{
				exists = true;
			}
			else
			{
				exists = false;
				return;
			}


			RefreshData();
		}

		private void RefreshData()
		{
			accountData = DB.GetDataTable($"SELECT * FROM `accounts` WHERE `login` = @login;",
				new Dictionary<string, object>()
				{
					{ "@login", login }
				}).Rows[0];

			login = accountData["login"].ToString();
			date_registered = (DateTime)accountData["when_registered"];
			paid_till = (DateTime)accountData["paid_till"];
			RefreshDaysLeft();
		}

		protected void RefreshDaysLeft()
		{
			try
			{
				days_left = (int)Math.Ceiling((paid_till - DateTime.Now).TotalDays);
			}
			catch
			{
				days_left = (int)0;
			}

			DB.Execute($"UPDATE `accounts` SET `days_left` = @days_left WHERE `id` = @id;",
				new Dictionary<string, object>()
				{
					{ "@days_left", days_left },
					{ "@id", (ulong)accountData["id"] }
				});
		}

		/// <param name="months">Amount of months to add to account's balance.</param>
		/// <returns>A DateTime till which account is paid.</returns>
		public DateTime AddTime(ushort months)
		{
			DateTime new_paid_till = paid_till.AddMonths(months);

			DB.Execute($"UPDATE `accounts` SET `paid_till` = @new_paid_till WHERE `login` = @login;", 
				new Dictionary<string, object>()
				{
					{ "@new_paid_till", new_paid_till },
					{ "@login", login }
				});

			RefreshData();
			return new_paid_till;
		}

		/// <summary>
		/// Registers a new account.
		/// </summary>
		/// <returns>A fresh brand new account</returns>
		public static Account Register()
		{
			string new_login = GenerateUniqueLogin();
			DateTime now = DateTime.Now;
			DateTime when_registered = now;
			DateTime paid_till = now;

			ulong new_account_id = DB.InsertAndGetID("INSERT INTO `accounts` " +
				"(`login`, `when_registered`, `paid_till`) " +
				"VALUES " +
				"(@login, @when_registered, @paid_till);", 
				new Dictionary<string, object>()
				{
					{ "@login", new_login },
					{ "@when_registered", when_registered },
					{ "@paid_till", paid_till }
				});

			Thread.Sleep(123);

			return new Account(new_login);
		}

		private static string GenerateUniqueLogin()
		{
			const string dic = "qwetipasdfghjkzcvb123456789"; //possible account characters dictionary
			string new_login = "";

			for (uint u = 0; u < uint.MaxValue; u++) //a safer alternative to forever loop
			{
				new_login = $"{Cryption.GenerateRandomString(4, dic)}-{Cryption.GenerateRandomString(4, dic)}";
				
				DataTable loginExistances = DB.GetDataTable($"SELECT * FROM `accounts` WHERE " +
					$"`login` = @new_login;",
					new Dictionary<string, object>()
					{
						{ "@new_login", new_login }
					});

				if (loginExistances.Rows.Count <= 0)
					break;
			}

			if (new_login == "")
				throw new Exception("Could not generate a unique login");
			else
				return new_login;
		}

	}
}