namespace CentralEvents.DataAccess.Contracts.Entities
{
	using System;

	public class EventEntity
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Strasse { get; set; }

		public string PlzOrt { get; set; }

		public string Datum { get; set; }

		public string BeginnUhrzeit { get; set; }

		public string EndeUhrzeit { get; set; }

		public double Eintritt { get; set; }

		public string Beschreibung { get; set; }

		public string Rubrik { get; set; }

		public string GesamtanzahlEintrittskarten { get; set; }
	}
}