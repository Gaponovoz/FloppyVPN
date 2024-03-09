using System.Data;

namespace FloppyVPN
{
	public static class Localizations
	{
		private static DataTable localizations = null;

		public static void AutoRefresh()
		{
			for (; ; )
			{
				Refresh();
				Thread.Sleep(15 * 1000 * 60);
			}
		}

		public static void Refresh()
		{
			localizations = Config.LoadDataTable("");
		}

		public static string Get(string name, string lang)
		{
			try
			{
				return localizations.Select($"name = '{name}'")[0][lang].ToString();
			}
			catch
			{
				return "";
			}
		}
	}
}