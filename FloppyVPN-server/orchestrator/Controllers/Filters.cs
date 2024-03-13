using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers;

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
			userKarma.LogRequest(Karma.LogRequestResources.idk, false);

			context.HttpContext.Response.StatusCode = StatusCodes.Status423Locked;
			context.HttpContext.Response.WriteAsync("The user seems to be banned right now.");
			context.Result = new EmptyResult();
		}
		else
		{
			userKarma.LogRequest(Karma.LogRequestResources.idk, true);
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
		if (userKarma.IsSoftBanned() || userKarma.IsBanned())
		{
			context.HttpContext.Response.StatusCode = 403;
			context.HttpContext.Response.WriteAsync("The user seems to be softbanned right now.");
			context.Result = new EmptyResult();
		}
		else
		{
			userKarma.LogRequest(Karma.LogRequestResources.registration, true);
		}
	}

	public void OnActionExecuted(ActionExecutedContext context)
	{
		// No action needed after the action method is executed
	}
}

public class MasterKeyValidationFilter : IActionFilter
{
	public void OnActionExecuting(ActionExecutingContext context)
	{
		Karma serverKarma = new(ServerTools.GetHashedIPAddress(context.HttpContext.Request));

		if (serverKarma.IsBanned())
		{
			context.HttpContext.Response.StatusCode = 423;
			context.HttpContext.Response.WriteAsync("You seem to be banned.");
			context.Result = new EmptyResult();
		}
		else if (!ServerTools.IsValidMasterKey(context.HttpContext.Request))
		{
			serverKarma.LogRequestAsync(Karma.LogRequestResources.master_key_failed_usage, false);

			context.HttpContext.Response.StatusCode = 403;
			context.HttpContext.Response.WriteAsync("Master key is wrong or absent.");
			context.Result = new EmptyResult();
		}
	}

	public void OnActionExecuted(ActionExecutedContext context)
	{
		// No action needed after the action method is executed
	}
}
