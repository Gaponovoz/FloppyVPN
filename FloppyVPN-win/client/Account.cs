using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FloppyVPN
{
	internal static class Account
	{
		public static string master_server_url = "https://localhost/api/";

		public static bool loggedIn = false;
		public static string login = "";
		public static string maskedlogin = "";
		public static string paidtill = "";
		public static string daysleft = "";


		public static bool LogIn(string _login = "") //if no login provided, try using saved one
		{
			return true;
			if (_login == "")
				_login = IniFile.GetValue("login");

			if (_login == "")
				return false;

			string[] response = Shared.DownloadString($"{PathsAndLinks.masterServerURL}/userapi/login/{_login}").Split('♂');

			if (response[0] != "Success")
				return false;

			maskedlogin = response[1];
			paidtill = response[2];
			daysleft = response[3];

			loggedIn = true;
			login = _login;

			IniFile.SetValue("login", login);

			return true;
		}

		public static void LogOut()
		{
			loggedIn = false;
			login = "";
			maskedlogin = "";
			paidtill = "";
			daysleft = "";
			IniFile.SetValue("login", "");
		}

	}
}