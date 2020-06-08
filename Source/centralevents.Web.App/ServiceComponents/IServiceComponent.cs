namespace CentralEvents.Web.App.ServiceComponents
{
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Threading.Tasks;

	using RestSharp;

	public interface IServiceComponent
	{
		Task<HttpResponseMessage> ResponseJson(string url, object requestBody, Dictionary<string, string> requestHeader, List<Parameter> requestParameter, Method method);

		Task<HttpResponseMessage> ResponseJsonAuth(string url, object requestBody, Dictionary<string, string> requestHeader, Method method);

		Task<IRestResponse> ResponseJsonOrig(string url, object requestBody, Dictionary<string, string> requestHeader, List<Parameter> requestParameter, Method method);

	}
}