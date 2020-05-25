namespace CentralEvent.Business.Services
{
	using System.Collections.Generic;
	using System;

	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;
	using CentralEvent.Business.Mappers;

	public class EventService : IEventService
	{
		private readonly IEventMapper eventMapper;
		private readonly IEventRepository eventRepository;
		public IEnumerable<EventModel> GetEvents()
		{
			IEnumerable<EventEntity> eventEntity = this.eventRepository.FetchAll();
			EventModel[] eventModels = eventEntity.Select(this.eventMapper.Mapper).ToArray();
			return eventModels;

		}

		public EventModel GetEvent(Guid id)
		{
			EventEntity eventEntity = this.eventRepository.Fetch(id);
			EventModel eventModel = this.eventMapper.Mapper(eventEntity);
			return eventModel;
		}
	}

}