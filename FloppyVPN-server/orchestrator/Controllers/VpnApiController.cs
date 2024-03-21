using Microsoft.AspNetCore.Mvc;

namespace FloppyVPN.Controllers
{
	[ApiController]
	[Route("Api/Vpn")]
	[ServiceFilter(typeof(MasterKeyValidationFilter))]
	public class VpnApiController : Controller
	{
		/// <summary>
		/// For vpn servers to claim their existance to the orchestrator server.
		/// Usually for first launch so the orchestrator will know there's such vpn server.
		/// </summary>
		[HttpPost("MyNameIsFloppyVpnVpnServerButEverybodyCallsMeVpn")]
		public string SelfClaim()
		{
			string body = "";
			using (StreamReader sr = new(Request.Body))
			{
				body = sr.ReadToEnd();
			}



			return "ok";
		}
	}
}