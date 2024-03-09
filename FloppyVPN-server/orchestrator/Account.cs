using System.Security.Cryptography;

namespace FloppyVPN
{
	public class Account
	{
		public static char splitChar = 'x'; //character which is used to split login to the public and private parts

		public bool exists = false;
		public string login;
		public string masked_login;
		public string masked_login_stars;
		public string paid_till;
		public int days_left;
		public string? date_registered;

		public Account(string _login, bool isMasked = false)
		{
			login = _login.Replace("*", "");

			//restore full login if we only have short (masked) part:
			if (isMasked)
				login = DB.GetValueInTable($"SELECT login FROM Users WHERE login LIKE '{login}{splitChar}%';");

            //check if login exists
            DataTable accounts = DB.GetDataTable($"SELECT login FROM Users WHERE login = '{login}';");
			if (accounts.Rows.Count == 1)
				exists = true;
			else
			{
                exists = false;
                return;
			}
				

            DataRow account = accounts.Rows[0];

            //make masked versions:
            string[] splitLogin = login.Split(splitChar);
			masked_login = splitLogin[0];
			masked_login_stars = masked_login + new string('*', splitLogin[1].Length + 1);

			//get and count paid time:
			paid_till = account["paid_till"];
			try
			{
				days_left = (int)Math.Ceiling((Utils.StringToDateTime(paid_till) - DateTime.Now).TotalDays);
			}
			catch
			{
				days_left = 0;
			}

			//get registration date:
			date_registered = DB.GetValue($"SELECT date_registered FROM Users WHERE `login` = '@login';", new Dictionary<string, object>()
			{
				{ "login", login }
			}).ToString();
		}

		/// <param name="days">Amount of days to add to account's balance.</param>
		/// <returns>A DateTime symbolizing date and time till which account is paid.</returns>
		public DateTime AddTime(ushort days)
		{
			DateTime new_paid_till = paid_till.ToDateTime().AddDays(days);
			DB.Execute($"UPDATE `Users` SET paid_till = '{new_paid_till.ToDateTime()}' WHERE login = '{login}';", 
				new Dictionary<string, object>() { { "", "" }, { "", "" }, { "", "" } });
			Thread.Sleep(100);
			return new_paid_till;
		}






		public static Account RegisterNew(string ipaddress)
		{
			string login = "";
			string paid_till = "-";
			string date_registered = Dating.DateNow();
			string hash_ip_registered = Utils.GetSha256Hash(ipaddress);

			const string dic = "qwetipasdfghjkzcvb123456789"; //account symbols dictionary

			for (uint u = 0; u < uint.MaxValue; u++) //fail-safe alternative to forever loop
			{
				Random random = new();

				for (int i = 0; i < 10; i++)
				{
					login += dic[random.Next(dic.Length)];
					if (i == 4)
						login += "x";

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
						Thread.Sleep(new Random().Next(0, 25));
					}
				}

				DataTable loginExistances = DB.GetDataTable($"SELECT * FROM `users` WHERE `login` LIKE '{login.Split('x')[0]}%';", 
					new Dictionary<string, object>()
					{
						{ "", "" },
						{ "", "" },
						{ "", "" }
					});

				if (loginExistances.Rows.Count <= 0)
					break;
			}

			if (login == "")
				throw new Exception("Could not generate a unique login");


			//using hashed IP address, check if the user registers enourmous amount of accounts this day:
			int registrationsOfIPtoday = DB.GetDataTable($"SELECT * FROM `request` WHERE hash_ip_registered = '{hash_ip_registered}' AND date_registered = '{Dating.DateNow()}';").Rows.Count;
			if (registrationsOfIPtoday >= 7)
			{
				throw new Exception("Cant register this user today anymore");
			}

			string[] newUserRow = { login, paid_till, date_registered, hash_ip_registered, };
			DB.InsertAndGetID("Users", 
				new Dictionary<string, object>()
				{
					
				});

			Task.Delay(123).GetAwaiter().GetResult();
			return new Account(newUserRow[0]);
		}




	}
}