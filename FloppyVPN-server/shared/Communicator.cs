using System.Net;

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
		public static string GetHttp(string url, string master_key, string hashed_user_ip_address, out HttpStatusCode status_code, out bool is_successful)
		{
			using (HttpClient client = new())
			{
				client.DefaultRequestHeaders.Add("master_key", master_key);
				client.DefaultRequestHeaders.Add("hashed_user_ip_address", hashed_user_ip_address);

				HttpResponseMessage response = client.GetAsync(url).Result;

				status_code = response.StatusCode;
				is_successful = response.IsSuccessStatusCode;

				return response.Content.ReadAsStringAsync().Result;
			}
		}

		/// <summary>
		/// Sends an HTTP POST request.
		/// </summary>
		/// <param name="url">The URL to send the request to.</param>
		/// <param name="body">The body of the request.</param>
		/// <param name="master_key">The value of the "master_key" header.</param>
		/// <returns>The response body.</returns>
		public static string PostHttp(string url, object body, string master_key, string hashed_user_ip_address, out HttpStatusCode status_code, out bool is_successful)
		{
			using (HttpClient client = new())
			{
				client.DefaultRequestHeaders.Add("master_key", master_key);
				client.DefaultRequestHeaders.Add("hashed_user_ip_address", hashed_user_ip_address);

				string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);
				HttpContent content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = client.PostAsync(url, content).Result;

				status_code = response.StatusCode;
				is_successful = response.IsSuccessStatusCode;

				return response.Content.ReadAsStringAsync().Result;
			}
		}
	}

}