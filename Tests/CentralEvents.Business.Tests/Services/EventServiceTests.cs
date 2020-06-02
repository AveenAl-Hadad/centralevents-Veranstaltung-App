namespace CentralEvents.Business.Tests.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvent.Business.Contracts.Mappers;
	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Services;
	using CentralEvents.DataAccess.Contracts.Entities;
	using CentralEvents.DataAccess.Contracts.Repositories;

	using Moq;

	using NUnit.Framework;

	[TestFixture]
	public class EventServiceTests
	{
		//private IEventRepository eventRepository;
		private EventService eventService;
		//private IEventMapper eventMapper;

		private Mock<IEventMapper> eventMapper;

		private Mock<IEventRepository> eventRepository;
		//private Mock<IDataContext> dataContext;

		[SetUp]
		public void SetUp()
		{
			this.eventMapper = new Mock<IEventMapper>();
			//this.dataContext = new Mock<IDataContext>();
			this.eventRepository = new Mock<IEventRepository>();

			//this.eventMapper = new EventMapper();
			//this.eventService = new EventService(this.eventRepository, this.eventMapper);
			//this.eventRepository = new EventRepository(this.dataContext.Object);
			this.eventService = new EventService(this.eventRepository.Object, this.eventMapper.Object);
		}

		[Test]
		public void GetEventsShouldDelegateToEventRepository()
		{
			//IQueryable<EventEntity> eventSqueries = new EnumerableQuery<EventEntity>(eventSentities);
			//this.dataContext.Setup(e => e.Query<EventEntity>()).Returns(eventSqueries);

			IEnumerable<EventEntity> eventSentities = new List<EventEntity>();
			eventSentities = Enumerable.Range(1, 2).Select(id => new EventEntity()).ToList();

			IEnumerable<EventModel> eventSmodels = new List<EventModel>();
			eventSmodels = eventSentities.Select(e => new EventModel { Id = e.Id }).ToList();

			this.eventRepository.Setup(e => e.GetEvents()).Returns(eventSentities);

			IEnumerable<EventModel> result = (IEnumerable<EventModel>)this.eventService.GetEventS();

			CollectionAssert.AreEquivalent(eventSmodels, result);
		}

		[Test]
		[TestCase("6FD5EB20-15F5-4096-8716-13F3493B1410")]
		[TestCase("53833F43-CA85-4E2E-AF3B-1A09C0172989")]
		[TestCase("1209FE48-9590-4D92-8759-1B6E2A377926")]
		public void GetEventSshouldReturnStoredEventS(Guid id)
		{
			Guid[] ids =
			{
				Guid.Parse("6FD5EB20-15F5-4096-8716-13F3493B1410"),
				Guid.Parse("53833F43-CA85-4E2E-AF3B-1A09C0172989"),
				Guid.Parse("1209FE48-9590-4D92-8759-1B6E2A377926")
			};

			IEnumerable<EventModel> result = this.eventService.GetEventS();

			CollectionAssert.AreEquivalent(ids, result.Select(e => e.Id));
		}

		[Test]
		public void GetEventsShouldDelegateToEventService()
		{
			List<EventModel> eventS = Enumerable.Range(1, 2).Select(id => new EventModel()).ToList();

			this.eventRepository.Setup(t => t.GetEventS()).Returns(eventS);

			IEnumerable<EventModel> result = this.eventService.GetEventS();

			CollectionAssert.AreEquivalent(eventS, result);
		}
	}
}