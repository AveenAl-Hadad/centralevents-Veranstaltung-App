namespace CentralEvents.Web.Api.Authorization
{
	using System;
	using System.IdentityModel.Tokens.Jwt;
	using System.Linq;
	using System.Threading.Tasks;

	using CentralEvent.Business.Services;

	using Microsoft.AspNetCore.Authentication.JwtBearer;

	public class CustomJwtBearerEvents : JwtBearerEvents
	{
		private const string BearerPrefix = "Bearer ";

		/// <summary>Invoked when a protocol message is first received.</summary>
		public override Task MessageReceived(MessageReceivedContext context)
		{
			string authorization = context.Request.Headers["Authorization"];

			if (string.IsNullOrEmpty(authorization))
			{
				context.NoResult();
				return Task.CompletedTask;
			}

			if (authorization.StartsWith(BearerPrefix, StringComparison.OrdinalIgnoreCase))
			{
				context.Token = authorization.Substring(BearerPrefix.Length).Trim();
			}

			if (string.IsNullOrEmpty(context.Token))
			{
				context.NoResult();
				return Task.CompletedTask;
			}

			StoreUserName(context);

			return Task.CompletedTask;
		}

		private static void StoreUserName(MessageReceivedContext context)
		{
			string token = context.Token;

			if (token != null)
			{
				JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

				JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);
				string benutzername = jwtToken.Claims.First(c => c.Type == "Benutzername").Value;

				SessionService.Instance.Benutzername = benutzername;
			}
		}
	}
}