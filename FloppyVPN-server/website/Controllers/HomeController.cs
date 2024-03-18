using FloppyVPN.Models;
using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Support()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AcknowledgeCookie()
		{
			_Functions.WriteCookie(HttpContext, "cookieAcknowledged", "True");
			return RedirectToAction("Index", "Home");
		}
		
		[HttpPost]
		public IActionResult ChangeLanguage()
		{
			var selectedLang = HttpContext.Request.Form["language"];
			_Functions.WriteCookie(HttpContext, "language", selectedLang);

			// Redirect to refresh page with the new language parameter
			string refreshUrl = HttpContext.Request.Form["currentPath"] + "?lang=" + selectedLang;
			return Redirect(refreshUrl);
		}

		
	}
}
