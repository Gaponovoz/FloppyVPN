using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloppyVPN
{
	public static class Vpn
	{
		public static bool connected = false;
		public static string pathToConf = Path.Combine(PathsAndLinks.appDir, "FloppyVPN.conf");
		public static string tunnelName = "FloppyVPN";
		public static string pathToDriver = Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), "Program Files\\WireSock VPN Client\\bin\\wiresock-client.exe");


		public static void Connect()
		{
			try
			{
				try { Disconnect(); } catch { }

				if (!File.Exists(pathToConf))
					throw new Exception("Config file does not exist!");

				ProcessStartInfo psi = new ProcessStartInfo();
				psi.FileName = pathToDriver;
				psi.Arguments = $"run -config \"{pathToConf}\" -log-level none";
				//if () //use virtual adapter if user prefers to
				//	psi.Arguments += " -lac";
				psi.RedirectStandardOutput = true;
				psi.RedirectStandardError = true;
				psi.UseShellExecute = false;
				psi.CreateNoWindow = true;

				using (Process process = new Process { StartInfo = psi })
				{
					process.Start();
				}

				Task.Delay(new Random().Next(300, 700)).GetAwaiter().GetResult();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error running driver: {ex.Message}");
			}
		}

		public static void Disconnect()
		{
			try
			{
				foreach (var process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(pathToDriver)))
				{
					process.Kill();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Error stopping driver: {ex.Message}");
			}
		}

		public static void StartKillSwitch()
		{

		}
	}
}