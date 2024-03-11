using MySql.Data.MySqlClient;

namespace FloppyVPN
{
	internal static class DB
	{
		private static readonly string connectionString = $"Server={Config.Get("db_host")};Port={Config.Get("db_port")};Database={Config.Get("db_name")};User={Config.Get("db_user")};Password={Config.Get("db_password")};AllowPublicKeyRetrieval=true;";


		public static void Backupper()
		{
			for (; ; )
			{
				Thread.Sleep(15 * 1000 * 60);

				string backupDir = Path.GetFullPath(Config.Get("db_backups_folder"));

				if (!Directory.Exists(backupDir))
					Directory.CreateDirectory(backupDir);


				string backupName = $"backup {Dating.DateTimeNow()}.sql".Replace(":", "-");
				string backupPath = Path.Combine(backupDir, backupName);

				Backup(backupPath);
			}
		}

		public static void Backup(string backupPath)
		{
			try
			{
				if (File.Exists(backupPath))
					throw new Exception("Dump file already exists");

				using (MySqlConnection connection = new(connectionString))
				{
					using (MySqlCommand command = new())
					{
						using (MySqlBackup mb = new(command))
						{
                            command.Connection = connection;
                            connection.Open();
							mb.ExportToFile(backupPath);
                            connection.Close();
							Console.WriteLine("Backup completed successfully.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred when attempting to backup: {ex.Message}");
			}
		}

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
