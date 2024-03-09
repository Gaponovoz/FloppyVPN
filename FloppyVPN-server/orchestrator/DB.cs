using MySql.Data.MySqlClient;

namespace FloppyVPN
{
	internal static class DB
	{
		private static readonly string connectionString = $"Server=localhost;Port=3306;Database=AAAAAAAA;User={Config.Get("db_user")};Password={Config.Get("db_password")};";

		public static void Execute(string query, Dictionary<string, object> parameters = null)
		{
			using (MySqlConnection connection = new(connectionString))
			using (MySqlCommand command = new(query, connection))
			{
				if (parameters != null)
				{
					foreach (var param in parameters)
					{
						command.Parameters.AddWithValue(param.Key, param.Value);
					}
				}

				command.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// To be used with INSERT commands only.
		/// </summary>
		/// <returns>ID of the newly created record</returns>
		public static uint InsertAndGetID(string query, Dictionary<string, object> parameters = null)
		{
			using (MySqlConnection connection = new(connectionString))
			using (MySqlCommand cmd = new(query, connection))
			{
					if (parameters != null)
					{
						foreach (var param in parameters)
						{
							cmd.Parameters.AddWithValue(param.Key, param.Value);
						}
					}

					// Выполнение запроса на вставку
					cmd.ExecuteNonQuery();

					// Получение ID последней вставленной строки
					cmd.CommandText = "SELECT LAST_INSERT_ID();";
					uint lastInsertedId = Convert.ToUInt32(cmd.ExecuteScalar());

					return lastInsertedId;
			}
		}


		public static object GetValue(string query, Dictionary<string, object> parameters = null)
		{
			using (MySqlConnection connection = new(connectionString))
			using (MySqlCommand command = new(query, connection))
			{
				if (parameters != null)
				{
					foreach (var param in parameters)
					{
						command.Parameters.AddWithValue(param.Key, param.Value);
					}
				}

				return command.ExecuteScalar();
			}
		}

		public static string GetConfig(string key)
		{
			return GetValue("SELECT `value` FROM `config` WHERE `name` = @key", new Dictionary<string, object> { { "@key", key } }).ToString();
		}

		public static void SetConfig(string key, string value)
		{
			Execute("UPDATE `config` SET `value` = @value WHERE `name` = @key", new Dictionary<string, object> { { "@value", value }, { "@key", key } });
		}

		public static DataTable GetDataTable(string query, Dictionary<string, object> parameters = null)
		{
			DataTable dataTable = new();

			using (MySqlConnection connection = new(connectionString))
			using (MySqlCommand command = new(query, connection))
			{
				if (parameters != null)
				{
					foreach (var param in parameters)
					{
						command.Parameters.AddWithValue(param.Key, param.Value);
					}
				}

				using (MySqlDataAdapter adapter = new(command))
				{
					adapter.Fill(dataTable);
				}
			}

			return dataTable;
		}

		public static string[] FirstColumnAsArray(string query)
		{
			List<string> array = new();

			DataTable dt = GetDataTable(query);

			foreach (DataRow row in dt.Rows)
			{
				array.Add(row[0].ToString());
			}

			return array.ToArray();
		}
	}
}
