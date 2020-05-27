namespace CentralEvents.Web.App.Wrappers
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.Net.Http;
	using System.Text;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Components;

	using Newtonsoft.Json;

	[ExcludeFromCodeCoverage]
	public class HttpClientWrapper : IHttpClient
	{
		private static string ApiUrl = "http://localhost:54768/";

		//private const string ApiUrl = "//localhost:50319/";
		private HttpClient httpClient;

		public HttpClientWrapper()
		{
			this.httpClient = new HttpClient();
		}
		// CRUD:

		// CREATE
		public async Task<HttpResponseMessage> PostAsync<TModel>(string path, TModel model)
		{
			return await this.httpClient.PostAsync(this.GetUrl(path), this.JsonToStringContent(model));
		}

		//READ
		public async Task<TModel> GetJsonAsync<TModel>(string path)
		{
			return await this.httpClient.GetJsonAsync<TModel>(this.GetUrl(path));
		}

		//UPDATE
		public async Task<HttpResponseMessage> PutAsync<TModel>(string path, TModel model)
		{
			return await this.httpClient.PutAsync(this.GetUrl(path), this.JsonToStringContent(model));
		}

		//DELETE
		public async Task DeleteAsync(string path)
		{
			await this.httpClient.DeleteAsync(this.GetUrl(path));
		}

		//Hilfsmethoden
		private string GetUrl(string path)
		{
			Uri api = new Uri(ApiUrl);
			Uri uri = new Uri(api, path);
			return uri.ToString();
		}

		private StringContent JsonToStringContent(object content)
		{
			string serializedBody = JsonConvert.SerializeObject(content);
			StringContent stringContent = new StringContent(serializedBody, Encoding.UTF8, "application/json");
			//StringContent stringContent = new StringContent(serializedBody);
			//stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
			return stringContent;
		}
	}
}