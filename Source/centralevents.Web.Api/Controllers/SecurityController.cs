namespace CentralEvents.Web.Api.Controllers
{
	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Services;

	using CentralEvents.Web.Api.Controllers.Base;

	using Microsoft.AspNetCore.Mvc;

	[Route("api/security")]
	public class SecurityController : AuthorizedController
	{
		[Route("")]
		[HttpGet]
		public SecurityModel Test()
		{
			string userName = SessionService.Instance.Benutzername;
			return new SecurityModel { IsAuthorized = true, Benutzername = userName };
		}
	}
}