using Microsoft.AspNetCore.Mvc;
using static FloppyVPN.ServerTools;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/Website")]
	[ServiceFilter(typeof(MasterKeyValidationFilter))]
	public class WebsiteApiController : ControllerBase
	{
		[HttpGet("RegisterAccount")]
		[ServiceFilter(typeof(UserIsSoftBannedValidationFilter))]
		public string RegisterAccount()
		{
			return Rialize.Se<DataRow>(Account.Register().accountData);
		}

		[HttpGet("LogintoAccount/{private_login}")]
		[ServiceFilter(typeof(UserIsBannedValidationFilter))]
		public string LogintoAccount(string private_login)
		{
			Account acc = new(private_login);
			Karma karma = new(Filters.GetHashedIpFromHeaders(HttpContext.Request));

			if (acc.exists)
			{
				karma.LogRequest(Karma.LogRequestResources.login, true);

				return Rialize.Se<DataRow>(acc.accountData);
			}
			else
			{
				karma.LogRequest(Karma.LogRequestResources.login, false);

				Response.StatusCode = 401;
				return "Such account does not seem to exist";
			}
		}

		[HttpGet("TopupInfo/{public_login}")]
		[ServiceFilter(typeof(UserIsBannedValidationFilter))]
		public string TopupInfo(string public_login)
		{
			return "";
		}
	}
}