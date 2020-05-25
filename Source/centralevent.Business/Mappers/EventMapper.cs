namespace CentralEvent.Business.Mappers
{
	using CentralEvent.Business.Contracts.Models;

	using CentralEvent.Business.Mappers;

	public class EventMapper : IEventMapper
	{
		public EventModel Mapper(EventEntity eventEntity)
		{
			EventModel eventModel = new EventModel
									{
										Id = eventEntity.Id,
										Name = eventEntity.Name,
										Strasse = eventEntity.Strasse,
										PlzOrt = eventEntity.PlzOrt,
										Datum = eventEntity.Datum,
										BeginnUhrzeit = eventEntity.BeginnUhrzeit,
										EndeUhrzeit = eventEntity.EndUhrzeit,
										Eintritt = eventEntity.Eintritt,
										Beschreibung = eventEntity.Beschreibung,
										Rubrik = eventEntity.Rubrik,
										GesamtanzahlEintrittskarten = eventEntity.GesamtanzahlEintrittskarten
									};
			return eventModel;
		}
	}
}