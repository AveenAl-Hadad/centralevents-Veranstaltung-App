namespace CentralEvent.Business.Contracts.Models
{
	using Newtonsoft.Json;

	public class SecurityModel
	{
		[JsonProperty("IsAuthorized")]
		public bool IsAuthorized { get; set; }

		[JsonProperty("Benutzername")]
		public string Benutzername { get; set; }
	}
}