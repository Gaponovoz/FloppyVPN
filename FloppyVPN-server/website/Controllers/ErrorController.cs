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
			string errorMessage = "";

			// Handle different HTTP status codes
			switch (statusCode)
			{
				case 404:
					errorMessage = "The resource you requested does not exist.";
					break;
				default:
					errorMessage = "Sorry, something went wrong.";
					break;
			}

			return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
			{
				ErrorMessage = errorMessage,
				ErrorCode = statusCode,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			});
		}
	}
}
