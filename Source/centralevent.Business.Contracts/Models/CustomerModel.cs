namespace CentralEvent.Business.Contracts.Models
{
	using System;
	using System.Text.Json.Serialization;

	public class CustomerModel
	{
		[JsonPropertyName("id")]
		public Guid Id { get; set; }

		[JsonPropertyName("Vorname")]
		public string Vorname { get; set; }

		[JsonPropertyName("Nachname")]
		public string Nachname { get; set; }

		[JsonPropertyName("Strasse")]
		public string Strasse { get; set; }

		[JsonPropertyName("Hausnummer")]
		public string Hausnummer { get; set; }

		[JsonPropertyName("Plz")]
		public string Plz { get; set; }

		[JsonPropertyName("Ort")]
		public string Ort { get; set; }

		[JsonPropertyName("Telefon")]
		public string Telefon { get; set; }

		[JsonPropertyName("Email")]
		public string Email { get; set; }

		[JsonPropertyName("Benutzername")]
		public string Benutzername { get; set; }

		[JsonPropertyName("Passwort")]
		public string Passwort { get; set; }
	}
}