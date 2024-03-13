using Newtonsoft.Json;

namespace FloppyVPN
{
	/// <summary>
	/// Serializes and deserializes any object into a json string and from the json string. 
	/// </summary>

	public static class Rialize
	{
		public static string Se<T>(T obj)
		{
			// For DataRow, serialize to dictionary
			if (typeof(T) == typeof(DataRow))
			{
				DataRow row = obj as DataRow;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				foreach (DataColumn column in row.Table.Columns)
				{
					dictionary[column.ColumnName] = row[column];
				}
				return JsonConvert.SerializeObject(dictionary);
			}
			else
			{
				return JsonConvert.SerializeObject(obj);
			}
		}

		public static T? Dese<T>(string json)
		{
			try
			{
				if (typeof(T) == typeof(DataRow))
				{
					// Deserialize from dictionary to DataRow
					Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
					DataTable table = new DataTable();
					foreach (var key in dictionary.Keys)
					{
						table.Columns.Add(key, dictionary[key]?.GetType() ?? typeof(object));
					}
					DataRow row = table.NewRow();
					foreach (var key in dictionary.Keys)
					{
						row[key] = dictionary[key];
					}
					return (T)(object)row;
				}
				else
				{
					return JsonConvert.DeserializeObject<T>(json);
				}
			}
			catch
			{
				return default;
			}
		}
	}
}