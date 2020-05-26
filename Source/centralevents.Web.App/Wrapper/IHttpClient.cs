using System.Threading.Tasks;

namespace CentralEvents.Web.App.Wrappers
{
	using System.Net.Http;

	public interface IHttpClient
	{
		// CREATE
		Task<HttpResponseMessage> PostAsync<TModel>(string path, TModel model);

		//READ
		Task<TModel> GetJsonAsync<TModel>(string path);

		//UPDATE
		Task<HttpResponseMessage> PutAsync<TModel>(string path, TModel model);
		
		//DELETE
		Task DeleteAsync(string path);
	}
}