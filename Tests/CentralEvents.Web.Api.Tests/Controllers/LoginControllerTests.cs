namespace CentralEvents.Web.Api.Tests.Controllers
{
	using NUnit.Framework;

	[TestFixture]
	public class LoginControllerTests
	{
		private LoginController loginController;

		[SetUp]
		public void SetUp()
		{
			this.loginController = new LoginController();
		}
	}
}