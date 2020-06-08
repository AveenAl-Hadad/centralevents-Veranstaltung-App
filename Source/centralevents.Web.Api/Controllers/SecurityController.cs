namespace CentralEvents.Web.Api.Controllers
{
	using System;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Text;

	using CentralEvent.Business.Contracts.Models;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using Microsoft.IdentityModel.Tokens;

	using RestSharp;

	[ApiController]
	[Route("api/security")]
	[Authorize]
	public class SecurityController : ControllerBase
	{
		private IConfiguration config;

		public SecurityController(IConfiguration config)
		{
			this.config = config;
		}

		[Route("login")]
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login(string userId = "", string pass = "")
		{
			CustomerModel loginModel = new CustomerModel();
			loginModel.Benutzername = userId;
			loginModel.Passwort = pass;

			IActionResult response = this.Unauthorized();

			CustomerModel userModel = this.AuthenticateUser(loginModel);

			if (userModel.Benutzername != null)
			{
				string tokenString = this.GenerateJsonWebToken(userModel);
				response = this.Ok(new { token = tokenString });
			}

			return response;
		}

		[Route("login2/{UserId}/{Passwort}")]
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login2(string UserId, string Passwort)
		{
			CustomerModel loginModel = new CustomerModel();
			loginModel.Benutzername = UserId;
			loginModel.Passwort = Passwort;

			IActionResult response = this.Unauthorized();

			CustomerModel userModel = this.AuthenticateUser(loginModel);

			if (userModel.Benutzername != null)
			{
				string tokenString = this.GenerateJsonWebToken(userModel);
				response = this.Ok(new { token = tokenString });
			}

			//IRestResponse test = response;
			return response;
		}

		private CustomerModel AuthenticateUser(CustomerModel loginModel)
		{
			// TODO noch hardcoded
			CustomerModel userModel = new CustomerModel();

			if (loginModel.Benutzername == "ceUser" && loginModel.Passwort == "xxx")
			{
				userModel = new CustomerModel { Benutzername = "ceUser", Passwort = "xxx", Rolle = "Admin" };
			}

			return userModel;
		}

		private string GenerateJsonWebToken(CustomerModel infoModel)
		{
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Jwt:Key"]));
			SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			Claim[] claims =
			{
				new Claim(JwtRegisteredClaimNames.Sub, infoModel.Benutzername),
				//new Claim(JwtRegisteredClaimNames.Email, infoModel.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Role, infoModel.Rolle)
			};

			JwtSecurityToken token = new JwtSecurityToken(
														  issuer: this.config["Jwt:Issuer"],
														  audience: this.config["Jwt:Issuer"],
														  claims,
														  expires: DateTime.Now.AddMinutes(10),
														  signingCredentials: credentials);
			string encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

			return encodetoken;
		}

		[Authorize("Admin")]
		//[AllowAnonymous]
		[Route("auth")]
		[HttpPost]
		public IActionResult Post([FromBody] string value)
		{
			try
			{
				return this.Ok(value);
			}
			catch (Exception)
			{
				return this.NotFound();
			}
		}

		[Route("auth2")]
		[Authorize("Admin")]
		//[AllowAnonymous]
		[HttpGet]
		public IActionResult Test([FromHeader] string value)
		{
			try
			{
				return this.Ok(value);
			}
			catch (Exception)
			{
				return this.NotFound();
			}
		}
	}
}