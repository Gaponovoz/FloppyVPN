using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using System.Net;

namespace FloppyVPN
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			//single instance:
			Mutex mutex = new(true, "floppyvpn_orchestrator_L2Neli82o5I8P1hsqVtOHoq67htydhythtdeyj8AuWYE", out bool result);
			if (!result)
			{
				Console.WriteLine("The same server is already running so it won't start again.");
				Environment.Exit(0);
			}
			GC.KeepAlive(mutex);

			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

			Config.EnsureFileIntegrity();

			Startup(args);
		}

		static void Startup(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orchestrator server API", Version = "v1" });
			});

			builder.Services.Configure<KestrelServerOptions>(options =>
			{
				options.AllowSynchronousIO = true;
				options.Limits.MaxRequestBodySize = 300000000;
			});
			builder.Services.Configure<FormOptions>(options =>
			{
				options.ValueCountLimit = int.MaxValue;
				options.MultipartBodyLengthLimit = 30000000;
				options.MemoryBufferThreshold = int.MaxValue;
			});

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

			app.MapControllers();

			app.Urls.Clear();
			app.Urls.Add("http://localhost:1440");

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orchestrator Server API");
				c.RoutePrefix = "swagger"; // set Swagger UI at the app root
			});


			app.Run();
		}

		public static void Log(string where, string what)
		{
			Console.WriteLine($"{Dating.DateNow()}  {where}\t{what}");

			try
			{

			}
			catch
			{
			}

			DB.Execute("INSERT INTO `logs` (``, ``, ``) VALUES ('@ddd', '@fff', '@lll');", new Dictionary<string, object>()
			{
				{ "", Dating.DateNow() },
				{ "", where },
				{ "", what },
			});
		}
	}
}