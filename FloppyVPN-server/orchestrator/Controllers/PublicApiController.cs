using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/Public")]
	public class PublicApiController : ControllerBase
	{
		[HttpGet("Test")]
		public string Test()
		{
			return "hello";
		}
	}
}
