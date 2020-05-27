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
										Name = eventEntity.Name
										/*Strasse = eventEntity.Strasse,
				PlzOrt = eventEntity.PlzOrt,
				Datum = eventEntity.Datum,
				BeginnUhrzeit = eventEntity.BeginnUhrzeit,
				EndeUhrzeit = eventEntity.EndeUhrzeit,
				Eintritt = eventEntity.Eintritt,
				Beschreibung = eventEntity.Beschreibung,
				Rubrik = eventEntity.Rubrik,
				GesamtanzahlEintrittskarten = eventEntity.GesamtanzahlEintrittskarten*/
									};
			return eventModel;
		}

		public EventEntity EventModelToEntity(EventModel eventModel)
		{
			EventEntity eventEntity = new EventEntity
									  {
										  Name = eventModel.Name
									  };
			return eventEntity;
		}
	}
}