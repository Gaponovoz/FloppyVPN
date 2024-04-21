﻿using FloppyVPN.Models;
using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return Redirect("/login");
		}

		[HttpGet("/login")]
		public IActionResult Login()
		{
			return View();
		}

		[HttpGet("register")]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult PerformRegistration()
		{
			// Set TempData flag indicating that the form was submitted
			TempData["FormSubmitted"] = true;

			// Redirect to the Registered action to render the Registered view
			// Only open "Registered" (which actually registers a user) when redirected from "Register"
			if ((bool)(TempData["FormSubmitted"] ?? false) == true)
			{
				TempData.Remove("FormSubmitted");

				if (Config.cache["allow_registration"].ToString() == bool.FalseString)
				{
					return Redirect("/Error/503");
				}
				else
				{
					string response = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/RegisterAccount",
						hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
						status_code: out HttpStatusCode statusCode,
						is_successful: out bool isSuccessful,
						Config.cache["master_key"].ToString()
					);

					DataRow? newAccountData;
					try
					{
						newAccountData = Rialize.Dese<DataRow>(response);
					}
					catch
					{
						newAccountData = null;
					}


					if (!isSuccessful || newAccountData == null)
					{
						return Redirect($"/Error/{(int)statusCode}");
					}

					return View("~/Views/Account/Registered.cshtml", new NewAccountModel() { NewAccountData = newAccountData });
				}
			}
			else
			{
				// If not redirected from Register view, redirect to login page
				return RedirectToAction("Login", "Account");
			}
		}

		[HttpPost]
		public IActionResult My() //logging in
		{
			string enteredLogin = (HttpContext.Request.Form["user_login"].FirstOrDefault() ?? "").Replace("-", "");

			string lang = _Functions.GetCurrentLanguage(HttpContext);
			if (enteredLogin.Length != 8)
			{
				Thread.Sleep(new Random().Next(200, 900));
				TempData["Message"] = Loc.Get("error-wrong-login", lang);
				return Redirect("/login");
			}

			string response = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/LogintoAccount/{enteredLogin}",
				hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
				status_code: out HttpStatusCode statusCode,
				is_successful: out bool isSuccessful,
				Config.cache["master_key"].ToString()
			);

			DataRow? accountData;
			try
			{
				accountData = Rialize.Dese<DataRow>(response);
			}
			catch
			{
				accountData = null;
			}

			if (!isSuccessful || accountData == null)
			{
				if ((int)statusCode == 404)
				{
					TempData["Message"] = Loc.Get("error-wrong-login", lang);
					return Redirect("/login");
				}
				return Redirect($"/Error/{(int)statusCode}");
			}

			string alias = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/CreateLoginAlias/{enteredLogin}",
				hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
				status_code: out HttpStatusCode aliasStatusCode,
				is_successful: out bool aliasIsSuccessful,
				Config.cache["master_key"].ToString()
			);

			if (!aliasIsSuccessful)
			{
				return Redirect($"/Error/{aliasStatusCode}");
			}

			AccountModel accountModel = new() { AccountData = accountData, Alias = alias };

			return View("~/Views/Account/My.cshtml", accountModel);
		}

		[HttpPost]
		public IActionResult PerformLogout()
		{
			return RedirectToAction("Index", "Home");
		}

		[HttpGet("TopUp/{alias}")]
		public IActionResult TopUp(string alias) // Serves the TopUp page for an account
		{
			string acc_existance = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/AccountExistsByAlias/{alias}",
				hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
				status_code: out _,
				is_successful: out _,
				Config.cache["master_key"].ToString()
			);

			if (!acc_existance.Contains(bool.TrueString))
				return Redirect("/Error/404");

			string response = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/GetCurrenciesTable",
				hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
				status_code: out HttpStatusCode statusCode,
				is_successful: out bool isSuccessful,
				Config.cache["master_key"].ToString()
			);

			DataTable currenciesTable = Rialize.Dese<DataTable>(response);

			return View("~/Views/Account/TopUp.cshtml", new TopUpModel { CurrenciesTable = currenciesTable, Alias = alias });
		}

		[HttpPost]
		public IActionResult CreatePayment() // Creates a new payment and redirects to the payment page if success
		{
			string alias = Request.Form["alias"];
			string currency_code = Request.Form["currency_code"];
			int months_amount = int.Parse(Request.Form["months_amount"]);

			string new_payment_id = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/CreateNewPayment/{alias}/{currency_code}/{months_amount}",
				hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
				status_code: out HttpStatusCode statusCode,
				is_successful: out bool isSuccessful,
				Config.cache["master_key"].ToString()
			);

			if (isSuccessful)
				return Redirect($"/Payment/{new_payment_id}");
			else
				return Redirect($"/Error/{(int)statusCode}");
		}

		[HttpGet("Payment/{payment_id}")]
		public IActionResult Payment(string payment_id) // Serves the page of an individual payment
		{
			string responsePaymentInfo = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/GetPaymentInfo/{payment_id}",
				hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
				status_code: out HttpStatusCode statusCode,
				is_successful: out bool isSuccessful,
				Config.cache["master_key"].ToString()
			);
			if (!isSuccessful)
				return Redirect($"/Error/{(int)statusCode}");

			DataRow paymentInfo = Rialize.Dese<DataRow>(responsePaymentInfo);

			string responseCurrencyInfo = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/GetCurrencyInfo/{paymentInfo["currency_code"]}",
				hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
				status_code: out _,
				is_successful: out _,
				Config.cache["master_key"].ToString()
			);

			DataRow currencyInfo = Rialize.Dese<DataRow>(responseCurrencyInfo);

			PaymentModel paymentModel = new() { PaymentData = paymentInfo, CurrencyData = currencyInfo };

			return View("~/Views/Account/Payment.cshtml", paymentModel);
		}
	}
}