using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("WebsiteController")]
	public class WebsiteApiController : ControllerBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns>nothing yet</returns>
		[HttpGet("Test")]
		public string Test()
		{
			return "hello";
		}
	}
}