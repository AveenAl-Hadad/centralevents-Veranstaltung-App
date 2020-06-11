

namespace CentralEvents.Web.Api.Controllers
{
	using System.Security.Authentication;
	using System.Threading.Tasks;

	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	[Route("api/security")]
	[AllowAnonymous]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationHandlerService authenticationHandlerService;

		/// <summary>
		/// Initializes a new instance of the <see cref="AuthenticationController"/> class.
		/// </summary>
		public AuthenticationController(IAuthenticationHandlerService authenticationHandlerService)
		{
			this.authenticationHandlerService = authenticationHandlerService;
		}

		[Route("")]
		[HttpPost]
		public async Task<IActionResult> RequestToken([FromBody] CustomerCredentials credentials)
		{
			try
			{
				string token = await this.authenticationHandlerService.CreateToken(credentials);

				return this.Ok(ToJsonString(token));
			}
			catch (AuthenticationException)
			{
				return this.Unauthorized();
			}
		}

		/// <summary>
		/// TODO: Remove when testing ended.
		/// </summary>
		[Route("{username}")]
		[HttpGet]
		public async Task<IActionResult> TestAuthentication(string username)
		{
			return await this.RequestToken(new CustomerCredentials { Username = username });
		}

		private static string ToJsonString(string message)
		{
			return $"\"{message}\"";
		}
	}
}
