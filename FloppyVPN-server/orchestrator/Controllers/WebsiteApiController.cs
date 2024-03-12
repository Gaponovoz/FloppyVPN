using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/Website")]
	public class WebsiteApiController : ControllerBase
	{
		[HttpGet("Test")]
		public string Test()
		{
			return "hello";
		}
	}
}