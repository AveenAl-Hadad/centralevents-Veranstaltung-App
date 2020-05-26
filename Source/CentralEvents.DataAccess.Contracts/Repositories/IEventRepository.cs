namespace CentralEvents.DataAccess.Contracts.Repositories
{
	using System.Collections.Generic;

	using CentralEvent.Business.Contracts.Models;

	using CentralEvents.DataAccess.Contracts.Entities;

	public interface IEventRepository
	{
		IEnumerable<EventEntity> GetEvents();
	}
}