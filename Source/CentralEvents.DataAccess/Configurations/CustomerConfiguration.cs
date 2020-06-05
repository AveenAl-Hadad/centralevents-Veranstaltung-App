namespace CentralEvents.DataAccess.Configurations
{
	using CentralEvents.DataAccess.Contracts.Entities;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class CustomerConfiguration : EntityBaseConfiguration<CustomerEntity>
	{
		public CustomerConfiguration() : base("CustomerTable") { }

		public override void Configure(EntityTypeBuilder<CustomerEntity> builder)
		{
			base.Configure(builder);

			builder.Property(e => e.Vorname).HasColumnName("Vorname");
			builder.Property(e => e.Nachname).HasColumnName("Nachname");
			builder.Property(e => e.Strasse).HasColumnName("Strasse");
			builder.Property(e => e.Hausnummer).HasColumnName("Hausnummer");
			builder.Property(e => e.Plz).HasColumnName("Plz");
			builder.Property(e => e.Ort).HasColumnName("Ort");
			builder.Property(e => e.Telefon).HasColumnName("Telefon");
			builder.Property(e => e.Email).HasColumnName("Email");
			builder.Property(e => e.Benutzername).HasColumnName("Benutzername");
			builder.Property(e => e.Passwort).HasColumnName("Passwort");
			builder.Property(e => e.Rolle).HasColumnName("Rolle");
		}
	}
}