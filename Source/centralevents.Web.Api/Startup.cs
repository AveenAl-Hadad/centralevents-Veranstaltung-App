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
	using CentralEvents.Web.Api.Authorization;

	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.IdentityModel.Tokens;

	public class Startup
	{
		private const string Secret =
			"MIICXQIBAAKBgQDcMs1TeEl5sh9HVROXi/ARdpkrLONMRNL5tXR46+6VJmxpbF8b\n7VtNBuSSiJz7zYysCkJxuN6DdahNve8M3tFfMAa4C6LdrPr/ULcwR+Df6qnlrWlg\nhRAuW4a3RDwX5XHUCYIo9P2HeO1Jc6WptjCE8gYil1OnwbrAYpfrMT/66wIDAQAB\nAoGBAIxnaDzc6hzK0t7tBH0RIZZBBRFeoeAz0kKezRF9frdjtKTUESEBi8Hlr0Ew\nEskMG7JnKE7TDi7MivBnN1IBkYXtFjPLAZDmeh94GTBNHfNGhXPDr497+Xowk21B\nVokwh4Y5L7ZqLL9u8WQ6TCQdZPzA/rE+CVDFLObwdR6vOa6BAkEA+2+2QzFoA5lX\nxO1T0u/KOqk2R2zNM7Rl5dD7FRX5CdEQIHB+fXXnPcx9XchzCEU6sY4+g4HwUc5d\nWpfOlexqmwJBAOAx8cYn6/hElH4Jkh6+v/FgaSk+ZmdVUzeOZNhORKZZu+SfLsGD\nsf+sv5DArOelMZBCQtUYnaSfZH5CbTNNTfECQQC/JBx9liiJW+AyL2zi1TF6SLqf\nr6GLZd90xtqpG+wXP1wwHPS7sY7aFwNS8RgpuF83LXhuhrBHsEadoPwGUxRzAkBX\nxRXLJuvpmSetJCARa0oHvF/PJr++apgWoud2C0Yy/eRiP7N1TRKNbtrcV6IZWgHK\nYTZ66JUm0sPr7iOENxpxAkBXzt9LjP6dYBu8uoVdJJb6ZNg01WPQ83nnDs7LXNAr\npbR9PWpxDOimd+M3+VjxWhJoncwrR4A1/Mt87OUxGKag";

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

			services.AddScoped<IAuthenticationHandlerService, AuthenticationHandlerService>();

			services.AddScoped
				<IJwtSecurityTokenCreatorService, JwtSecurityTokenHandlerService>
				(provider =>
				 {
					 JwtSecurityTokenHandlerService tokenHandlerService = new JwtSecurityTokenHandlerService();

					 tokenHandlerService.Initialize(Secret, 360);

					 return tokenHandlerService;
				 });

			byte[] key = Encoding.ASCII.GetBytes(Secret);
			services.AddAuthentication(options => options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
								  {
									  options.RequireHttpsMetadata = false;
									  options.SaveToken = true;
									  options.TokenValidationParameters = new TokenValidationParameters
																		  {
																			  ValidateIssuerSigningKey = true,
																			  IssuerSigningKey = new SymmetricSecurityKey(key),
																			  ValidateIssuer = false,
																			  ValidateAudience = false
																		  };
									  options.Events = new CustomJwtBearerEvents();
								  });

			services.AddAuthorization(options => options.AddPolicy("UserNamePolicy", policy => policy.RequireClaim("benutzername")));// TODO
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}