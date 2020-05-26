namespace CentralEvents.DataAccess.Context
{
	using System;
	using System.Linq;
	using System.Reflection;

	using CentralEvents.Commons;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;

	public class DataContext : DbContext, IDataContext, IInitializer
	{
		private readonly IConfiguration configuration;

		public DataContext(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("CE"));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("DBO");
			// alle Konfigurationen werden in die DB eingladen, die sich DataAccess befinden
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DataContext))
														 ?? throw new InvalidOperationException());
		}

		// Hier wird immer der aktuelle der Stand der DB migriert
		public void Initialize()
		{
			this.Database.Migrate();
		}

		//Abfrage auf der DB

		IQueryable<TEntity> IDataContext.Query<TEntity>()
		{
			return this.Set<TEntity>();
		}
	}
}