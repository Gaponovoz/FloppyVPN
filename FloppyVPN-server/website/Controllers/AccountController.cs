using FloppyVPN.Models;
using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		//public IActionResult Registered()
		//{
		//	return RedirectToAction();
		//}

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
					HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
					return RedirectToAction();
				}
				else
				{
					string response = Communicator.GetHttp(url: $"{Config.cache["orchestrator_url"]}/Api/Website/RegisterAccount",
						master_key: Config.cache["master_key"].ToString(),
						hashed_user_ip_address: ServerTools.GetHashedIPAddress(HttpContext.Request).ToString(),
						status_code: out HttpStatusCode statusCode,
						is_successful: out bool isSuccessful
					);

					Console.WriteLine(response);

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
		public IActionResult PerformLogin()
		{


			AccountModel accountModel = new();

			return RedirectToAction("~/Views/Account");
		}

		[HttpPost]
		public IActionResult PerformLogout()
		{
			return RedirectToAction("Index", "Home");
		}
	}
}
