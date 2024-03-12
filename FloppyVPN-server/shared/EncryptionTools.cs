using System.Security.Cryptography;
using System.Text;

namespace FloppyVPN
{
	public static class EncryptionTools
	{
		public static string Hash(string s)
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

		public static string Encrypt(string s)
		{
			return "";
		}

		public static string Decrypt(string s)
		{
			return "";
		}
	}
}