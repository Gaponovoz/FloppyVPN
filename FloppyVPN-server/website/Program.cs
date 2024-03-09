using System.Net;

namespace FloppyVPN
{
	public class Program
	{
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


            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            new Thread(() => Localizations.AutoRefresh()).Start();

            Startup(args);
        }


        public static void Startup(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            #region Short paths initialization

            app.MapControllerRoute(
                name: "graduatesRoute",
                pattern: "graduates",
                defaults: new { controller = "Home", action = "Graduates" }
            );

            app.MapControllerRoute(
                name: "avtoparkRoute",
                pattern: "avtopark",
                defaults: new { controller = "Home", action = "Avtopark" }
            );

            app.MapControllerRoute(
                name: "krasnodonRoute",
                pattern: "krasnodon",
                defaults: new { controller = "Home", action = "Krasnodon" }
            );

            app.MapControllerRoute(
                name: "avtodromRoute",
                pattern: "avtodrom",
                defaults: new { controller = "Home", action = "Avtodrom" }
            );

            app.MapControllerRoute(
                name: "scheduleRoute",
                pattern: "schedule",
                defaults: new { controller = "Home", action = "Schedule" }
            );

            app.MapControllerRoute(
                name: "classesRoute",
                pattern: "classes",
                defaults: new { controller = "Home", action = "Classes" }
            );

            app.MapControllerRoute(
                name: "enrollRoute",
                pattern: "enroll",
                defaults: new { controller = "Account", action = "Enroll" }
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