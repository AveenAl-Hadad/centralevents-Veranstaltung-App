namespace CentralEvents.Web.Api.Tests.Controllers
{
	using CentralEvent.Business.Contracts.Services;

	using CentralEvents.Web.Api.Controllers;

	using Moq;

	using NUnit.Framework;

	[TestFixture]
	public class CustomerControllerTests
	{
		private CustomerController customerController;
		private Mock<IEventService> eventService;

		[SetUp]
		public void SetUp()
		{
			this.eventService = new Mock<IEventService>();

			this.customerController = new CustomerController(this.eventService.Object);
		}

		//[Test]
		//public void AddCustomerDelegatesToEventService() { }

		//[Test]
		//public void GetCustomerSdelegatesToEventService() { }
	}
}