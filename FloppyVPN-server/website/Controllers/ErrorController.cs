using FloppyVPN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FloppyVPN.Controllers
{
	public class ErrorController : Controller
	{
		[HttpGet("/Error/{statusCode}")]
		public IActionResult HttpStatusCodeHandler(int statusCode)
		{
			string? errorMessage = null;

			// Only write error message if status code is not well-known and localized
			// to display the actual error message
			if (statusCode == 500)
				errorMessage = "Fuck";

			return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
			{
				ErrorMessage = errorMessage,
				ErrorCode = statusCode,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			});
		}
	}
}
