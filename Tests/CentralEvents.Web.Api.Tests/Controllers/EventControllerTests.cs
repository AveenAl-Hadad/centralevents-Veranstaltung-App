namespace CentralEvents.Web.Api.Tests.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	using CentralEvents.Web.Api.Controllers;

	using Moq;

	using NUnit.Framework;

	[TestFixture]
	public class EventControllerTests
	{
		private EventController eventController;
		private Mock<IEventService> eventService;

		[SetUp]
		public void SetUp()
		{
			this.eventService = new Mock<IEventService>();

			this.eventController = new EventController(this.eventService.Object);
		}

		[Test]
		public void GetEventSdelegatesToEventService()
		{
			List<EventModel> eventS = Enumerable.Range(1, 2).Select(id => new EventModel()).ToList();

			this.eventService.Setup(e => e.GetEventS()).Returns(eventS);

			IEnumerable<EventModel> result = this.eventController.GetEventS();

			CollectionAssert.AreEquivalent(eventS, result);
			this.eventService.Verify(s => s.GetEventS());
		}

		[TestCase("6FD5EB20-15F5-4096-8716-13F3493B1410")]
		[TestCase("53833F43-CA85-4E2E-AF3B-1A09C0172989")]
		[TestCase("1209FE48-9590-4D92-8759-1B6E2A377926")]
		public void GetEventDelegatesToEventService(string guid)
		{
			Guid id = Guid.Parse(guid);
			EventModel eventModel = new EventModel { Id = id };
			this.eventService.Setup(s => s.GetEvent(id)).Returns(eventModel);

			EventModel result = this.eventController.GetEvent(id);

			Assert.AreEqual(id, result.Id);
			this.eventService.Verify(s => s.GetEvent(id));
		}

		[TestCase("ersterName")]
		[TestCase("zweiterAndererName")]
		public void UpdateEventDelegatesToEventService(string expected)
		{
			Guid id = Guid.Parse("6FD5EB20-15F5-4096-8716-13F3493B1410");
			EventModel eventModel = new EventModel { Id = id, Name = expected };
			this.eventService.Setup(s => s.GetEvent(id)).Returns(eventModel);

			this.eventController.UpdateEvent(eventModel);
			EventModel result = this.eventController.GetEvent(id);

			Assert.AreEqual(id, result.Id);
		}
	}
}