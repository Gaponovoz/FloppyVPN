using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FloppyVPN
{
	/// <summary>
	/// Common data and general functions.
	/// </summary>
	public static class Shared
	{
		public static void LaunchWebsite(string url)
		{
			try
			{
				Process.Start(url);
			}
			catch
			{
				Process.Start("explorer.exe", url);
			}
		}

		public static string DownloadString(string url)
		{
			using (HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(10) })
			{
				try
				{
					return httpClient.GetStringAsync(url).Result;
				}
				catch //will simply return an empty string on fail
				{
					return "";
				}
			}
		}

		public static void DownloadFile(string url, string path)
		{
			using (var client = new HttpClient())
			{
				using (var response = client.GetAsync(url).Result)
				{
					using (FileStream fileStream = new FileStream(path, FileMode.Create))
					{
						response.EnsureSuccessStatusCode();
						var contentStream = response.Content.ReadAsStreamAsync().Result;
						contentStream.CopyTo(fileStream);
					}
				}
			}
		}

		public static void Exception(object sender, ThreadExceptionEventArgs e)
		{
			new MsgBox(e.Exception.Message, "Loc.errorCaption", MessageBoxIcon.Error, MessageBoxButtons.OK).ShowDialog();
		}
	}
}