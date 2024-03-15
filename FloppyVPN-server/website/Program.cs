using System.Net;

namespace FloppyVPN
{
	public class Program
	{
		public static readonly string PathToLocalizations = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "localizations.xml"));


		public static void Main(string[] args)
		{
			//single instance:
			Mutex mutex = new(true, "floppyvpn_website_L2Neli82o5I8P1hsqVtOHoq67htydhythtdeyj8AuWYE", out bool result);
			if (!result)
			{
				Console.WriteLine("The same server is already running so it won't start again.");
				Environment.Exit(0);
			}
			GC.KeepAlive(mutex);

			Config.EnsureFileIntegrity();

			new Thread(() => Config.CacheRefresher()).Start();
			new Thread(() => Loc.AutoRefresh()).Start();
			new Thread(() => Cache.AutoRefresh()).Start();


			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


			Startup(args);
		}


		public static void Startup(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container
			builder.Services.AddControllersWithViews();

			// Disable crazy logging
			builder.Host.ConfigureLogging(logging =>
			{
				logging.ClearProviders();
				logging.AddConsole(); // Add back the console logger if needed

				logging.AddFilter("Microsoft.AspNetCore", LogLevel.Warning);
				logging.AddFilter("Microsoft.AspNetCore.Mvc.ViewFeatures", LogLevel.None);
				logging.AddFilter("Microsoft.AspNetCore.Mvc.Infrastructure", LogLevel.None);
				logging.AddFilter("Microsoft.AspNetCore.Routing", LogLevel.None);
				logging.AddFilter("Microsoft.AspNetCore.StaticFiles", LogLevel.None);
			});

			WebApplication app = builder.Build();

			app.UseStaticFiles();
			app.UseRouting();

			#region Short paths initialization

			//app.MapControllerRoute(
			//	name: "errorRoute",
			//	pattern: "error",
			//	defaults: new { controller = "Home", action = "Error" }
			//);

			app.MapControllerRoute(
				name: "privacyRoute",
				pattern: "privacy",
				defaults: new { controller = "Home", action = "Privacy" }
			);

			app.MapControllerRoute(
				name: "supportRoute",
				pattern: "support",
				defaults: new { controller = "Home", action = "Support" }
			);

            app.MapControllerRoute(
                name: "accountRoute",
                pattern: "account",
                defaults: new { controller = "Account", action = "Index" }
            );

            app.MapControllerRoute(
                name: "topupRoute",
                pattern: "topup",
                defaults: new { controller = "Account", action = "Index" }
            ); 
			
			app.MapControllerRoute(
				name: "loginRoute",
				pattern: "login",
				defaults: new { controller = "Account", action = "Login" }
			);

			app.MapControllerRoute(
				name: "registerRoute",
				pattern: "register",
				defaults: new { controller = "Account", action = "Register" }
			);

			#endregion


			#region Main controller initialization

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}",
				defaults: new { controller = "Home", action = "Index" }
			);

			#endregion


			// Custom middleware to handle exceptions and set status codes
			app.Use(async (context, next) =>
			{
				try
				{
					await next();
				}
				catch (Exception ex)
				{
					context.Response.StatusCode = StatusCodes.Status500InternalServerError;

					context.Request.Path = "/Error";

					await next();
				}
			});

			// UseExceptionHandler to handle other unhandled exceptions
			app.UseExceptionHandler("/Error");

			// UseStatusCodePagesWithReExecute to handle other status codes
			app.UseStatusCodePagesWithReExecute("/Error/{0}");


			app.Urls.Clear();
			app.Urls.Add("http://localhost:1441");

			app.Run();
		}

	}
}