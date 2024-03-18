namespace FloppyVPN
{
	/// <summary>
	/// Does periodical jobs like deleting data which is not needed anymore at all
	/// </summary>
	internal static class Worker
	{
		public static void Start()
		{
			Thread.Sleep(5000);
			for (; ; )
			{
				DeleteUnpaidAccounts();
				DeleteOldRequests();

				Thread.Sleep(15 * 1000 * 60);
			}
		}

		static void DeleteUnpaidAccounts()
		{

		}

		static void DeleteOldRequests()
		{

		}
	}
}