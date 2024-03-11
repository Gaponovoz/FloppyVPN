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

			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

			new Thread(() => Loc.AutoRefresh()).Start();
			new Thread(() => Cache.AutoRefresh()).Start();

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

			var app = builder.Build();

			// Configure the HTTP request pipeline
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();
			app.UseRouting();

			#region Short paths initialization

			app.MapControllerRoute(
				name: "graduatesRoute",
				pattern: "graduates",
				defaults: new { controller = "Home", action = "Graduates" }
			);

			app.MapControllerRoute(
				name: "scheduleRoute",
				pattern: "schedule",
				defaults: new { controller = "Home", action = "Schedule" }
			);

			app.MapControllerRoute(
				name: "accountRoute",
				pattern: "account",
				defaults: new { controller = "Account", action = "Index" }
			);

			app.MapControllerRoute(
				name: "loginRoute",
				pattern: "login",
				defaults: new { controller = "Account", action = "Login" }
			);

			app.MapControllerRoute(
				name: "nologinRoute",
				pattern: "nologin",
				defaults: new { controller = "Account", action = "NoLogin" }
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


			app.UseExceptionHandler("/Error/500");
			app.UseStatusCodePagesWithReExecute("/Error/{0}");


			app.Urls.Clear();
			app.Urls.Add("http://localhost:14400");

			app.Run();
		}

	}
}