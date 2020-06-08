namespace CentralEvents.Web.Api
{
	using System.Text;

	using CentralEvent.Business.Contracts.Mappers;
	using CentralEvent.Business.Contracts.Services;
	using CentralEvent.Business.Mappers;
	using CentralEvent.Business.Services;

	using CentralEvents.Commons;
	using CentralEvents.DataAccess.Context;
	using CentralEvents.DataAccess.Contracts.Context;
	using CentralEvents.DataAccess.Contracts.Repositories;
	using CentralEvents.DataAccess.Repositories;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.IdentityModel.Tokens;

	public class Startup
	{

		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddScoped<IInitializer, DataContext>();
			services.AddScoped<IEventService, EventService>();
			services.AddScoped<IEventRepository, EventRepository>();
			services.AddScoped<IEventMapper, EventMapper>();
			services.AddScoped<IDataContext, DataContext>();
			services.AddScoped<ISecurityService, SecurityService>();

			//services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			//		.AddJwtBearer(option =>
			//					  {
			//						  option.TokenValidationParameters = new TokenValidationParameters
			//															 {
			//																 ValidateIssuer = true,
			//																 ValidateAudience = true,
			//																 ValidateLifetime = true,
			//																 ValidateIssuerSigningKey = true,
			//																 ValidIssuer = this.Configuration["Jwt: Issuer"],
			//																 ValidAudience = this.Configuration["Jwt:Issuer"],
			//																 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Jwt:Key"]))
			//															 };
			//					  });
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			// JWT
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
							 {
								 endpoints.MapControllers();
								 endpoints.MapDefaultControllerRoute(); // JWT


							 });



		}
	}
}