using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/App")]
	public class AppApiController : ControllerBase
	{
		[HttpGet("Test")]
		public string Test()
		{
			return "hello";
		}
	}
}
