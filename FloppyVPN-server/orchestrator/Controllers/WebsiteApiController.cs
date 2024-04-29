﻿using K4os.Compression.LZ4.Streams.Frames;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using static FloppyVPN.ServerTools;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/Website")]
	[ServiceFilter(typeof(MasterKeyValidationFilter))]
	public class WebsiteApiController : ControllerBase
	{
		[HttpGet("AccountExists/{login}")]
		[ServiceFilter(typeof(BannedUsersFilter))]
		public string AccountExists(string login)
		{
			Account acc = new(login);
			return acc.exists.ToString();
		}

		[HttpGet("AccountExistsByAlias/{alias}")]
		public string AccountExistsByAlias(string alias)
		{
			string? login = Aliasing.GetLoginFromAlias(alias);

			if (!string.IsNullOrEmpty(alias) && new Account(login).exists)
			{
				return bool.TrueString;
			}
			else
			{
				return bool.FalseString;
			}
		}

		[HttpGet("RegisterAccount")]
		[ServiceFilter(typeof(SoftbannedUsersFilter))]
		public string RegisterAccount()
		{
			return Rialize.Se<DataRow>(Account.Register().accountData);
		}

		[HttpGet("LogintoAccount/{login}")]
		[ServiceFilter(typeof(BannedUsersFilter))]
		public string LogintoAccount(string login)
		{
			Account acc = new(login);
			Karma karma = new(Filters.GetHashedIpFromHeaders(HttpContext.Request));

			if (acc.exists)
			{
				karma.LogRequest(Karma.LogRequestResources.login, true);

				return Rialize.Se<DataRow>(acc.accountData);
			}
			else
			{
				karma.LogRequest(Karma.LogRequestResources.login, false);

				Response.StatusCode = 404;
				return "Such account does not seem to exist";
			}
		}

		[HttpGet("CreateLoginAlias/{login}")]
		public string CreateLoginAlias(string login)
		{
			if (new Account(login).exists)
			{
				return Aliasing.NewAliasForLogin(login);
			}
			else
			{
				Response.StatusCode = 404;
				return "The account to create alias for does not seem to exist.";
			}
		}

		[HttpGet("GetLoginFromAlias/{alias}")]
		public string GetLoginFromAlias(string alias)
		{
			return Aliasing.GetLoginFromAlias(alias) ?? "null";
		}

		[HttpGet("GetCurrenciesTable")]
		public string GetCurrenciesTable()
		{
			DataTable currenciesTable = DB.GetDataTable($"SELECT * FROM `currencies` WHERE `enabled` = 1;");
			return Rialize.Se<DataTable>(currenciesTable);
		}

		//[HttpGet("GetAllCurrenciesTable")]
		//public string GetAllCurrenciesTable()
		//{
		//	DataTable currenciesTable = DB.GetDataTable($"SELECT * FROM `currencies`;");
		//	return Rialize.Se<DataTable>(currenciesTable);
		//}

		[HttpGet("GetCurrencyInfo/{currency_code}")]
		public string GetCurrencyInfo(string currency_code)
		{
			DataRow currencyInfo = DB.GetDataTable($"SELECT * FROM `currencies` " +
				$"WHERE `currency_code` = @currency_code;",
				new Dictionary<string, object>()
				{
					{ "@currency_code", currency_code }
				}).Rows[0];
			return Rialize.Se<DataRow>(currencyInfo);
		}

		[HttpGet("CreateNewPayment/{alias}/{currency_code}/{months_amount}")]
		[ServiceFilter(typeof(BannedUsersFilter))]
		public string CreateNewPayment(string alias, string currency_code, int months_amount)
		{
			//check if an acount of such alias exists:
			string? login = Aliasing.GetLoginFromAlias(alias);

			if (string.IsNullOrEmpty(login) || !new Account(login).exists)
			{
				Response.StatusCode = 404;
				return "The account of payment does not seem to exist.";
			}

			//create the payment:
			string new_payment_id = Paymenting.Create_NowPayments(login, currency_code, months_amount);

			Karma karma = new(Filters.GetHashedIpFromHeaders(HttpContext.Request));
			karma.LogRequest(Karma.LogRequestResources.payment_creation, true);

			return new_payment_id;
		}

		[HttpGet("GetPaymentInfo/{payment_id}")]
		[ServiceFilter(typeof(BannedUsersFilter))]
		public string GetPaymentInfo(string payment_id)
		{
			DataTable _paymentInfo = DB.GetDataTable($"SELECT * FROM `payments` WHERE `id` = @payment_id;", 
				new Dictionary<string, object>()
				{
					{ "@payment_id", payment_id }
				});

			if (_paymentInfo.Rows.Count < 1)
			{
				Response.StatusCode = 404;
				return "This payment does not seem to exist.";
			}

			DataRow paymentInfo = _paymentInfo.Rows[0];

			return Rialize.Se<DataRow>(paymentInfo);
		}

		[HttpPost("AdminAddNewVpnServer")]
		public string AdminAddNewVpnServer()
		{
			try
			{
				string body = "null";
				using (StreamReader sr = new(HttpContext.Request.Body))
				{
					body = sr.ReadToEnd();
				}
				JObject newVpnServerData = JObject.Parse(body);

				ulong freshID = DB.InsertAndGetID(@"INSERT INTO vpn_servers 
	(socket, country_code, max_configs, ipv4_address, ipv6_address, when_added, last_alive) 
	VALUES(@socket, @country_code, @max_configs, @ipv4_address, @ipv6_address, @when_added, @last_alive);",
				new Dictionary<string, object>()
				{
					{ "@socket", (string)newVpnServerData["socket"] },
					{ "@country_code", (string)newVpnServerData["country_code"] },
					{ "@max_configs", (byte)newVpnServerData["max_configs"] },
					{ "@ipv4_address", (string)newVpnServerData["ipv4_address"] },
					{ "@ipv6_address", (string)newVpnServerData["ipv6_address"] },
					{ "@when_added", DateTime.Now },
					{ "@last_alive", DateTime.Now },
				});

				return freshID.ToString();
			}
			catch (Exception ex)
			{
				DB.Log("AdminAddNewVpnServer", ex.Message);
				return ex.Message;
			}
		}
	}
}