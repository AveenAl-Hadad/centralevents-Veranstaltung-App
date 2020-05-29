namespace CentralEvent.Business.Contracts.Models
{
	using System;
	using System.Text.Json.Serialization;

	public class BookingModel
	{
		[JsonPropertyName("id")]
		public Guid Id { get; set; }

		[JsonPropertyName("Eventname")]
		public string EventName { get; set; }

		[JsonPropertyName("AnzahlTickets")]
		public int AnzahlTickets { get; set; }

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
	}
}