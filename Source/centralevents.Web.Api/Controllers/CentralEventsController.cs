namespace CentralEvents.Web.Api.Controllers
{
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

		[Route("")]
		[HttpGet]
		public IEnumerable<EventModel> GetEventS()
		{
			return this.eventService.GetEventS();
		}
	}

}