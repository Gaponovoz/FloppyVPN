using System.Security.Cryptography;
using System.Text;

namespace FloppyVPN
{
	public static class Cryption
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

		public static string GenerateRandomString(ushort length, string? dictionary = null)
		{
			if (string.IsNullOrEmpty(dictionary))
				dictionary = "qazxswedcrftgyhvbnujikolmp1092384756";

			char[] dic = dictionary.ToCharArray();

			const int REPETITIONS = 1_000_000;
			const int KEY_SIZE = 32;

			double expectedPercentage = 100.0 / dic.Length;

			Dictionary<char, long> grandTotalCounts = new();

			foreach (char ch in dic)
				grandTotalCounts.Add(ch, 0);

			for (int i = 0; i < REPETITIONS; i++)
			{
				var key = GetUniqueKey(KEY_SIZE, dic);

				foreach (var ch in key)
					grandTotalCounts[ch]++;
			}

			long totalChars = grandTotalCounts.Values.Sum();

			StringBuilder result = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				double rnd = GetNextRandomDouble();
				int idx = (int)Math.Floor(rnd * dic.Length);

				result.Append(dic[idx]);
			}

			return result.ToString();

			double GetNextRandomDouble()
			{
				byte[] buffer = new byte[4];
				using (var rng = RandomNumberGenerator.Create())
				{
					rng.GetBytes(buffer);
				}

				uint rand = BitConverter.ToUInt32(buffer, 0);
				return rand / (uint.MaxValue + 1.0);
			}

			string GetUniqueKey(int size, char[] dic)
			{
				byte[] data = new byte[4 * size];
				using (var crypto = RandomNumberGenerator.Create())
				{
					crypto.GetBytes(data);
				}
				StringBuilder result = new(size);
				for (int i = 0; i < size; i++)
				{
					uint rnd = BitConverter.ToUInt32(data, i * 4);
					long idx = rnd % dic.Length;

					result.Append(dic[idx]);
				}

				return result.ToString();
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