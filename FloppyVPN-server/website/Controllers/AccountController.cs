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

		public IActionResult NoLogin()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		public IActionResult Registered()
		{
			// Only redirect to "Registered" (which actually registers a user) when redirected from "Register"
			if ((bool)(TempData["FormSubmitted"] ?? false) == true)
			{
				TempData.Remove("FormSubmitted");
				return View();
			}
			else
			{
				// If not redirected from Register view, redirect to login page
				return RedirectToAction("Login", "Account");
			}
		}

		[HttpPost]
		public IActionResult PerformRegistration()
		{
			// Set TempData flag indicating that the form was submitted
			TempData["FormSubmitted"] = true;

			// Redirect to the Registered action to render the Registered view
			return RedirectToAction("Registered");
		}
	}
}
