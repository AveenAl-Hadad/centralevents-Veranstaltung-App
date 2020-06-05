namespace CentralEvents.Web.App.ServiceComponents
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using RestSharp;

	public interface IServiceComponent
	{
		Task<IRestResponse> ResponseJson(string url, object requestBody, Dictionary<string, string> requestHeader, List<Parameter> requestParameter, Method method);

		Task<IRestResponse> ResponseJsonAuth(string url, object requestBody, Dictionary<string, string> requestHeader, Method method);
	}
}