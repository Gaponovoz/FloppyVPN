using Microsoft.AspNetCore.Mvc;
using static FloppyVPN.ServerTools;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/Website")]
	[ServiceFilter(typeof(MasterKeyValidationFilter))]
	[ServiceFilter(typeof(UserIsBannedValidationFilter))]
	public class WebsiteApiController : ControllerBase
	{
		[HttpGet("RegisterAccount/{hashed_ip_address}")]
		public string RegisterAccount(string hashed_ip_address)
		{
			return Rialize.Se<DataRow>(Account.Register().accountData);
		}
	}
}