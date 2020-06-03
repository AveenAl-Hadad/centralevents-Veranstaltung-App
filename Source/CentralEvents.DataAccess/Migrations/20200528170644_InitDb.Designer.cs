﻿// <auto-generated />
using System;
using CentralEvents.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CentralEvents.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200528170644_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("DBO")
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentralEvents.DataAccess.Contracts.Entities.BookingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnzahlTickets")
                        .HasColumnName("AnzahlTickets")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnName("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hausnummer")
                        .HasColumnName("Hausnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nachname")
                        .HasColumnName("Nachname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ort")
                        .HasColumnName("Ort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plz")
                        .HasColumnName("Plz")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strasse")
                        .HasColumnName("Strasse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnName("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .HasColumnName("Vorname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookingDetailsTable");
                });

            modelBuilder.Entity("CentralEvents.DataAccess.Contracts.Entities.EventEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BeginnUhrzeit")
                        .HasColumnName("BeginnUhrzeit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Beschreibung")
                        .HasColumnName("Beschreibung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Datum")
                        .HasColumnName("Datum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Eintritt")
                        .HasColumnName("Eintritt")
                        .HasColumnType("float");

                    b.Property<string>("EndeUhrzeit")
                        .HasColumnName("EndeUhrzeit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GesamtanzahlEintrittskarten")
                        .HasColumnName("GesamtanzahlEintrittskarten")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ort")
                        .HasColumnName("Ort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Restbestand")
                        .HasColumnName("Restbestand")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CentralEventsTable");
                });
#pragma warning restore 612, 618
        }
    }
}