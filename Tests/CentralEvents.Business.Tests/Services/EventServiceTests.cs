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

		//private EventMapper eventMapper;
		private Mock<IEventMapper> eventMapper;

		private Mock<IEventRepository> eventRepository;
		//private Mock<IDataContext> dataContext;

		private IEnumerable<EventModel> eventSmodels;
		private IEnumerable<EventEntity> eventSentities;
		private IEnumerable<EventModel> result;

		//private EventModel eventModel;
		//private EventEntity eventEntity;

		[SetUp]
		public void SetUp()
		{
			//this.eventSmodels = new EventModel[0];
			//this.eventSentities = new EventEntity[0];
			//this.result = new EventModel[0];
			//this.eventModel = new EventModel();
			//this.eventEntity = new EventEntity();

			this.eventMapper = new Mock<IEventMapper>();
			//this.dataContext = new Mock<IDataContext>();
			this.eventRepository = new Mock<IEventRepository>();

			//this.eventMapper = new EventMapper();
			//this.eventService = new EventService(this.eventRepository, this.eventMapper);
			//this.eventRepository = new EventRepository(this.dataContext.Object);
			this.eventService = new EventService(this.eventRepository.Object, this.eventMapper.Object);
		}

		[Test]
		public void GetEventSdelegatesToEventRepository()
		{
			//IQueryable<EventEntity> eventSqueries = new EnumerableQuery<EventEntity>(eventSentities);
			//this.dataContext.Setup(e => e.Query<EventEntity>()).Returns(eventSqueries);
			// IEnumerable<EventEntity> eventSentities = new List<EventEntity>();

			this.eventSentities = Enumerable.Range(1, 2).Select(id => new EventEntity()).ToList();

			this.eventSmodels = this.eventSentities.Select(e => new EventModel { Id = e.Id }).ToList();

			this.eventRepository.Setup(e => e.GetEvents()).Returns(this.eventSentities);

			// Hier verreckts!
			this.eventMapper.Setup(e => e.EventEntitiesToModelList(this.eventSentities)).Returns(this.eventSmodels);

			this.result = this.eventService.GetEventS();

			CollectionAssert.AreEquivalent(this.eventSmodels, this.result);
			//this.eventRepository.Verify(s => s.GetEventS());
		}

		[TestCase("6FD5EB20-15F5-4096-8716-13F3493B1410")]
		[TestCase("53833F43-CA85-4E2E-AF3B-1A09C0172989")]
		[TestCase("1209FE48-9590-4D92-8759-1B6E2A377926")]
		public void GetEventDelegatesToEventRepository(string guid)
		{
			Guid id = Guid.Parse(guid);
			EventModel eventModel = new EventModel { Id = id };
			EventEntity eventEntity = new EventEntity { Id = eventModel.Id };

			this.eventRepository.Setup(s => s.GetEvent(id)).Returns(eventEntity);
			this.eventMapper.Setup(m => m.EventEntityToModel(eventEntity)).Returns(eventModel);

			EventModel result = this.eventService.GetEvent(id);

			Assert.AreEqual(id, result.Id);
			this.eventRepository.Verify(s => s.GetEvent(id));
		}
	}
}