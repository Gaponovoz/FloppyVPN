using FloppyVPN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

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
			_Functions.WriteCookie(HttpContext, "FloppyVPN_CookieAcknowledged", "True");
			return RedirectToAction("Index", "Home");
		}
	}
}
