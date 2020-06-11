namespace CentralEvents.DataAccess.Configurations
{
	using System;

	using CentralEvent.Business.Contracts.Models;

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

			builder.HasData(new CustomerModel
							{
								Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
								Vorname = "Hans",
								Nachname = "Werner",
								Strasse = "Bremerstraße",
								Hausnummer = "66a",
								Plz = "28759",
								Ort = "Bremen",
								Telefon = "0421-555 888 22",
								Email = "Hans.Werner@freemail.de",
								Benutzername = "ceUser",
								Passwort = "lUgM3gwaOyfgUGaOB300LtJKsbYamO+hZGrdQVZkIYk="
							});
		}
	}
}