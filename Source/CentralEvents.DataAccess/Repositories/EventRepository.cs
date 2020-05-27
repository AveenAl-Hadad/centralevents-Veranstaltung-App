namespace CentralEvents.DataAccess.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvents.DataAccess.Context;
	using CentralEvents.DataAccess.Contracts.Entities;
	using CentralEvents.DataAccess.Contracts.Exeptions;
	using CentralEvents.DataAccess.Contracts.Repositories;

	public class EventRepository : IEventRepository
	{
		private readonly IDataContext dataContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventRepository"/> class.
		/// </summary>
		public EventRepository(IDataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		//CRUD

		//CREATE
		public void Add(EventEntity eventEntity)
		{
			this.dataContext.Add(eventEntity);
			this.dataContext.SaveChanges();
		}

		//READ
		public IEnumerable<EventEntity> FetchAll()
		{
			EventEntity[] eventEntities = this.dataContext.Query<EventEntity>().ToArray();
			return eventEntities;
		}

		public EventEntity Fetch(Guid id)
		{
			EventEntity eventEntity = this.dataContext.Query<EventEntity>().FirstOrDefault(e => e.Id == id);

			if (eventEntity == null)
			{
				throw new EntityNotFoundException(typeof(EventEntity), id);
			}

			return eventEntity;
		}

		//UPDATE
		public void SaveChanges()
		{
			this.dataContext.SaveChanges();
		}

		// REMOVE
		public void Remove(EventEntity eventEntity)
		{
			this.dataContext.Remove(eventEntity);
		}

		public IEnumerable<EventEntity> GetEvents()
		{
			return this.dataContext.Query<EventEntity>().ToArray();
		}
	}
}