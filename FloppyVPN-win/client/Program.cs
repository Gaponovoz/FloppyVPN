using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace FloppyVPN
{
	internal static class Program
	{
		//DPI fix:
		[DllImport("user32.dll")]
		private static extern bool SetProcessDPIAware();


		[STAThread]
		static void Main(string[] args)
		{
			//get chosen language or detect it:
			Loc.lang = IniFile.GetValue("lang");
			if (Loc.lang.Length != 2)
				Loc.lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToLower();
			Loc.Alize();

			//only single instance:
			Mutex mutex = new Mutex(true, "q2gcl75BlLXN9K60SVT3dcJJ3P8eSQQi", out bool result);
			if (!result)
			{
				new MsgBox(Loc.alreadylaunched);
				Environment.Exit(0);
			}
			GC.KeepAlive(mutex);

			//DPI fix:
			if (Environment.OSVersion.Version.Major >= 6)
				SetProcessDPIAware();

			//disable SSL warnings:
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

			//use custom exception handler:
			Application.ThreadException += new ThreadExceptionEventHandler(Shared.Exception);

			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(PathsAndLinks.iniFilePath));
			}
			catch
			{
			}

			//check for driver existance:
			//if (!File.Exists(Vpn.pathToDriver))
			//{
			//	new MsgBox(Loc.cantFindDriver, "FloppyVPN", MessageBoxIcon.Error).ShowDialog();
			//	Environment.Exit(0);
			//}

			bool connectAfterLaunch = false;
			try
			{
				if (args[0].Contains("--connect after launch"))
					connectAfterLaunch = true;
			}
			catch
			{
			}

			Vpn.Disconnect();

			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(connectAfterLaunch));
		}
	}
}