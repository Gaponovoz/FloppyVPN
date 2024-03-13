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

		[HttpGet("RegisterAccount/{private_login}")]
		[ServiceFilter(typeof(UserIsBannedValidationFilter))]
		public string LogintoAccount(string private_login)
		{
			Account acc = new(private_login);
			if (acc.exists)
			{
				return Rialize.Se<DataRow>(acc.accountData);
			}
			else
			{
				Response.StatusCode = StatusCodes.Status404NotFound;
				return "Such account does not seem to exist";
			}
		}
	}
}