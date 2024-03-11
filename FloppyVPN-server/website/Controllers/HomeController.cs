using FloppyVPN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpPost]
		public IActionResult AcknowledgeCookie()
		{
			_Functions.WriteCookie(HttpContext, "FloppyVPN_CookieAcknowledged", "True");
			return RedirectToAction("Index", "Home");
		}
	}
}
