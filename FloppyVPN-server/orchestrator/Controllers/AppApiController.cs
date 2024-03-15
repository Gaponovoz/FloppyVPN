using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/App")]
	public class AppApiController : ControllerBase
	{
		[HttpGet("Login")]
		[ServiceFilter(typeof(UserIsBannedValidationFilter))]
		public string Login()
		{
			return "";
		}
	}
}