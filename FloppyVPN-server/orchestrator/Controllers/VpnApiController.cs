using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/Vpn")]
	[ServiceFilter(typeof(MasterKeyValidationFilter))]
	public class VpnApiController : Controller
	{
		[HttpGet("Test")]
		public string Test()
		{
			return "hi";
		}
	}
}
