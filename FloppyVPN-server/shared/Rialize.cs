using Newtonsoft.Json;
using System.Xml.Serialization;

namespace FloppyVPN
{
	/// <summary>
	/// Serializes and deserializes any object into a json string and from the json string. 
	/// </summary>
	public static class Rialize
	{
		public static string Se<T>(T obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

		public static T? Dese<T>(string json)
		{
			try
			{
				return JsonConvert.DeserializeObject<T>(json);
			}
			catch
			{
				return default;
			}
		}
	}
}