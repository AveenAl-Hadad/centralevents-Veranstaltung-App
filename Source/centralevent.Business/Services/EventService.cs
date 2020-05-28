namespace CentralEvent.Business.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvent.Business.Contracts.Mappers;
	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	using CentralEvents.DataAccess.Contracts.Repositories;

	public class EventService : IEventService
	{
		private readonly IEventMapper eventMapper;
		private readonly IEventRepository eventRepository;

		public EventService(IEventRepository eventRepository, IEventMapper eventMapper)
		{
			this.eventRepository = eventRepository;
			this.eventMapper = eventMapper;
		}

		public void AddEvent(EventModel eventModel)
		{
			this.eventRepository.AddEvent(this.eventMapper.EventModelToEntity(eventModel));
		}

		public void AddBooking(BookingModel bookingModel)
		{
			this.eventRepository.AddBooking(this.eventMapper.BookingModelToEntity(bookingModel));
		}

		public IEnumerable<EventModel> GetEventS()
		{
			return this.eventRepository.GetEvents().Select(this.eventMapper.EventEntityToModel);
		}

		public EventModel GetEvent(Guid id)
		{
			return this.eventMapper.EventEntityToModel(this.eventRepository.GetEvent(id));
		}

		public void UpdateEvent(EventModel eventModel)
		{
			throw new NotImplementedException();
		}

		public void RemoveEvent(EventModel eventModel)
		{
			throw new NotImplementedException();
		}
	}
}