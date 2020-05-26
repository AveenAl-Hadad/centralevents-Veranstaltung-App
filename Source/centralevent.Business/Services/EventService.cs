namespace CentralEvent.Business.Services
{
	using CentralEvent.Business.Contracts.Services;
	using CentralEvent.Business.Mappers;

	using CentralEvents.DataAccess.Contracts.Repositories;

	public class EventService : IEventService
	{
		private readonly IEventMapper eventMapper;
		private readonly IEventRepository eventRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventService"/> class.
		/// </summary>
		public EventService(IEventRepository eventRepository, IEventMapper eventMapper)
		{
			this.eventRepository = eventRepository;
			this.eventMapper = eventMapper;
		}

		// public IEnumerable<EventModel> GetEvents()
		// {
		// 	IEnumerable<EventEntity> eventEntity = this.eventRepository.FetchAll();
		// 	EventModel[] eventModels = eventEntity.Select(this.eventMapper.Mapper).ToArray();
		// 	return eventModels;
		// }
		//
		// public EventModel GetEvent(Guid id)
		// {
		// 	EventEntity eventEntity = this.eventRepository.Fetch(id);
		// 	EventModel eventModel = this.eventMapper.Mapper(eventEntity);
		// 	return eventModel;
		// }
	}
}