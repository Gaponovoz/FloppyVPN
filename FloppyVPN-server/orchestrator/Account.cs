using System.Security.Cryptography;

namespace FloppyVPN
{
	public class Account
	{
		public bool exists = false;
		public string private_login; //used to log in and use vpn
		public string public_login;  //used to top up the balance
		public DateTime date_registered;
		public DateTime paid_till;   //if "paid_till" equals "date_registered" - the account is just created

		public DataRow? accountData = null;

		/// <param name="login"></param>
		/// <param name="isLoginPublic">True if passing a public login, false (default) if passing the private login</param>
		public Account(string login, bool isLoginPublic = false)
		{
			string accessColumn;

			if (isLoginPublic)
			{
				this.public_login = login;
				accessColumn = "public_login";
			}
			else
			{
				this.private_login = login;
				accessColumn = "private_login";
			}

			//check if account exists
			DataTable accounts = DB.GetDataTable($"SELECT * FROM `accounts` WHERE `{accessColumn}` = @login;", 
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

			//getting account data:
			accountData = accounts.Rows[0];

			private_login = accountData["private_login"].ToString();
			public_login = accountData["public_login"].ToString();
			date_registered = (DateTime)accountData["when_registered"];
			paid_till = (DateTime)accountData["paid_till"];
		}

		private void UpdateAccountRow()
		{

		}

		/// <param name="days">Amount of days to add to account's balance.</param>
		/// <returns>A DateTime till which account is paid.</returns>
		public DateTime AddTime(ushort days)
		{
			DateTime new_paid_till = paid_till.AddDays(days);
			DB.Execute($"UPDATE `Users` SET paid_till = '{new_paid_till.ToDateTime()}' WHERE login = '{private_login}';", 
				new Dictionary<string, object>() { { "", "" }, { "", "" }, { "", "" } });
			Thread.Sleep(100);
			return new_paid_till;
		}

		public ushort DaysLeft()
		{
			try
			{
				return (ushort)Math.Ceiling((paid_till - DateTime.Now).TotalDays);
			}
			catch
			{
				return (ushort)0;
			}
		}

		/// <summary>
		/// Registers a new account.
		/// </summary>
		/// <returns>A fresh brand new account</returns>
		public static Account Register()
		{
			string private_login = GenerateUniquePrivateLogin();
			string public_login = GenerateUniquePublicLogin();
			DateTime now = DateTime.Now;
			DateTime when_registered = now;
			DateTime paid_till = now;

			ulong new_account_id = DB.InsertAndGetID("INSERT INTO `accounts` " +
				"(`when_registered`, `paid_till`, `private_login`, `public_login`) " +
				"VALUES " +
				"(@when_registered, @paid_till, @private_login, @public_login);", 
				new Dictionary<string, object>()
				{
					{ "@when_registered", when_registered },
					{ "@paid_till", paid_till },
					{ "@private_login", private_login },
					{ "@public_login", public_login },
				});

			Thread.Sleep(123);

			return new Account(private_login);
		}

		private static string GenerateUniquePrivateLogin()
		{
			const string dic = "qwetipasdfghjkzcvb123456789"; //possible account characters dictionary
			string new_private_login = "";

			for (uint u = 0; u < uint.MaxValue; u++) //fail-safe alternative to forever loop
			{
				Random random = new();

				for (byte b = 0; b < 12; b++)
				{
					new_private_login += dic[random.Next(dic.Length)];
					if (b == 5)
						new_private_login += "-";

					try
					{
						Span<byte> randomNumber = stackalloc byte[4];
						RandomNumberGenerator.Fill(randomNumber);
						int value = BitConverter.ToInt32(randomNumber);
						int delay = 1 + (Math.Abs(value) % 13);
						Thread.Sleep(delay);
					}
					catch
					{
						Thread.Sleep(new Random().Next(3, 30));
					}
					finally
					{
						Thread.Sleep(new Random().Next(0, 27));
					}
				}

				DataTable loginExistances = DB.GetDataTable($"SELECT * FROM `accounts` WHERE " +
					$"`private_login` = @private_login;",
					new Dictionary<string, object>()
					{
						{ "private_login", new_private_login }
					});

				if (loginExistances.Rows.Count <= 0)
					break;
			}

			if (new_private_login == "")
				throw new Exception("Could not generate a unique private login");
			else
				return new_private_login;
		}

		private static string GenerateUniquePublicLogin()
		{
			const string dic = "qwertyupasdfghjkzxcvbnm123456789"; //possible account characters dictionary
			string new_public_login = "";

			for (uint u = 0; u < uint.MaxValue; u++) //fail-safe alternative to forever loop
			{
				Random random = new();

				for (byte b = 0; b < 11; b++)
				{
					new_public_login += dic[random.Next(dic.Length)];

					try
					{
						Span<byte> randomNumber = stackalloc byte[4];
						RandomNumberGenerator.Fill(randomNumber);
						int value = BitConverter.ToInt32(randomNumber);
						int delay = 1 + (Math.Abs(value) % 13);
						Thread.Sleep(delay);
					}
					catch
					{
						Thread.Sleep(new Random().Next(3, 30));
					}
					finally
					{
						Thread.Sleep(new Random().Next(0, 27));
					}
				}

				DataTable loginExistances = DB.GetDataTable($"SELECT * FROM `accounts` WHERE " +
					$"`public_login` = @public_login;",
					new Dictionary<string, object>()
					{
						{ "public_login", new_public_login }
					});

				if (loginExistances.Rows.Count <= 0)
					break;
			}

			if (new_public_login == "")
				throw new Exception("Could not generate a unique public login");
			else
				return new_public_login;
		}

	}
}