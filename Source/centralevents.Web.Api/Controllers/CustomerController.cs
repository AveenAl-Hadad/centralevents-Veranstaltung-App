namespace CentralEvents.Web.Api.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Security.Cryptography;

	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Contracts.Services;

	using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
			string password = customerModel.Passwort;
			byte[] salt = new byte[128 / 8];

			using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}

			customerModel.Passwort = Convert.ToBase64String(KeyDerivation.Pbkdf2(
																				 password: password,
																				 salt: salt,
																				 prf: KeyDerivationPrf.HMACSHA1,
																				 iterationCount: 10000,
																				 numBytesRequested: 256 / 8));
			this.eventService.AddCustomer(customerModel);
		}

		[Route("getAll")]
		[HttpGet]
		public IEnumerable<CustomerModel> GetCustomerS()
		{
			return this.eventService.GetCustomerS();
		}

		[Route("get/{id}")]
		[HttpGet]
		public void Get(Guid guid)
		{
			this.eventService.GetCustomer(guid);
		}

		[Route("update")]
		[HttpPut]
		public void UpdateCustomer(CustomerModel customerModel)
		{
			this.eventService.UpdateCustomer(customerModel);
		}
	}
}