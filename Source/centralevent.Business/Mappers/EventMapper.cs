namespace CentralEvent.Business.Mappers
{
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvent.Business.Contracts.Mappers;
	using CentralEvent.Business.Contracts.Models;

	using CentralEvents.DataAccess.Contracts.Entities;

	public class EventMapper : IEventMapper
	{
		public EventModel EventEntityToModel(EventEntity eventEntity)
		{
			EventModel eventModel = new EventModel
									{
										Id = eventEntity.Id,
										Name = eventEntity.Name,
										Ort = eventEntity.Ort,
										Datum = eventEntity.Datum,
										BeginnUhrzeit = eventEntity.BeginnUhrzeit,
										EndeUhrzeit = eventEntity.EndeUhrzeit,
										Eintritt = eventEntity.Eintritt,
										Beschreibung = eventEntity.Beschreibung,
										GesamtanzahlEintrittskarten = eventEntity.GesamtanzahlEintrittskarten,
										Restbestand = eventEntity.Restbestand
									};
			return eventModel;
		}

		public IEnumerable<EventModel> EventEntitiesToModelList(IEnumerable<EventEntity> eventEntities)
		{
			//IList<EventModel> eventModels = new List<EventModel>();
			//IEnumerable<EventModel> eventS = new EventModel[0];
			//foreach (EventEntity eventEntity in eventEntities)
			//{
			//	eventS = eventS.Append(this.EventEntityToModel(eventEntity));
			//}
			//return eventS;

			return eventEntities.Select(this.EventEntityToModel).ToList();
		}

		public EventEntity EventModelToEntity(EventEntity eventEntity, EventModel eventModel)
		{
			eventEntity.Name = eventModel.Name;
			eventEntity.Ort = eventModel.Ort;
			eventEntity.Datum = eventModel.Datum;
			eventEntity.BeginnUhrzeit = eventModel.BeginnUhrzeit;
			eventEntity.EndeUhrzeit = eventModel.EndeUhrzeit;
			eventEntity.Eintritt = eventModel.Eintritt;
			eventEntity.Beschreibung = eventModel.Beschreibung;
			eventEntity.GesamtanzahlEintrittskarten = eventModel.GesamtanzahlEintrittskarten;
			eventEntity.Restbestand = eventModel.Restbestand;

			return eventEntity;
		}

		public BookingModel BookingEntityToModel(BookingEntity bookingEntity)
		{
			BookingModel bookingModel = new BookingModel
										{
											Id = bookingEntity.Id,
											EventName = bookingEntity.EventName,
											AnzahlTickets = bookingEntity.AnzahlTickets,
											Vorname = bookingEntity.Vorname,
											Nachname = bookingEntity.Nachname,
											Strasse = bookingEntity.Strasse,
											Hausnummer = bookingEntity.Hausnummer,
											Plz = bookingEntity.Plz,
											Ort = bookingEntity.Ort,
											Telefon = bookingEntity.Telefon,
											Email = bookingEntity.Email
										};
			return bookingModel;
		}

		public BookingEntity BookingModelToEntity(BookingModel bookingModel, BookingEntity bookingEntity)
		{
			bookingEntity.EventName = bookingModel.EventName;
			bookingEntity.AnzahlTickets = bookingModel.AnzahlTickets;
			bookingEntity.Vorname = bookingModel.Vorname;
			bookingEntity.Nachname = bookingModel.Nachname;
			bookingEntity.Strasse = bookingModel.Strasse;
			bookingEntity.Hausnummer = bookingModel.Hausnummer;
			bookingEntity.Plz = bookingModel.Plz;
			bookingEntity.Ort = bookingModel.Ort;
			bookingEntity.Telefon = bookingModel.Telefon;
			bookingEntity.Email = bookingModel.Email;

			return bookingEntity;
		}

		public CustomerModel CustomerEntityToModel(CustomerEntity customerEntity)
		{
			CustomerModel customerModel = new CustomerModel
										  {
											  Id = customerEntity.Id,
											  Vorname = customerEntity.Vorname,
											  Nachname = customerEntity.Nachname,
											  Strasse = customerEntity.Strasse,
											  Hausnummer = customerEntity.Hausnummer,
											  Plz = customerEntity.Plz,
											  Ort = customerEntity.Ort,
											  Telefon = customerEntity.Telefon,
											  Email = customerEntity.Email,
											  Passwort = customerEntity.Passwort,
											  Benutzername = customerEntity.Benutzername,
											  Rolle = customerEntity.Rolle
										  }
				;
			return customerModel;
		}

		public CustomerEntity CustomerModelToEntity(CustomerModel customerModel, CustomerEntity customerEntity)
		{
			customerEntity.Vorname = customerModel.Vorname;
			customerEntity.Nachname = customerModel.Nachname;
			customerEntity.Strasse = customerModel.Strasse;
			customerEntity.Hausnummer = customerModel.Hausnummer;
			customerEntity.Plz = customerModel.Plz;
			customerEntity.Ort = customerModel.Ort;
			customerEntity.Telefon = customerModel.Telefon;
			customerEntity.Email = customerModel.Email;
			customerEntity.Passwort = customerModel.Passwort;
			customerEntity.Benutzername = customerModel.Benutzername;
			customerEntity.Rolle = customerModel.Rolle;

			return customerEntity;
		}
	}
}