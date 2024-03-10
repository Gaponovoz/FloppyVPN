using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("VpnApi")]
	public class VpnApiController : Controller
	{
		[HttpGet("Test")]
		public string Test()
		{
			return "hi";
		}
	}
}
