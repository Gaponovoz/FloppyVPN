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

			Config.ConfigFileIntegrity();

			Api.Start();
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