using Microsoft.AspNetCore.Http;

namespace FloppyVPN;

public static class ServerTools
{
	public static bool IsValidMasterKey(HttpRequest request)
	{
		string master_key_config = (Config.cache["master_key"] ?? "").ToString();
		string master_key_request;

		try
		{
			master_key_request = request.Headers["master_key"].FirstOrDefault();
		}
		catch
		{
			master_key_request = "";
		}

		if (master_key_request != master_key_config)
			return false;
		else
			return true;
	}

	public static string GetHashedIPAddress(HttpRequest request)
	{
		string? ip_address_raw = "";
		string ip_address_hashed = "";

		// Get the comma-separated list of IP addresses from the X-Forwarded-For header
		string forwardedForHeader = request.Headers["X-Forwarded-For"].FirstOrDefault();

		if (!string.IsNullOrEmpty(forwardedForHeader))
		{
			// Split the header value into individual IP addresses
			string[] forwardedIps = forwardedForHeader.Trim().Split(',');

			// Find the first non-local and non-empty IP address in the list
			foreach (string ip in forwardedIps.Reverse())
			{
				if (!string.IsNullOrEmpty(ip) && !IsLocalIpAddress(ip.Trim()))
				{
					ip_address_raw = ip.Trim();
					break;
				}
			}
		}

		// If X-Forwarded-For header is not present or all IPs are local, fallback to RemoteIpAddress
		if (ip_address_raw == "")
			ip_address_raw = request.HttpContext.Connection.RemoteIpAddress?.ToString();

		ip_address_hashed = Cryption.Hash(ip_address_raw ?? "unknown");

		return ip_address_hashed;
	}

	private static bool IsLocalIpAddress(string ipAddress)
	{
		string[] localIpPrefixes = { "10.", "172.", "192.", "127." };

		return localIpPrefixes.Any(prefix => ipAddress.StartsWith(prefix, StringComparison.Ordinal));
	}
}