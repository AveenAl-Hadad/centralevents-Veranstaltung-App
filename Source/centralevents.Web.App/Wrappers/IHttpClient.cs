namespace CentralEvents.Web.App.Wrappers
{
	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Http;
	using System.Net.Http;
	using System.Threading.Tasks;

	public interface IHttpClient
	{
		// CREATE
		Task<HttpResponseMessage> PostAsync<TModel>(string path, TModel model);

		Task<TModel> PostJsonAsync<TModel>(string path, TModel model);


		//READ
		Task<TModel> GetJsonAsync<TModel>(string path);

		//UPDATE
		Task<HttpResponseMessage> PutAsync<TModel>(string path, TModel model);

		//DELETE
		Task DeleteAsync(string path);

		public Task<AuthenticateResult> AuthenticateAsync();

		public Task ChallengeAsync(AuthenticationProperties properties);

		public Task ForbidAsync(AuthenticationProperties properties);

		public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context);
	}
}