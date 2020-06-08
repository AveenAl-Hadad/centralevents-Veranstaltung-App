namespace CentralEvents.Web.App.Wrappers
{
	using System.Net.Http;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Mvc;

	using RestSharp;

	public interface IHttpClient
	{
		// CREATE
		Task<HttpResponseMessage> PostAsync<TModel>(string path, TModel model);

		Task<TModel> PostJsonAsync<TModel>(string path, TModel model);

		//READ
		Task<TModel> GetJsonAsync<TModel>(string path);

		Task<IRestResponse> GetAsync(string path);


		//UPDATE
		Task<HttpResponseMessage> PutAsync<TModel>(string path, TModel model);

		//DELETE
		Task DeleteAsync(string path);


		Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);

	}
}