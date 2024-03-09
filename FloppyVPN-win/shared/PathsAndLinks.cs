using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FloppyVPN
{
	public static class PathsAndLinks
	{
		public static readonly string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		public static string appDir = Path.Combine(appDataDir, "FloppyVPN");
		public static string startupShortcutPath = Path.Combine(PathsAndLinks.appDataDir, "Microsoft\\Windows\\Start Menu\\Programs\\Startup", "FloppyVPN.lnk");
		public static string iniFilePath = Path.Combine(PathsAndLinks.appDir, "config.ini");

		public static string masterServerURL = "https://localhost";
	}
}
