﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RideShare.DataAccess;

namespace RideShare.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("RideShare.Entity.ReservationDataModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("createTime")
                        .HasColumnType("bigint");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("rideId")
                        .HasColumnType("integer");

                    b.Property<string>("surname")
                        .HasColumnType("text");

                    b.Property<long>("updateTime")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("rideId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RideShare.Entity.RideDataModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("createTime")
                        .HasColumnType("bigint");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("from")
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<int>("seat")
                        .HasColumnType("integer");

                    b.Property<string>("to")
                        .HasColumnType("text");

                    b.Property<long>("updateTime")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("Ride");
                });

            modelBuilder.Entity("RideShare.Entity.ReservationDataModel", b =>
                {
                    b.HasOne("RideShare.Entity.RideDataModel", "ride")
                        .WithMany("Reservations")
                        .HasForeignKey("rideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ride");
                });

            modelBuilder.Entity("RideShare.Entity.RideDataModel", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
