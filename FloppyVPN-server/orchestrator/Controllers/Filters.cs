using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	public class Filters
	{
		public static string GetHashedIpFromHeaders(HttpRequest request)
		{
			try
			{
				return request.Headers["hashed_user_ip_address"].FirstOrDefault();
			}
			catch
			{
				return "";
			}
		}
	}

	public class UserIsBannedValidationFilter : IActionFilter
	{
		public void OnActionExecuting(ActionExecutingContext context)
		{
			Karma userKarma = new(Filters.GetHashedIpFromHeaders(context.HttpContext.Request));
			if (userKarma.IsBanned())
			{
				context.HttpContext.Response.StatusCode = StatusCodes.Status423Locked;
				context.HttpContext.Response.WriteAsync("The user seems to be banned right now.");
				context.Result = new EmptyResult();
			}
			else
			{

			}
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			// No action needed after the action method is executed
		}
	}

	public class UserIsSoftBannedValidationFilter : IActionFilter
	{
		public void OnActionExecuting(ActionExecutingContext context)
		{
			Karma userKarma = new(Filters.GetHashedIpFromHeaders(context.HttpContext.Request));
			if (userKarma.IsSoftBanned())
			{
				context.HttpContext.Response.StatusCode = StatusCodes.Status423Locked;
				context.HttpContext.Response.WriteAsync("The user seems to be softbanned right now.");
				context.Result = new EmptyResult();
			}
			else
			{

			}
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			// No action needed after the action method is executed
		}
	}
}
