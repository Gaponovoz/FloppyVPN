namespace FloppyVPN
{
	/// <summary>
	/// A simple class for storing and updating frequently used data as cached data 
	/// because we are not going to read it from DB each time, right?
	/// </summary>
	internal static class Cache
	{
		/// <summary>
		/// Automatically refreshes cached data each X minutes
		/// </summary>
		internal static void AutoRefresh()
		{
			for (; ; )
			{
				Refresh();
				Thread.Sleep(5 * 1000 * 60);
			}
		}

		/// <summary>
		/// Refreshes cached data
		/// </summary>
		internal static void Refresh()
		{
			try
			{

			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine($"Could not refresh Cache: {ex.Message} {ex.Source} {ex.InnerException}");
				Console.ForegroundColor = ConsoleColor.White;
			}
		}

		#region Cached data

		public static string x = "";


		#endregion
	}
}
