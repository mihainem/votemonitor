﻿// <auto-generated />
using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vote.Monitor.Domain;

#nullable disable

namespace Vote.Monitor.Domain.Migrations
{
    [DbContext(typeof(VoteMonitorContext))]
    partial class VoteMonitorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.CSOAggregate.CSO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CSOs");
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.CountryAggregate.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Iso2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Iso3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumericCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.ElectionRoundAggregate.ElectionRound", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("ElectionRounds");
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.PollingStationAggregate.PollingStation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<JsonDocument>("Tags")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("PollingStations");
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.CSOAdmin", b =>
                {
                    b.HasBaseType("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.ApplicationUser");

                    b.Property<Guid>("CSOId")
                        .HasColumnType("uuid");

                    b.HasIndex("CSOId");

                    b.ToTable("CSOAdmins", (string)null);
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.Observer", b =>
                {
                    b.HasBaseType("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.ApplicationUser");

                    b.ToTable("Observers", (string)null);
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.PlatformAdmin", b =>
                {
                    b.HasBaseType("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.ApplicationUser");

                    b.ToTable("PlatformAdmins", (string)null);
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.ElectionRoundAggregate.ElectionRound", b =>
                {
                    b.HasOne("Vote.Monitor.Domain.Entities.CountryAggregate.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.CSOAdmin", b =>
                {
                    b.HasOne("Vote.Monitor.Domain.Entities.CSOAggregate.CSO", "CSO")
                        .WithMany("Admins")
                        .HasForeignKey("CSOId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.CSOAdmin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CSO");
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.Observer", b =>
                {
                    b.HasOne("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.Observer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.PlatformAdmin", b =>
                {
                    b.HasOne("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("Vote.Monitor.Domain.Entities.ApplicationUserAggregate.PlatformAdmin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vote.Monitor.Domain.Entities.CSOAggregate.CSO", b =>
                {
                    b.Navigation("Admins");
                });
#pragma warning restore 612, 618
        }
    }
}
