namespace CentralEvent.Business.Contracts.Mappers
{
	using CentralEvent.Business.Contracts.Models;

	using CentralEvents.DataAccess.Contracts.Entities;

	public interface IEventMapper
	{
		EventModel EventEntityToModel(EventEntity eventEntity);

		EventEntity EventModelToEntity(EventEntity eventEntity, EventModel eventModel);

		BookingModel BookingEntityToModel(BookingEntity bookingEntity);

		BookingEntity BookingModelToEntity(BookingModel bookingModel, BookingEntity bookingEntity);

		CustomerModel CustomerEntityToModel(CustomerEntity customerEntity);

		CustomerEntity CustomerModelToEntity(CustomerModel customerModel, CustomerEntity customerEntity);
	}
}