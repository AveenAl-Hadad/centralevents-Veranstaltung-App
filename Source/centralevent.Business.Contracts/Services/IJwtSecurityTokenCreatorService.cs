namespace CentralEvent.Business.Contracts.Services
{
	using System.Collections.Generic;

	public interface IJwtSecurityTokenCreatorService
	{
		string CreateToken(IReadOnlyDictionary<string, object> claims);
	}
}