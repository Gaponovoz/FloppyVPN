using System.Security.Cryptography;
using System.Text;

namespace FloppyVPN
{
	public static class Utils
	{
		public static string GetHash(string s)
		{
			string key = Config.Get("master_key");
			s += key; //add key as salt to maximally reduce bruteforce possibility

			using (SHA512 sha = SHA512.Create())
			{
				byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(s));

				StringBuilder builder = new();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}

		public static byte ToTinyInt(this bool b)
		{
			if (b == true)
				return (byte)1;
			else
				return (byte)0;
		}

	}
}