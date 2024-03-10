namespace FloppyVPN
{
	/// <summary>
	/// For making HTTP requests for communication between servers easily.
	/// </summary>
	public static class Communicator
	{
		/// <summary>
		/// Sends an HTTP GET request.
		/// </summary>
		/// <param name="url">The URL to send the request to.</param>
		/// <param name="master_key">The value of the "master_key" header.</param>
		/// <returns>The response body.</returns>
		public static string GetHttp(string url, string master_key)
		{
			using (HttpClient client = new())
			{
				client.DefaultRequestHeaders.Add("master_key", master_key);
				HttpResponseMessage response = client.GetAsync(url).Result;

				if (response.IsSuccessStatusCode)
				{
					return response.Content.ReadAsStringAsync().Result;
				}
				else
				{
					throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
				}
			}
		}

		/// <summary>
		/// Sends an HTTP POST request.
		/// </summary>
		/// <param name="url">The URL to send the request to.</param>
		/// <param name="body">The body of the request.</param>
		/// <param name="master_key">The value of the "master_key" header.</param>
		/// <returns>The response body.</returns>
		public static string PostHttp(string url, object body, string master_key)
		{
			using (HttpClient client = new())
			{
				client.DefaultRequestHeaders.Add("master_key", master_key);
				string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);
				HttpContent content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = client.PostAsync(url, content).Result;

				if (response.IsSuccessStatusCode)
				{
					return response.Content.ReadAsStringAsync().Result;
				}
				else
				{
					throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
				}
			}
		}
	}

}