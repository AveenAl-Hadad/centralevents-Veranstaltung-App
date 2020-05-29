namespace CentralEvents.Business.Tests.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvent.Business.Contracts.Mappers;
	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Services;

	using CentralEvents.DataAccess.Contracts.Repositories;

	using NUnit.Framework;

	[TestFixture]
	public class EventServiceTests
	{
		private EventService eventService;
		private IEventMapper eventMapper;
		private IEventRepository eventRepository;

		[SetUp]
		public void SetUp()
		{
			this.eventService = new EventService(this.eventRepository, this.eventMapper);
		}

		[Test]
		public void GetEventSshouldReturnStoredEventS()
		{

			Guid[] ids = { Guid.Parse("5A6C4A3D-67B4-4363-9D56-9A65830C724C"), Guid.Parse("0E07202A-E5DC-4CA1-94DF-42550D756940"), Guid.Parse("702A0F03-B9DE-4D94-B079-F476F8D03812") };
			IEnumerable<EventModel> result = this.eventService.GetEventS();

			CollectionAssert.AreEquivalent(ids, result.Select(r => r.Id));


			//Guid[] ids =
			//{
			//	Guid.Parse("5A6C4A3D-67B4-4363-9D56-9A65830C724C"),
			//	Guid.Parse("0E07202A-E5DC-4CA1-94DF-42550D756940"),
			//	Guid.Parse("702A0F03-B9DE-4D94-B079-F476F8D03812")
			//};

			//IEnumerable<EventModel> result = this.eventService.GetEventS();

			//CollectionAssert.AreEquivalent(ids, result.Select(t => t.Id));
		}
	}
}