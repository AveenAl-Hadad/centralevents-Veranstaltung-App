namespace CentralEvents.Web.Api.GuardDogs
{
	using System;
	using System.Threading.Tasks;

	using CentralEvent.Business.Contracts.Services;

	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;

	[Route("api/wachHund")]
	public class WachHund : IAuthenticationHandler
	{
		private readonly IEventService eventService;
		private readonly AuthenticateResult authenticateResult;

		public WachHund()
		{
		}

		public Task<AuthenticateResult> AuthenticateAsync()
		{
			throw new NotImplementedException();
		}

		public Task ChallengeAsync(AuthenticationProperties properties)
		{
			throw new NotImplementedException();
		}

		public Task ForbidAsync(AuthenticationProperties properties)
		{
			throw new NotImplementedException();
		}

		public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
		{
			throw new NotImplementedException();
		}
	}
}