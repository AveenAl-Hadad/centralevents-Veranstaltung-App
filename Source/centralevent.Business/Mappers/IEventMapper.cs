namespace CentralEvent.Business.Mappers
{
	using CentralEvent.Business.Contracts.Models;

	using CentralEvents.DataAccess.Contracts.Entities;

	public interface IEventMapper
	{
		EventModel Mapper(EventEntity eventEntity);
	}
}