namespace CentralEvents.Web.Api.Controllers
{
	using System.Collections.Generic;

	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	using Microsoft.AspNetCore.Mvc;

	[Route("api/customer")]
	public class CustomerController : ControllerBase
	{
		private readonly IEventService eventService;

		public CustomerController(IEventService eventService)
		{
			this.eventService = eventService;
		}

		[Route("add")]
		[HttpPost]
		public void AddCustomer([FromBody] CustomerModel customerModel)
		{
			this.eventService.AddCustomer(customerModel);
		}

		[Route("getAll")]
		[HttpGet]
		public IEnumerable<CustomerModel> GetCustomerS()
		{
			return this.eventService.GetCustomerS();
		}
	}
}