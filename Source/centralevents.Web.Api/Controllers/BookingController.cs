namespace CentralEvents.Web.Api.Controllers
{
	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	using Microsoft.AspNetCore.Mvc;

	[Route("api/booking")]
	public class BookingController : ControllerBase
	{
		private readonly IEventService eventService;

		public BookingController(IEventService eventService)
		{
			this.eventService = eventService;
		}

		[Route("add")]
		[HttpPost]
		public void AddBooking([FromBody] BookingModel bookingModel)
		{
			this.eventService.AddBooking(bookingModel);
		}
	}
}