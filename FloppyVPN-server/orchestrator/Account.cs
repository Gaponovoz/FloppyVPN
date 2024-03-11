using System.Security.Cryptography;

namespace FloppyVPN
{
	public class Account
	{
		public static readonly char splitChar = 'x'; //character which is used to split login to the public and private parts

		public bool exists = false;
		public string private_login;
		public string public_login;
		public DateTime paid_till;
		public DateTime date_registered;


		/// <summary>
		/// 
		/// </summary>
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
			}


			//check if login exists
			DataTable _account = DB.GetDataTable($"SELECT login FROM Users WHERE login = '{login}';", 
				new Dictionary<string, object>()
				{
					
				});

			if (_account.Rows.Count == 1)
			{
				exists = true;
			}
			else
			{
				exists = false;
				return;
			}
			
			DataRow account = _account.Rows[0];

			//make masked versions:
			string[] splitLogin = login.Split(splitChar);
			public_login = splitLogin[0];

			//get and count paid time:
			paid_till = (DateTime)account["paid_till"];
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

		public int DaysLeft()
		{
			try
			{
				return (int)Math.Ceiling((paid_till - DateTime.Now).TotalDays);
			}
			catch
			{
				return 0;
			}
		}




		public static Account Register()
		{
			string private_login = GenerateUniquePrivateLogin();
			string public_login = GenerateUniquePublicLogin();
			DateTime paid_till = DateTime.MinValue;
			DateTime date_registered = DateTime.Now;


			ulong new_account_id = DB.InsertAndGetID("INSERT INRO `accounts` " +
				"(`when_registered`, `paid_till`, `private_login`, `public_login`, ``) " +
				"VALUES " +
				"(@when_registered, @paid_till, @private_login, @public_login);", 
				new Dictionary<string, object>()
				{
					{ "@when_registered",  },
					{ "@paid_till", "" },
					{ "@private_login", "" },
					{ "@public_login", "" },
				});

			Thread.Sleep(123);

			return new Account();
		}

		private static string GenerateUniquePrivateLogin()
		{
			const string dic = "qwetipasdfghjkzcvb123456789"; //possible account characters dictionary
			string new_private_login = "";

			for (uint u = 0; u < uint.MaxValue; u++) //fail-safe alternative to forever loop
			{
				Random random = new();

				for (byte b = 0; b < 11; b++)
				{
					new_private_login += dic[random.Next(dic.Length)];
					if (b == 4)
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
					$"`login` = '{new_private_login.Split('x')[0]}%';",
					new Dictionary<string, object>()
					{
						{ "", new_private_login }
					});

				if (loginExistances.Rows.Count <= 0)
					break;
			}

			if (new_private_login == "")
				throw new Exception("Could not generate a unique login");
			else
				return new_private_login;
		}

		private static string GenerateUniquePublicLogin()
		{
			const string dic = "qwetipasdfghjkzcvb123456789"; //possible account characters dictionary
			string new_private_login = "";

			for (uint u = 0; u < uint.MaxValue; u++) //fail-safe alternative to forever loop
			{
				Random random = new();

				for (byte b = 0; b < 11; b++)
				{
					new_private_login += dic[random.Next(dic.Length)];
					if (b == 4)
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
					$"`login` = '{new_private_login.Split('x')[0]}%';",
					new Dictionary<string, object>()
					{
						{ "", new_private_login }
					});

				if (loginExistances.Rows.Count <= 0)
					break;
			}

			if (new_private_login == "")
				throw new Exception("Could not generate a unique login");
			else
				return new_private_login;
		}

	}
}