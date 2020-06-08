namespace CentralEvent.Business.Services
{
	using System;
	using System.Collections.Generic;

	using CentralEvent.Business.Contracts.Services;
	using CentralEvent.Business.Serializer;

	using RestSharp;

	public class SecurityService : ISecurityService
	{
		public IRestResponse ResponseJson(string url, object requestBody, Dictionary<string, string> requestHeader, List<Parameter> requestParameter, Method method)
		{
			Uri uri = new Uri(url);
			url = uri.ToString();

			RestClient client = new RestClient(url);
			RestRequest request = new RestRequest
								  {
									  RequestFormat = DataFormat.Json,

									  JsonSerializer = new CamelCaseSerializer()
								  };

			if (requestHeader != null)
			{
				foreach (KeyValuePair<string, string> item in requestHeader)
				{
					request.AddHeader(item.Key, item.Value);
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

			return response;
		}

		// Vielleicht
		//private string GetUrl(string path)
		//{
		//	Uri api = new Uri(ApiUrl);
		//	Uri uri = new Uri(api, path);
		//	return uri.ToString();
		//}

		public IRestResponse ResponseJsonAuth(string url, object requestBody, Dictionary<string, string> requestHeader, List<Parameter> requestParameter, Method method)
		{
			Uri uri = new Uri(url);
			url = uri.ToString();

			RestClient client = new RestClient(url);
			RestRequest request = new RestRequest
								  {
									  RequestFormat = DataFormat.Json,

									  JsonSerializer = new CamelCaseSerializer()
								  };

			if (requestHeader != null)
			{
				foreach (KeyValuePair<string, string> item in requestHeader)
				{
					request.AddHeader(item.Key, item.Value);
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

			// api aufruf -- umdrehen
			IRestResponse response = client.Execute(request);

			return response;
		}
	}
}