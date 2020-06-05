﻿namespace CentralEvents.Web.Api.Tests.Controllers
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
	public class BookingControllerTests
	{
		private BookingController bookingController;
		private Mock<IEventService> eventService;

		[SetUp]
		public void SetUp()
		{
			this.eventService = new Mock<IEventService>();

			this.bookingController = new BookingController(this.eventService.Object);
		}

		//[Test]
		//public void AddBookingDelegatesToEventService() { }
	}
}