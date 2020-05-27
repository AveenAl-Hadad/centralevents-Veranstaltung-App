namespace CentralEvent.Business.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;
	using CentralEvent.Business.Mappers;

	using CentralEvents.DataAccess.Contracts.Entities;
	using CentralEvents.DataAccess.Contracts.Repositories;

	public class EventService : IEventService
	{
		private readonly IEventMapper eventMapper;
		private readonly IEventRepository eventRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventService"/> class.
		/// </summary>
		public EventService(IEventRepository eventRepository, IEventMapper eventMapper)
		{
			this.eventRepository = eventRepository;
			this.eventMapper = eventMapper;
		}

		// public IEnumerable<EventModel> GetEvents()
		// {
		// 	IEnumerable<EventEntity> eventEntity = this.eventRepository.FetchAll();
		// 	EventModel[] eventModels = eventEntity.Select(this.eventMapper.EventEntityToModel).ToArray();
		// 	return eventModels;
		// }

		public EventModel GetEvent(Guid id)
		{
			EventEntity eventEntity = this.eventRepository.Fetch(id);
			EventModel eventModel = this.eventMapper.EventEntityToModel(eventEntity);
			return eventModel;
		}

		public void UpdateEventModel(EventModel eventModel)
		{
			throw new NotImplementedException();
		}

		public void AddEventModel(EventModel eventModel)
		{
			eventRepository.Add(this.eventMapper.EventModelToEntity(eventModel));
		}

		public void RemoveEventModel(EventModel eventModel)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EventModel> GetEventS()
		{
			// IEnumerable<EventEntity> eventS = this.eventRepository.GetEvents();
			//
			// return this.eventMapper.EventEntityToModel.(this.eventRepository.GetEvents());
			return this.eventRepository.GetEvents().Select(this.eventMapper.EventEntityToModel);
		}
	}
}