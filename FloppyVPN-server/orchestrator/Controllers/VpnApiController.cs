using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/Vpn")]
	public class VpnApiController : Controller
	{
		[HttpGet("Test")]
		public string Test()
		{
			return "hi";
		}
	}
}
