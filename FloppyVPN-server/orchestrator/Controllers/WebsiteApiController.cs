using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("WebsiteController")]
	public class WebsiteApiController : ControllerBase
	{
		[HttpGet("Test")]
		public string Test()
		{
			return "hello";
		}
	}
}