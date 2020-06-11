namespace CentralEvents.DataAccess.Contracts.Entities
{
	using System;

	public class CustomerEntity : EntityBase
	{
		public CustomerEntity()
		{
			this.Id = Guid.NewGuid();
		}

		public string Vorname { get; set; }

		public string Nachname { get; set; }

		public string Strasse { get; set; }

		public string Hausnummer { get; set; }

		public string Plz { get; set; }

		public string Ort { get; set; }

		public string Telefon { get; set; }

		public string Email { get; set; }

		public string Benutzername { get; set; }

		public string Passwort { get; set; }
	}
}