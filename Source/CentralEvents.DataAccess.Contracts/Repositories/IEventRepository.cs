namespace CentralEvents.DataAccess.Contracts.Repositories
{
	using System;
	using System.Collections.Generic;

	using CentralEvents.DataAccess.Contracts.Entities;

	public interface IEventRepository
	{
		void AddEvent(EventEntity eventEntity);

		void AddBooking(BookingEntity bookingEntity);

		void AddCustomer(CustomerEntity customerModel);

		IEnumerable<EventEntity> GetEvents();

		EventEntity GetEvent(Guid id);

		void SaveChangedRepository();

		void RemoveEvent(EventEntity eventEntity);
	}
}