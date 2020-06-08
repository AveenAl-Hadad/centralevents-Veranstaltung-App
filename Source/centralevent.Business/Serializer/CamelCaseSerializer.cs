namespace CentralEvent.Business.Serializer
{
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;

	using RestSharp.Serializers;

	public class CamelCaseSerializer : ISerializer
	{
		public string ContentType { get; set; }

		public CamelCaseSerializer()
		{
			this.ContentType = "application/json";
		}

		public string Serialize(object obj)
		{
			JsonSerializerSettings camelCaseSetting = new JsonSerializerSettings
													  {
														  ContractResolver = new CamelCasePropertyNamesContractResolver()
													  };

			string json = JsonConvert.SerializeObject(obj, camelCaseSetting);
			return json;
		}
	}
}