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
	public class CentralEventsControllerTests
	{
		private CentralEventsController cEcontroller;
		private Mock<IEventService> eventService;

		[SetUp]
		public void SetUp()
		{
			this.eventService = new Mock<IEventService>();

			this.cEcontroller = new CentralEventsController(this.eventService.Object);
		}

		[Test]
		public void GetEventsShouldDelegateToEventService()
		{
			List<EventModel> eventS = Enumerable.Range(1, 2).Select(id => new EventModel { Id = new Guid() }).ToList();

			this.eventService.Setup(t => t.GetEventS()).Returns(eventS);

			IEnumerable<EventModel> result = this.cEcontroller.GetEventS();

			CollectionAssert.AreEquivalent(eventS, result);
		}
	}
}