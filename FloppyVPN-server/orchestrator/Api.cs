using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace FloppyVPN
{
	public class Api
	{
		public static void Start()
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder();
			builder.Services.AddEndpointsApiExplorer();
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

			WebApplication app = builder.Build();
			app.Urls.Clear();
			app.Urls.Add("https://localhost:1440");


			app.MapGet("/weatherforecast", (HttpContext httpContext) =>
			{
				return "";
			});


			app.Run();
		}
	}
}
