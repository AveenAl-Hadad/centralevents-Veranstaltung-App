namespace CentralEvents.Web.Api.Controllers.Base
{
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UserNamePolicy")]
	public class AuthorizedController : ControllerBase { }
}