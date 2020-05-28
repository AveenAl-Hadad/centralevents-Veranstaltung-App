using System.Collections.Generic;
using CentralEvent.Business.Contracts.Models;
using CentralEvent.Business.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralEvents.Web.Api.Controllers
{
	[Route("api/eventControl")]
	public class CentralEventsController : ControllerBase
	{
		private readonly IEventService eventService;

		public CentralEventsController(IEventService eventService)
		{
			this.eventService = eventService;
		}

		[Route("")]
		[HttpGet]
		public IEnumerable<EventModel> GetEventS()
		{
			return eventService.GetEventS();
		}

		[Route("add")]
		[HttpPost]
		public void
			AddEvent([FromBody] EventModel eventModel) // FROMBODY voll wichtig da das Model in HTTP gewrappt ist und so!!!!
		{
			eventService.AddEvent(eventModel);
		}
	}
}