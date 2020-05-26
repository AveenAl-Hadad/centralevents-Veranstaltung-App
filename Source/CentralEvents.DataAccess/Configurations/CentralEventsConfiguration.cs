namespace CentralEvents.DataAccess.Configurations
{
	using CentralEvents.DataAccess.Contracts.Entities;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class CentralEventsConfiguration : EntityBaseConfiguration<EventEntity>
	{
		public CentralEventsConfiguration() : base("CentralEventsTable") { }

		public override void Configure(EntityTypeBuilder<EventEntity> builder)
		{
			base.Configure(builder);

			builder.Property(e => e.Name).HasColumnName("Name");
		}
	}
}