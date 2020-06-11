namespace CentralEvents.Web.App.Wrappers
{
	using System.Net.Http;
	using System.Threading.Tasks;

	public interface IHttpClient
	{
		// CREATE
		Task<HttpResponseMessage> PostAsync<TModel>(string path, TModel model);

		Task<TModel> PostJsonAsyncWithHead<TModel>(string path, object content);

		//READ
		Task<TModel> GetJsonAsync<TModel>(string path);

		Task<TModel> GetJsonAsyncWithHead<TModel>(string path);

		//UPDATE
		Task<HttpResponseMessage> PutAsync<TModel>(string path, TModel model);

		Task<TModel> PutJsonAsyncWithHead<TModel>(string path, object content);

		//DELETE
		Task DeleteAsync(string path);
	}
}