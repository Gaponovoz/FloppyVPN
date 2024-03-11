using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("GeneralApi")]
	public class GeneralApiController : ControllerBase
	{
		[HttpGet("CurrentDateTime")]
		public string Test()
		{
			return "hi";
		}
	}
}