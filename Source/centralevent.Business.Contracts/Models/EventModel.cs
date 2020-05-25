namespace CentralEvent.Business.Contracts.Models
{
	using System.Text.Json.Serialization;

	public class EventModel
	{
		    [JsonPropertyName("id")]
		    public System.Guid Id { get; set; }

		    [JsonPropertyName("Name")]
			public string Name { get; set; }

			[JsonPropertyName("Strasse")]
			public string Strasse { get; set; }
			
			[JsonPropertyName("PlzOrt")]
			public string PlzOrt { get; set; }

			[JsonPropertyName("Datum")]
			public string Datum { get; set; }

			[JsonPropertyName("BeginnUhrzeit")]
			public string BeginnUhrzeit { get; set; }
			
			[JsonPropertyName("EndeUhrzeit")] 
			public string EndeUhrzeit { get; set; }

			[JsonPropertyName("Eintritt")]
			public double Eintritt { get; set; }
			
			[JsonPropertyName("Beschreibung")]
			public string Beschreibung { get; set; }

			[JsonPropertyName("Rubrik")]
			public string Rubrik { get; set; }

		[JsonPropertyName("Strasse")]

		public string GesamtanzahlEintrittskarten { get; set; }
		
		}
	}
