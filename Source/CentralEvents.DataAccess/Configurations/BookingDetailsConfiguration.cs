using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralEvents.DataAccess.Configurations
{
	using CentralEvents.DataAccess.Contracts.Entities;
    using Microsoft.EntityFrameworkCore;

    public class BookingDetailsConfiguration : EntityBaseConfiguration<BookingEntity>
	{
		public BookingDetailsConfiguration() : base("BookingDetailsTable") { }

		public override void Configure(EntityTypeBuilder<BookingEntity> builder)
		{
			base.Configure(builder);

			builder.Property(e => e.EventName).HasColumnName("EventName");
			builder.Property(e => e.AnzahlTickets).HasColumnName("AnzahlTickets");
			builder.Property(e => e.Vorname).HasColumnName("Vorname");
			builder.Property(e => e.Nachname).HasColumnName("Nachname");
			builder.Property(e => e.Strasse).HasColumnName("Strasse");
			builder.Property(e => e.Hausnummer).HasColumnName("Hausnummer");
			builder.Property(e => e.Plz).HasColumnName("Plz");
			builder.Property(e => e.Ort).HasColumnName("Ort");
			builder.Property(e => e.Telefon).HasColumnName("Telefon");
			builder.Property(e => e.Email).HasColumnName("Email");
		}
	}
}