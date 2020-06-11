namespace CentralEvents.Web.Api.Controllers
{
	using CentralEvent.Business.Contracts.Models;
	using CentralEvent.Business.Services;

	using CentralEvents.Web.Api.Controllers.Base;

	using Microsoft.AspNetCore.Mvc;

	[Route("api/test")]
	public class TestController : AuthorizedController
	{
		[Route("")]
		[HttpGet]
		public TestTextModel Test()
		{
			string userName = SessionService.Instance.Benutzername;
			return new TestTextModel { Text = $"Api works: {userName}" };
		}
	}
}