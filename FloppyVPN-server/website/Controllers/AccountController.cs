using FloppyVPN.Models;
using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return Redirect("/login");
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpGet("TopUp/{public_login}")]
		public IActionResult TopUp(string public_login)
		{
			if (public_login.Length != 12)
			{
				return Redirect("/login");
			}




			TopupModel topupModel = new() { };

			return View("~/Views/Account/TopUp.cshtml", topupModel);
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
						master_key: Config.cache["master_key"].ToString(),
						hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
						status_code: out HttpStatusCode statusCode,
						is_successful: out bool isSuccessful
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
		public IActionResult My()
		{
			string enteredLogin = (HttpContext.Request.Form["user_login"].FirstOrDefault() ?? "").Replace("-", "");

			string lang = _Functions.GetCurrentLanguage(HttpContext);
			if (enteredLogin.Length != 12)
			{
				TempData["Message"] = Loc.Get("error-wrong-login", lang);
				return Redirect("/login");
			}


			string response = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/LogintoAccount/{enteredLogin}",
				master_key: Config.cache["master_key"].ToString(),
				hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
				status_code: out HttpStatusCode statusCode,
				is_successful: out bool isSuccessful
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
				return Redirect($"/Error/{(int)statusCode}");
			}

			AccountModel accountModel = new() { AccountData = accountData };

			return View("~/Views/Account/My.cshtml", accountModel);
		}

		[HttpPost]
		public IActionResult PerformLogout()
		{
			return RedirectToAction("Index", "Home");
		}
	}
}
