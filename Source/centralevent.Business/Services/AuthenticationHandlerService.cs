namespace CentralEvent.Business.Services
{
	using System.Collections.Generic;
	using System.Security.Authentication;
	using System.Threading.Tasks;

	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	public class AuthenticationHandlerService : IAuthenticationHandlerService
	{
		private readonly IJwtSecurityTokenCreatorService tokenCreatorService;
		private readonly IEventService eventService;
		private const string ClaimUsername = "Benutzername";

		public AuthenticationHandlerService(IJwtSecurityTokenCreatorService tokenCreatorService, IEventService eventService)
		{
			this.tokenCreatorService = tokenCreatorService;
			this.eventService = eventService;
		}

		public async Task<string> CreateToken(CustomerCredentials credentials)
		{
			this.Authorize(credentials);

			Dictionary<string, object> claims = this.CreateClaims(credentials.Benutzername);

			return this.tokenCreatorService.CreateToken(claims);
		}

		private void Authorize(CustomerCredentials credentials)
		{
			CustomerModel customerModel = this.GetCustomerByName(credentials.Benutzername);

			if (!(credentials.Benutzername == customerModel.Benutzername && credentials.Passwort == customerModel.Passwort))
			{
				throw new AuthenticationException();
			}
		}

		private Dictionary<string, object> CreateClaims(string userName)
		{
			return new Dictionary<string, object>
				   {
					   { ClaimUsername, userName }
				   };
		}

		private CustomerModel GetCustomerByName(string userName)
		{
			return this.eventService.GetCustomerByName(userName);
		}
	}
}