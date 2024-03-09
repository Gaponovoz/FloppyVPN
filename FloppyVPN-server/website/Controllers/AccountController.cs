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
			return View();
		}
	}
}
