﻿namespace CentralEvents.Web.Api.Controllers
{
	using System;
	using System.Collections.Generic;

	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	using Microsoft.AspNetCore.Mvc;

	[Route("api/eventControl")]
	public class CentralEventsController : ControllerBase
	{
		private readonly IEventService eventService;

		public CentralEventsController(IEventService eventService)
		{
			this.eventService = eventService;
		}

		[Route("addEvent")]
		[HttpPost]
		public void AddEvent([FromBody] EventModel eventModel) // FROMBODY voll wichtig da das Model in HTTP gewrappt ist und so!!!!
		{
			this.eventService.AddEvent(eventModel);
		}

		[Route("addBooking")]
		[HttpPost]
		public void AddBooking([FromBody] BookingModel bookingModel)
		{
			this.eventService.AddBooking(bookingModel);
		}

		[Route("addCustomer")]
		[HttpPost]
		public void AddCustomer([FromBody] CustomerModel customerModel)
		{
			this.eventService.AddCustomer(customerModel);
		}

		[Route("getEvents")]
		[HttpGet]
		public IEnumerable<EventModel> GetEventS()
		{
			return this.eventService.GetEventS();
		}

		[Route("getEvent/{id}")]
		[HttpGet]
		public EventModel GetEvent(Guid id)
		{
			return this.eventService.GetEvent(id);
		}

		[Route("updateEvent")]
		[HttpPut]
		public void UpdateEvent([FromBody] EventModel eventModel)
		{
			this.eventService.UpdateEvent(eventModel);
		}
	}
}