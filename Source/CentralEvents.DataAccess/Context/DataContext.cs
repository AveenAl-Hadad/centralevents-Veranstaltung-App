namespace CentralEvents.DataAccess.Context
{
	using System;
	using System.Linq;
	using System.Reflection;

	using CentralEvents.Commons;
	using CentralEvents.DataAccess.Contracts.Context;

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
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DataContext))
														 ?? throw new InvalidOperationException());
		}

		public void Initialize()
		{
			this.Database.Migrate();
		}

		//CRUD

		// CREATE
		void IDataContext.Add<TEntity>(TEntity entity)
		{
			base.Add(entity);
		}

		// READ
		IQueryable<TEntity> IDataContext.Query<TEntity>()
		{
			return this.Set<TEntity>();
		}

		// UPDATE
		public void SaveChangedRepository()
		{
			base.SaveChanges();
		}

		// REMOVE
		void IDataContext.Remove<TEntity>(TEntity entity)
		{
			base.Remove(entity);
		}
	}
}