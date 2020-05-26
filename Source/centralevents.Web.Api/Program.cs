namespace CentralEvents.Web.Api
{
	using System;
	using System.Collections.Generic;

	using CentralEvents.Commons;

	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;

	public class Program
	{
		public static void Main(string[] args)
		{
			IHost webHost = CreateHostBuilder(args).Build();
			Initialize(webHost);
			webHost.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

		private static void Initialize(IHost webHost)
		{
			using (IServiceScope scope = webHost.Services.CreateScope())
			{
				IServiceProvider provider = scope.ServiceProvider;
				IEnumerable<IInitializer> initializers = provider.GetServices<IInitializer>();

				foreach (IInitializer initializer in initializers)
				{
					initializer.Initialize();
				}
			}
		}
	}
}