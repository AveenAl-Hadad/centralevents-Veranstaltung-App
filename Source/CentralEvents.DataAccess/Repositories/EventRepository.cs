namespace CentralEvents.DataAccess.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvents.DataAccess.Contracts.Context;
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
		public void AddEvent(EventEntity eventEntity)
		{
			this.dataContext.Add(eventEntity);
			this.dataContext.SaveChangedRepository();
		}

		public void AddBooking(BookingModel bookingModel)
		{
			this.dataContext.Add(bookingModel);
			this.dataContext.SaveChangedRepository();
		}

		//READ
		public IEnumerable<EventEntity> GetEvents()
		{
			return this.dataContext.Query<EventEntity>().ToArray();
		}

		public EventEntity GetEvent(Guid id)
		{
			EventEntity eventEntity = this.dataContext.Query<EventEntity>().FirstOrDefault(e => e.Id == id);

			if (eventEntity == null)
			{
				throw new EntityNotFoundException(typeof(EventEntity), id);
			}

			return eventEntity;
		}

		//UPDATE
		public void SaveChangedRepository()
		{
			this.dataContext.SaveChangedRepository();
		}

		// REMOVE
		public void RemoveEvent(EventEntity eventEntity)
		{
			this.dataContext.Remove(eventEntity);
		}
	}
}