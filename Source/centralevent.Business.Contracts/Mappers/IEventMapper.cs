namespace CentralEvent.Business.Contracts.Mappers
{
	using CentralEvent.Business.Contracts.Models;

	using CentralEvents.DataAccess.Contracts.Entities;

	public interface IEventMapper
	{
		EventModel EventEntityToModel(EventEntity eventEntity);

		EventEntity EventModelToEntity(EventModel eventModel);

		BookingModel BookingEntityToModel(BookingEntity bookingEntity);

		BookingEntity BookingModelToEntity(BookingModel bookingModel);
	}
}