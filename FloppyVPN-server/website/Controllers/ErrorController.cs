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

			return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
			{
				ErrorMessage = errorMessage,
				ErrorCode = statusCode,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			});
		}

		[HttpGet("/Error:{errorMessage}")]
		public IActionResult HttpStatusCodeHandler(string errorMessage)
		{
			return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
			{
				ErrorMessage = errorMessage,
				ErrorCode = 0,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			});
		}

		[HttpPost("/Error/{statusCode}")]
		public IActionResult ErrorPagePost(int statusCode)
		{
			string? errorMessage = null;

			return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
			{
				ErrorMessage = errorMessage,
				ErrorCode = statusCode,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			});
		}

		[HttpPost("/Error:{errorMessage}")]
		public IActionResult ErrorPagePost(string errorMessage)
		{
			return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
			{
				ErrorMessage = errorMessage,
				ErrorCode = 0,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			});
		}

	}
}
