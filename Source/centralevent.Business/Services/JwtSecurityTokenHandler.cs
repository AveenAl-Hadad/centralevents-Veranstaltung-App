namespace CentralEvent.Business.Services
{
	using System;
	using System.Collections.Generic;
	using System.IdentityModel.Tokens.Jwt;
	using System.Linq;
	using System.Security.Claims;
	using System.Text;

	using CentralEvent.Business.Contracts.Services;

	using Microsoft.IdentityModel.Tokens;

	public class JwtSecurityTokenHandlerService : IJwtSecurityTokenCreatorService
	{
		private JwtSecurityTokenHandler tokenHandler;

		private byte[] key;
		private int expirationMinutes;

		/// <summary>
		/// Initializes a new instance of the <see cref="JwtSecurityTokenHandlerService"/> class.
		/// </summary>
		public JwtSecurityTokenHandlerService()
		{
			this.tokenHandler = new JwtSecurityTokenHandler();
		}

		public void Initialize(string secret, int expirationMinutes)
		{
			this.key = Encoding.ASCII.GetBytes(secret);
			this.expirationMinutes = expirationMinutes;
		}

		public string CreateToken(IReadOnlyDictionary<string, object> claims)
		{
			IEnumerable<Claim> realClaims = CreateClaims(claims);
			SecurityTokenDescriptor descriptor = CreateTokenDescriptor(this.key, this.expirationMinutes, realClaims);

			string token = this.tokenHandler.CreateEncodedJwt(descriptor);

			return token;
		}

		private static IEnumerable<Claim> CreateClaims(IReadOnlyDictionary<string, object> claims)
		{
			return claims.Select(CreateClaim);
		}

		private static Claim CreateClaim(KeyValuePair<string, object> claim)
		{
			if (claim.Value is bool)
			{
				return new Claim(claim.Key, claim.Value.ToString(), ClaimValueTypes.Boolean);
			}

			return new Claim(claim.Key, claim.Value.ToString());
		}

		private static SecurityTokenDescriptor CreateTokenDescriptor(byte[] key, int expirationMinutes, IEnumerable<Claim> claims)
		{
			return new SecurityTokenDescriptor
				   {
					   Subject = new ClaimsIdentity(claims),
					   Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
					   SigningCredentials =
						   new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
				   };
		}
	}
}