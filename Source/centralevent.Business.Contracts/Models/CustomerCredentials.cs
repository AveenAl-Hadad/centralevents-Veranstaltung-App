namespace CentralEvent.Business.Contracts.Models
{
	using System.Text.Json.Serialization;

	public class CustomerCredentials
	{
		[JsonPropertyName("Benutzername")]
		public string Benutzername { get; set; }

		[JsonPropertyName("Passwort")]
		public string Passwort { get; set; } = "";
	}
}