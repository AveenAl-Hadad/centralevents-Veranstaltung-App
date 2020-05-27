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
			builder.Property(e => e.Ort).HasColumnName("Ort");
			builder.Property(e => e.Datum).HasColumnName("Datum");
			builder.Property(e => e.BeginnUhrzeit).HasColumnName("BeginnUhrzeit");
			builder.Property(e => e.EndeUhrzeit).HasColumnName("EndeUhrzeit");
			builder.Property(e => e.Eintritt).HasColumnName("Eintritt");
			builder.Property(e => e.Beschreibung).HasColumnName("Beschreibung");
		}
	}
}