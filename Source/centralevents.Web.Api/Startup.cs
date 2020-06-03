using CentralEvent.Business.Contracts.Mappers;
using CentralEvents.DataAccess.Contracts.Context;

namespace CentralEvents.Web.Api
{
	using CentralEvent.Business.Contracts.Services;
	using CentralEvent.Business.Mappers;
	using CentralEvent.Business.Services;

	using CentralEvents.Commons;
	using CentralEvents.DataAccess.Context;
	using CentralEvents.DataAccess.Contracts.Repositories;
	using CentralEvents.DataAccess.Repositories;

	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;

	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddScoped<IInitializer, DataContext>();
			services.AddScoped<IEventService, EventService>();
			services.AddScoped<IEventRepository, EventRepository>();
			services.AddScoped<IEventMapper, EventMapper>();
			services.AddScoped<IDataContext, DataContext>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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