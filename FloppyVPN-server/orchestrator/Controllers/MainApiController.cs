using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("MainApi")]
	public class MainApiController : ControllerBase
	{
		[HttpGet("CurrentDateTime")]
		public string Test()
		{
			return "hi";
		}
	}
}