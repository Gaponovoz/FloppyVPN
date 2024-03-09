namespace FloppyVPN
{
	/// <summary>
	/// Retrieves information about current VPN server configuration which was written on disk during installation
	/// </summary>
	internal static class Properties
	{
		private static string configFolder = "/FloppyVPN/";
		private static string configFileLocation = "/root/FloppyVPNserver.ini";



		public static void GetProperties()
		{
			
			File.ReadAllText(configFolder + "key");
		}
	}
}