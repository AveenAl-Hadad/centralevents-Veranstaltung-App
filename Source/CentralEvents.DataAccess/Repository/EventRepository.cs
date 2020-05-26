namespace CentralEvents.DataAccess.Repository
{
	using CentralEvents.DataAccess.Context;
	using CentralEvents.DataAccess.Contracts.Repositories;

	public class EventRepository: IEventRepository
	{
		private readonly IDataContext dataContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventRepository"/> class.
		/// </summary>
		public EventRepository(IDataContext dataContext)
		{
			this.dataContext = dataContext;
		}
	}
}