namespace FloppyVPN
{
	/// <summary>
	/// 
	/// </summary>
	internal static class Worker
	{
		public static void Start()
		{
			Thread.Sleep(5000);
			for (; ; )
			{
				DeleteUnpaidUsers();


				Thread.Sleep(60000);
			}
		}

		static void DeleteUnpaidUsers()
		{

		}
	}
}