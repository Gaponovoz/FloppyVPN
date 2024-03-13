namespace FloppyVPN
{
	/// <summary>
	/// Does periodical jobs like deleting unpaid accounts
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

				Thread.Sleep(60000);
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