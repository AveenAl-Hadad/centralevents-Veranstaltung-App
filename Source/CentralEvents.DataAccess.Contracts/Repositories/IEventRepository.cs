namespace CentralEvents.DataAccess.Contracts.Repositories
{
	using System;
	using System.Collections.Generic;

	using CentralEvents.DataAccess.Contracts.Entities;

	public interface IEventRepository
	{
		IEnumerable<EventEntity> GetEvents();

		void Add(EventEntity eventEntity);

		IEnumerable<EventEntity> FetchAll();

		EventEntity Fetch(Guid id);

		void SaveChanges();

		void Remove(EventEntity eventEntity);
	}
}