namespace CentralEvent.Business.Contracts.Models
{
	using System;
	using System.Text.Json.Serialization;

	public class CustomerModel
	{
		[JsonPropertyName("id")]
		public Guid Id { get; set; }

		//[Display(Name = "Vorname")]
		[JsonPropertyName("Vorname")]
		public string Vorname { get; set; }

		//[Display(Name = "Nachname")]
		[JsonPropertyName("Nachname")]
		public string Nachname { get; set; }

		//[Display(Name = "Strasse")]
		[JsonPropertyName("Strasse")]
		public string Strasse { get; set; }

		//[Display(Name = "Hausnummer")]
		[JsonPropertyName("Hausnummer")]
		public string Hausnummer { get; set; }

		//[Display(Name = "Plz")]
		[JsonPropertyName("Plz")]
		public string Plz { get; set; }

		//[Display(Name = "Ort")]
		[JsonPropertyName("Ort")]
		public string Ort { get; set; }

		//[Display(Name = "Telefon")]
		[JsonPropertyName("Telefon")]
		public string Telefon { get; set; }

		//[Display(Name = "Email")]
		//[Required(ErrorMessage = "Bitte geben Sie eine gültige E-Mail Adresse ein")]
		[JsonPropertyName("Email")]
		public string Email { get; set; }

		//[Display(Name = "Benutzername")]
		//[Required(ErrorMessage = "Bitte geben Sie einen Benutzernamen an")]
		[JsonPropertyName("Benutzername")]
		public string Benutzername { get; set; }

		//[Display(Name = "Passwort")]
		[JsonPropertyName("Passwort")]
		public string Passwort { get; set; } = "";
	}
}