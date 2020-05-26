namespace CentralEvents.DataAccess.Repository
{
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvent.Business.Contracts.Models;

	using CentralEvents.DataAccess.Context;
	using CentralEvents.DataAccess.Contracts.Entities;
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

		public IEnumerable<EventEntity> GetEvents()
		{
			return this.dataContext.Query<EventEntity>().ToArray();
		}
	}
}