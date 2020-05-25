using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace CentralEvents.Web.App.Wrappers
{
	[ExcludeFromCodeCoverage]
	public class HttpClientWrapper : IHttpClient
	{
		private const string ApiUrl = "//localhost:54768/api/";
		//private const string ApiUrl = "//localhost:50319/api/";
		private HttpClient httpClient;

		public HttpClientWrapper()
		{
			this.httpClient = new HttpClient();
		}

		public async Task<TModel> GetJsonAsync<TModel>(string path)
		{
			return await this.httpClient.GetJsonAsync<TModel>(ApiUrl + path);
		}

		public async Task<TModel> PutJsonAsync<TModel>(string path, object content)
		{
			return await this.httpClient.PutJsonAsync<TModel>(path, content);
		}

		public async Task<TModel> PostJsonAsync<TModel>(string path, object content)
		{
			return await this.httpClient.PostJsonAsync<TModel>(path, content);
		}

		public async Task DeleteJsonAsync<TModel>(string path)
		{
			await this.httpClient.DeleteAsync(path);
		}

		private string GetUrl(string path)
		{
			Uri api = new Uri(ApiUrl);
			Uri uri = new Uri(api, path);

			return uri.ToString();
		}
	}
}
