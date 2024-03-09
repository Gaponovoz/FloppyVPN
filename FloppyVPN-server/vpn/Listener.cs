namespace FloppyVPN
{
	public static class Listener
	{
		public static void Start()
		{
			var builder = WebApplication.CreateBuilder();

			var app = builder.Build();

			app.MapGet("/", () =>
			{
				return "vpn";
			});

			app.Run();
		}
	}
}
