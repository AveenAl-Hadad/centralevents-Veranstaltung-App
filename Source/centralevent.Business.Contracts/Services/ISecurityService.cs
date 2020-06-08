using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralEvent.Business.Contracts.Services
{
	public interface ISecurityService
	{
		IRestResponse ResponseJson(string url, object requestBody, Dictionary<string, string> requestHeader, List<Parameter> requestParameter, Method method);

		IRestResponse ResponseJsonAuth(string url, object requestBody, Dictionary<string, string> requestHeader, List<Parameter> requestParameter, Method method);
	}
}
