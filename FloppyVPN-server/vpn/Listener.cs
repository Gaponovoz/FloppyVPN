using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Data;

namespace FloppyVPN;

/// <summary>
/// A tiny API that listens for master server commands
/// </summary>
public static class Listener
{
	public static void Start()
	{
		var builder = WebApplication.CreateBuilder();

		var app = builder.Build();

		builder.Services.Configure<KestrelServerOptions>(options =>
		{
			options.AllowSynchronousIO = true;
		});

		app.UseMiddleware<MasterKeyValidationFilter>();


		//responses if the server is alive
		app.MapGet("/CheckAvailability", () =>
		{
			return "OK";
		});


		//
		app.MapGet("/DeleteConfig/{config_to_delete}", (string config_to_delete) =>
		{
			Vpn.DeleteConfig(config_to_delete);
			return "Done";
		});


		//replaces existing config
		app.MapGet("/CreateConfig", (HttpContext context) =>
		{
			try
			{
				return Vpn.CreateConfig();
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = 500;
				return "Could not create config: " + ex.Message;
			}
		});


		//returns this vpn server configuration
		app.MapGet("/GetServerConfiguration", () =>
		{
			return Rialize.Se<DataRow>(Config.cache);
		});


		//
		app.MapGet("/", () =>
		{
			return "vpn";
		});


		//
		app.MapGet("/", () =>
		{
			return "vpn";
		});



		app.Run();
	}
}



public class MasterKeyValidationFilter : IActionFilter
{
	public void OnActionExecuting(ActionExecutingContext context)
	{
		if (!ServerTools.IsValidMasterKey(context.HttpContext.Request))
		{
			context.HttpContext.Response.StatusCode = 401;
			context.HttpContext.Response.WriteAsync("Master key is wrong or absent.");
			context.Result = new EmptyResult();
		}
	}

	public void OnActionExecuted(ActionExecutedContext context)
	{
	}
}
