namespace CentralEvents.DataAccess.Context
{
	using System.Linq;
	using System.Reflection;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;

	public class DataContext : DbContext, IDataContext
	{
		private readonly IConfiguration configuration;

		/// <summary>
		/// Initializes a new instance of the <see cref="DataContext"/> class.
		/// </summary>
		public DataContext(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		/// <summary>
		///     <para>
		///         Override this method to configure the database (and other options) to be used for this context.
		///         This method is called for each instance of the context that is created.
		///         The base implementation does nothing.
		///     </para>
		///     <para>
		///         In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
		///         to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
		///         the options have already been set, and skip some or all of the logic in
		///         <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
		///     </para>
		/// </summary>
		/// <param name="optionsBuilder">
		///     A builder used to create or modify options for this context. Databases (and other extensions)
		///     typically define extension methods on this object that allow you to configure the context.
		/// </param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				// Connection String in appsettings.json
				//"Data Source=localhost\\SQLEXPRESS;Database=CentralEvents;User ID=ce_user;Password=ce_pass;"
				optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("CE"));
			}
		}

		/// <summary>
		///     Override this method to further configure the model that was discovered by convention from the entity types
		///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
		///     and re-used for subsequent instances of your derived context.
		/// </summary>
		/// <remarks>
		///     If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
		///     then this method will not be run.
		/// </remarks>
		/// <param name="modelBuilder">
		///     The builder being used to construct the model for this context. Databases (and other extensions) typically
		///     define extension methods on this object that allow you to configure aspects of the model that are specific
		///     to a given database.
		/// </param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("DBO");
			// alle Konfigurationen werden in die DB eingladen, die sich DataAccess befinden
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DataContext)));
		}

		// Hier wird immer der aktuelle der Stand der DB migriert
		public void Initialize()
		{
			this.Database.Migrate();
		}

		//Abfrage auf der DB
		// public IQueryable<TModel> Query<TModel>() where TModel : class
		// {
		//
		// }
	}
}