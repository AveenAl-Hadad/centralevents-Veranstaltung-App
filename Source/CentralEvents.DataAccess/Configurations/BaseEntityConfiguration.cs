namespace CentralEvents.DataAccess.Configurations
{
	using CentralEvents.DataAccess.Contracts.Entities;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
	{
		private readonly string table;

		protected EntityBaseConfiguration(string table)
		{
			this.table = table;
		}

		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.ToTable(this.table);
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).HasColumnName("Id").ValueGeneratedNever();
		}
	}
}