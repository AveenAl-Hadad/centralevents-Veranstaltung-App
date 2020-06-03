namespace CentralEvent.Business.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvent.Business.Contracts.Mappers;
	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	using CentralEvents.DataAccess.Contracts.Entities;
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
			EventEntity eventEntity = new EventEntity();
			this.eventRepository.AddEvent(this.eventMapper.EventModelToEntity(eventEntity, eventModel));
			this.eventRepository.SaveChangedRepository();
		}

		public void AddBooking(BookingModel bookingModel)
		{
			BookingEntity bookingEntity = new BookingEntity();
			this.eventRepository.AddBooking(this.eventMapper.BookingModelToEntity(bookingModel, bookingEntity));
			this.eventRepository.SaveChangedRepository();
		}

		public void AddCustomer(CustomerModel customerModel)
		{
			CustomerEntity customerEntity = new CustomerEntity();
			this.eventRepository.AddCustomer(this.eventMapper.CustomerModelToEntity(customerModel, customerEntity));
			this.eventRepository.SaveChangedRepository();
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
			EventEntity eventEntity = this.eventRepository.GetEvent(eventModel.Id);
			eventEntity = this.eventMapper.EventModelToEntity(eventEntity, eventModel);
			this.eventRepository.SaveChangedRepository();
		}

		public void RemoveEvent(EventModel eventModel)
		{
			throw new NotImplementedException();
		}
	}
}