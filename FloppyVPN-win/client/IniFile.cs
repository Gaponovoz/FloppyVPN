using System.Runtime.InteropServices;
using System.Text;

namespace FloppyVPN
{
	public static class IniFile
	{
		private static string IniFilePath => PathsAndLinks.iniFilePath;

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		private const string DefaultSection = "Settings";

		public static void SetValue(string key, string value)
		{
			WritePrivateProfileString(DefaultSection, key, value, IniFilePath);
		}

		public static string GetValue(string key, string defaultValue = "")
		{
			StringBuilder temp = new StringBuilder(255);
			int i = GetPrivateProfileString(DefaultSection, key, defaultValue, temp, 255, IniFilePath);
			return temp.ToString();
		}
	}
}