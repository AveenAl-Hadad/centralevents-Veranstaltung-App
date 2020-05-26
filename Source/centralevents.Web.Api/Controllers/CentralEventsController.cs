using CentralEvent.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralEvents.Web.Api.Controllers
{
	public class CentralEventsController : ControllerBase
	{
		private readonly EventService eventService;

		/// <summary>
		/// Initializes a new instance of the <see cref="CentralEventsController"/> class.
		/// </summary>
		public CentralEventsController(EventService eventService)
		{
			this.eventService = eventService;
		}
	}
}