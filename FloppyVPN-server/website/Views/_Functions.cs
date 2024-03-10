using Microsoft.AspNetCore.Mvc.Razor;

namespace FloppyVPN
{
	public static class _Functions
	{
		public static string GetCurrentLanguage(RazorPage page)
		{
			string? languageFromUrl = page.Context.Request.Query["lang"].ToString();
			string detectedLang = "en";

			if (!string.IsNullOrEmpty(languageFromUrl))
			{
				detectedLang = languageFromUrl;
			}

			string? languageFromCookie = ReadCookie(page, "language");

			if (!string.IsNullOrEmpty(languageFromCookie))
			{
				detectedLang = languageFromCookie;
			}

			decision:

			if (Loc.table != null && Loc.table.Columns.Contains(detectedLang))
			{
				if (languageFromCookie != languageFromUrl && languageFromCookie == null && languageFromUrl != null)
					WriteCookie(page, "language", languageFromUrl);

				return detectedLang;
			}
			else
			{
				return "en";
			}
		}

		public static void WriteCookie(RazorPage page, string key, string value)
		{
			page.Context.Response.Cookies.Append(key, value, new CookieOptions() { Expires = DateTimeOffset.MaxValue });
		}

		public static string? ReadCookie(RazorPage page, string key)
		{
			return page.Context.Request.Cookies[key] ?? null;
		}
	}
}
