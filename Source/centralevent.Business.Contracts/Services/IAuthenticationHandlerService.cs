namespace CentralEvent.Business.Contracts.Services
{
	using System.Threading.Tasks;

	using CentralEvent.Business.Contracts.Models;

	public interface IAuthenticationHandlerService
	{
		Task<string> CreateToken(CustomerCredentials credentials);

	}
}