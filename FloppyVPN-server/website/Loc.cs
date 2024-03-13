namespace FloppyVPN
{
	/// <summary>
	/// Class responsible for obtaining, caching and providing localized strings for Views.
	/// </summary>
	internal static class Loc
	{
		public static DataTable table = null;

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
			table = Config.LoadDataTable(Program.PathToLocalizations);
		}

		public static string Get(string name, string lang)
		{
			try
			{
				return (table.Select($"name = '{name}'")[0][lang] ?? "").ToString().Replace("\r\n", "<br>").Replace("\\n", "<br>");
			}
			catch
			{
				return "?";
			}
		}
	}
}