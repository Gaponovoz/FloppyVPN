namespace FloppyVPN
{
	/// <summary>
	/// Used to communicate with the Orchestrator Server and perform aactions
	/// </summary>
	public static class Orchestra
	{
		public static DataRow? GetAccountInfo(string login)
		{
			return Rialize.Dese<DataRow>(Communicator.GetHttp($"{Cache.orchestrator_url}/Communication/GetAccountInfo/Login", Cache.master_key));
		}


	}
}
