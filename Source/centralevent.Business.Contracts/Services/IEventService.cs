namespace CentralEvent.Business.Contracts.Services
{
	using System;
	using System.Collections.Generic;

	using CentralEvent.Business.Contracts.Models;

	public interface IEventService
	{
		void AddEvent(EventModel eventModel);

		IEnumerable<EventModel> GetEventS();

		EventModel GetEvent(Guid id);

		void UpdateEvent(EventModel eventModel);

		void RemoveEvent(EventModel eventModel);
	}
}