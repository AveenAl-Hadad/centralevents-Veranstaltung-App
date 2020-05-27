namespace CentralEvent.Business.Contracts.Services
{
	using System;
	using System.Collections.Generic;

	using CentralEvent.Business.Contracts.Models;

	public interface IEventService
	{
		IEnumerable<EventModel> GetEventS();

		EventModel GetEvent(Guid id);

		void UpdateEventModel(EventModel eventModel);

		void AddEventModel(EventModel eventModel);

		void RemoveEventModel(EventModel eventModel);
	}
}