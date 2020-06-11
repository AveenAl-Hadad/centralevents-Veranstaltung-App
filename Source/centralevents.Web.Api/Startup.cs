namespace CentralEvents.Web.Api
{
	using CentralEvent.Business.Contracts.Mappers;
	using CentralEvent.Business.Contracts.Services;
	using CentralEvent.Business.Mappers;
	using CentralEvent.Business.Services;

	using CentralEvents.Commons;
	using CentralEvents.DataAccess.Context;
	using CentralEvents.DataAccess.Contracts.Context;
	using CentralEvents.DataAccess.Contracts.Repositories;
	using CentralEvents.DataAccess.Repositories;

	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;

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
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}