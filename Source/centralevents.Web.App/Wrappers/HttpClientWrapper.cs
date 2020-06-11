namespace CentralEvents.Web.App.Wrappers
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Text;
	using System.Threading.Tasks;

	using Blazored.LocalStorage;

	using Microsoft.AspNetCore.Components;

	using Newtonsoft.Json;

	[ExcludeFromCodeCoverage]
	public class HttpClientWrapper : IHttpClient
	{
		private static string apiUrl = "http://localhost:54768/";
		private readonly ILocalStorageService localStorage;

		private HttpClient httpClient;

		public HttpClientWrapper(ILocalStorageService localStorage)
		{
			this.httpClient = new HttpClient();
			this.localStorage = localStorage;
		}
		// CRUD:

		// CREATE
		public async Task<HttpResponseMessage> PostAsync<TModel>(string path, TModel model)
		{
			return await this.httpClient.PostAsync(this.GetUrl(path), this.JsonToStringContent(model));
		}

		public async Task<TModel> PostJsonAsyncWithHead<TModel>(string path, object content)
		{
			await this.SetHeader();
			return await this.httpClient.PostJsonAsync<TModel>(this.GetUrl(path), content);
		}

		//READ
		public async Task<TModel> GetJsonAsync<TModel>(string path)
		{
			return await this.httpClient.GetJsonAsync<TModel>(this.GetUrl(path));
		}

		public async Task<TModel> GetJsonAsyncWithHead<TModel>(string path)
		{
			await this.SetHeader();
			return await this.httpClient.GetJsonAsync<TModel>(this.GetUrl(path));
		}

		//UPDATE
		public async Task<HttpResponseMessage> PutAsync<TModel>(string path, TModel model)
		{
			return await this.httpClient.PutAsync(this.GetUrl(path), this.JsonToStringContent(model));
		}

		public async Task<TModel> PutJsonAsyncWithHead<TModel>(string path, object content)
		{
			await this.SetHeader();
			return await this.httpClient.PutJsonAsync<TModel>(this.GetUrl(path), content);
		}

		//DELETE
		public async Task DeleteAsync(string path)
		{
			await this.httpClient.DeleteAsync(this.GetUrl(path));
		}

		//Hilfsmethoden
		private string GetUrl(string path)
		{
			Uri api = new Uri(apiUrl);
			Uri uri = new Uri(api, path);
			return uri.ToString();
		}

		private StringContent JsonToStringContent(object content)
		{
			string serializedBody = JsonConvert.SerializeObject(content);
			StringContent stringContent = new StringContent(serializedBody, Encoding.UTF8, "application/json");
			return stringContent;
		}

		private async Task SetHeader()
		{
			if (await this.localStorage.ContainKeyAsync("jwt"))
			{
				string token = await this.localStorage.GetItemAsync<string>("jwt");

				this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			}
		}
	}
}