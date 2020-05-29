namespace CentralEvents.DataAccess.Contracts.Entities
{
	using System;

	public class BookingEntity : EntityBase
	{
		public BookingEntity()
		{
			this.Id = Guid.NewGuid();
		}
		public string EventName { get; set; }

		public int AnzahlTickets { get; set; }

		public string Vorname { get; set; }

		public string Nachname { get; set; }

		public string Strasse { get; set; }

		public string Hausnummer { get; set; }

		public string Plz { get; set; }

		public string Ort { get; set; }

		public string Telefon { get; set; }

		public string Email { get; set; }
	}
}