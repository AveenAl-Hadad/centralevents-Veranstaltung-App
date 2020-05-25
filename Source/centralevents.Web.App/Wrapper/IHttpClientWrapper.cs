using System.Threading.Tasks;

namespace CentralEvents.Web.App.Wrappers
{
	public interface IHttpClient
	{
		Task<TModel> GetJsonAsync<TModel>(string path);
		Task<TModel> PutJsonAsync<TModel>(string path, object content);
		Task<TModel> PostJsonAsync<TModel>(string path, object content);
		Task DeleteJsonAsync<TModel>(string path);
	}
}