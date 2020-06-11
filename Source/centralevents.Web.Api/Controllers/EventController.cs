namespace CentralEvents.Web.Api.Controllers
{
	using System;
	using System.Collections.Generic;

	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	using CentralEvents.Web.Api.Controllers.Base;

	using Microsoft.AspNetCore.Mvc;

	[Route("api/event")]
	public class EventController : ControllerBase
	{
		private readonly IEventService eventService;

		public EventController(IEventService eventService)
		{
			this.eventService = eventService;
		}

		[Route("add")]
		[HttpPost]
		public void AddEvent([FromBody] EventModel eventModel) // FROMBODY voll wichtig da das Model in HTTP gewrappt ist und so!!!!
		{
			this.eventService.AddEvent(eventModel);
		}

		[Route("getAll")]
		[HttpGet]
		public IEnumerable<EventModel> GetEventS()
		{
			return this.eventService.GetEventS();
		}

		[Route("get/{id}")]
		[HttpGet]
		public EventModel GetEvent(Guid id)
		{
			return this.eventService.GetEvent(id);
		}

		[Route("update")]
		[HttpPut]
		public void UpdateEvent([FromBody] EventModel eventModel)
		{
			this.eventService.UpdateEvent(eventModel);
		}
	}
}