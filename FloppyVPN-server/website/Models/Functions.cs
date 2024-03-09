using Microsoft.AspNetCore.Mvc.Razor;

namespace FloppyVPN
{
	public static class Functions
	{
		public static string GetCurrentLanguage(RazorPage page)
		{
			string? languageFromUrl = page.Context.Request.Query["lang"].ToString();
			string detectedLang = "en";

			if (!string.IsNullOrEmpty(languageFromUrl))
			{
				detectedLang = languageFromUrl;
			}

			string? languageFromCookie = page.Context.Request.Cookies["language"];

			if (!string.IsNullOrEmpty(languageFromCookie))
			{
				detectedLang = languageFromCookie;
			}

			if (Loc.table != null && Loc.table.Columns.Contains(detectedLang))
				return detectedLang;
			else
				return "en";
		}
	}
}
