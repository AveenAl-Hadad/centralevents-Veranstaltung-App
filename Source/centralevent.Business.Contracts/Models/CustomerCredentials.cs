namespace CentralEvent.Business.Contracts.Models
{
	using System.Text.Json.Serialization;

	public class CustomerCredentials
	{
		[JsonPropertyName("username")]
		public string Username { get; set; }

		[JsonPropertyName("Benutzername")]
		public string Benutzername { get; set; }

		[JsonPropertyName("Passwort")]
		public string Passwort { get; set; } = "";
	}
}