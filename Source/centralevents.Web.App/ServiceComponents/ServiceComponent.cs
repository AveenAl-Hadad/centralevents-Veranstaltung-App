namespace CentralEvents.Web.App.ServiceComponents
{
	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Threading.Tasks;

	using CentralEvents.Web.App.Serializers;
	using CentralEvents.Web.App.Wrappers;

	using RestSharp;

	public class ServiceComponent : IServiceComponent
	{
		private IHttpClient httpClient = new HttpClientWrapper();

		public async Task<IRestResponse> ResponseJsonOrig(string url, object requestBody, Dictionary<string, string> requestHeader, List<Parameter> requestParameter, Method method)
		{
			Uri uri = new Uri(url);
			url = uri.ToString();

			RestClient client = new RestClient(url);
			RestRequest request = new RestRequest
								  {
									  RequestFormat = DataFormat.Json,

									  JsonSerializer = new CamelCaseSerializer()
								  };

			//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

			if (requestHeader != null)
			{
				foreach (KeyValuePair<string, string> item in requestHeader)
				{
					request.AddHeader(item.Key, item.Value);
					//request.Headers.Add(item.Key, item.Value);
					//request.Properties.Add(item.Key, item.Value);
				}
			}

			if (requestParameter != null)
			{
				foreach (Parameter item in requestParameter)
				{
					request.AddParameter(item);
				}
			}

			if (requestBody != null)
			{
				request.AddJsonBody(requestBody);
			}

			IRestResponse response = client.Execute(request);
			//var response =await this.httpClient.SendAsync(request);

			return response;
		}

		public async Task<HttpResponseMessage> ResponseJson(string url, object requestBody, Dictionary<string, string> requestHeader, List<Parameter> requestParameter, Method method)
		{
			Uri uri = new Uri(url);
			url = uri.ToString();

			//RestClient client = new RestClient(url);
			//RestRequest request = new RestRequest
			//					  {
			//						  RequestFormat = DataFormat.Json,

			//						  JsonSerializer = new CamelCaseSerializer()
			//					  };

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

			if (requestHeader != null)
			{
				foreach (KeyValuePair<string, string> item in requestHeader)
				{
					//request.AddHeader(item.Key, item.Value);
					request.Headers.Add(item.Key, item.Value);
					request.Properties.Add(item.Key, item.Value);
				}
			}

			if (requestParameter != null)
			{
				foreach (Parameter item in requestParameter)
				{
					//request.AddParameter(item);
				}
			}

			if (requestBody != null)
			{
				//request.AddJsonBody(requestBody);
				//request.Content = requestBody;
			}

			//IRestResponse response = client.Execute(request);
			HttpResponseMessage response = await this.httpClient.SendAsync(request);

			return response;
		}

		// Vielleicht
		//private string GetUrl(string path)
		//{
		//	Uri api = new Uri(ApiUrl);
		//	Uri uri = new Uri(api, path);
		//	return uri.ToString();
		//}

		public async Task<HttpResponseMessage> ResponseJsonAuth(string url, object requestBody, Dictionary<string, string> requestHeader, Method method)
		{
			Uri uri = new Uri(url);
			url = uri.ToString();

			//RestClient client = new RestClient(url);
			//RestRequest request = new RestRequest
			//					  {
			//						  RequestFormat = DataFormat.Json,

			//						  JsonSerializer = new CamelCaseSerializer()
			//					  };

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

			if (requestHeader != null)
			{
				foreach (KeyValuePair<string, string> item in requestHeader)
				{
					//request.AddHeader(item.Key, item.Value);
					//request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
					request.Headers.Add(item.Key, item.Value);
					request.Properties.Add(item.Key, item.Value);
				}
			}

			if (requestBody != null)
			{
				//request.AddJsonBody(requestBody);
			}

			HttpResponseMessage response = await this.httpClient.SendAsync(request);

			//IRestResponse response = client.Execute(request);

			return response;
		}
	}
}