using System;
using System.Collections.Generic;
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
		public static string programname = "FloppyVPN";
		public static string publishername = "OtsoSoftware";
		public static string language = "en";
		public static string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		public static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		public static string tempfolder = Path.GetTempPath();
		public static string tempfile = Path.Combine(tempfolder, "FloppyVPN_archive.zip");
		public static string programfiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
		public static string installfolder = Path.Combine(localappdata, "Programs", "FloppyVPN");
		public static string pathtoinstalledexe = Path.Combine(installfolder, "FloppyVPN.exe");
		public static string startmenushortcutfolder = Path.Combine(appdata, "Microsoft", "Windows", "Start Menu");
		public static string startmenushortcutfile = Path.Combine(startmenushortcutfolder, "FloppyVPN.lnk");

		public static string linkToDistro = $"{PathsAndLinks.masterServerURL}/repo/";
		public static string linkToDriver = $"{PathsAndLinks.masterServerURL}/repo/";



		[DllImport("user32.dll")]
		private static extern bool SetProcessDPIAware();



		[STAThread]
		static void Main()
		{
			//single instance:
			var mutex = new Mutex(true, "floppyvpninstaller8g78wegy4hnrtsjr6j6rjysjs6ryjgyshs985ygh", out bool result);
			if (!result)
			{
				Environment.Exit(0);
			}
			GC.KeepAlive(mutex);

			//disable SSL checks (there was no ssl/tls in good old days):
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

			//detect user PC language:
			string currentculture = CultureInfo.CurrentUICulture.Name.ToLower();
			if (currentculture.Contains("ru") || currentculture.Contains("uk") || currentculture.Contains("uz") || currentculture.Contains("bel") || currentculture.Contains("kz"))
				language = "ru";

			//use custom exception handler:
			Application.ThreadException += new ThreadExceptionEventHandler(Shared.Exception);

			//fix DPI:
			if (Environment.OSVersion.Version.Major >= 6)
				SetProcessDPIAware();

			//depending on system architecture, use appropriate binary:
			Architecture arch = RuntimeInformation.ProcessArchitecture;
			switch (arch)
			{
				case Architecture.X64:
					linkToDriver += "x86_64.msi";
					break;
				case Architecture.Arm64:
					linkToDriver += "arm64.msi";
					break;
				case Architecture.X86:
					linkToDriver += "x86.msi";
					break;
				default:
					if (Environment.Is64BitOperatingSystem)
						linkToDriver += "x86_64.msi";
					else
						linkToDriver += "x86.msi";
					break;
			}


			//launch the installer interface:
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new InstallForm());
		}
	}
}
