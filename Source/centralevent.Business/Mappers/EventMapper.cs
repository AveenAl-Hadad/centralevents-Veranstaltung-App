namespace CentralEvent.Business.Mappers
{
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
										GesamtanzahlEintrittkarten = eventEntity.GesamtanzahlEintrittskarten,
										Restbestand =eventEntity.Restbestand


				/*Strasse = eventEntity.Strasse,
PlzOrt = eventEntity.PlzOrt,


Rubrik = eventEntity.Rubrik,*/

			};
			return eventModel;
		}

		public EventEntity EventModelToEntity(EventModel eventModel)
		{
			EventEntity eventEntity = new EventEntity
									  {
										  Name = eventModel.Name,
										  Ort = eventModel.Ort,
										  Datum = eventModel.Datum,
										  BeginnUhrzeit = eventModel.BeginnUhrzeit,
										  EndeUhrzeit = eventModel.EndeUhrzeit,
										  Eintritt = eventModel.Eintritt,
										  Beschreibung = eventModel.Beschreibung,
										  GesamtanzahlEintrittskarten = eventModel.GesamtanzahlEintrittkarten,
										  Restbestand = eventModel.Restbestand

			};
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

		public BookingEntity BookingModelToEntity(BookingModel bookingModel)
		{
			BookingEntity bookingEntity = new BookingEntity
										  {
											  EventName = bookingModel.EventName,
											  AnzahlTickets = bookingModel.AnzahlTickets,
											  Vorname = bookingModel.Vorname,
											  Nachname = bookingModel.Nachname,
											  Strasse = bookingModel.Strasse,
											  Hausnummer = bookingModel.Hausnummer,
											  Plz = bookingModel.Plz,
											  Ort = bookingModel.Ort,
											  Telefon = bookingModel.Telefon,
											  Email = bookingModel.Email
										  };
			return bookingEntity;
		}
	}
}