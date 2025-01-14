﻿// <auto-generated />
using System;
using FlightOperations.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightOperations.Model.Migrations
{
    [DbContext(typeof(FlightOperationsContext))]
    [Migration("20200819031522_FlightOps")]
    partial class FlightOps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightOperations.Model.Entity.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftTypeId");

                    b.Property<int>("AirportCategoryId");

                    b.Property<int>("BusinessCapacity");

                    b.Property<int>("CargoCapacity");

                    b.Property<int>("CountryOfRegistration");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DateOfRegistration");

                    b.Property<int>("EconomyCapacity");

                    b.Property<int>("FirstCapacity");

                    b.Property<int>("MaximumFlightHours");

                    b.Property<int>("PeconomyCapacity");

                    b.Property<string>("Registration");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AircraftTypeId");

                    b.HasIndex("AirportCategoryId");

                    b.HasIndex("CountryOfRegistration");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.AircraftType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AircraftTypeName");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Make");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("AircraftTypes");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.AirlineSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("PeriodFrom");

                    b.Property<DateTime>("PeriodTo");

                    b.Property<string>("ScheduleName");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("AirlineSchedules");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("AirportCategoryId");

                    b.Property<string>("AirportName");

                    b.Property<int>("CityId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("IATA_Code");

                    b.Property<string>("ICAO_Code");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AirportCategoryId");

                    b.HasIndex("CityId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.AirportCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<string>("CategoryNumber");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("AirportCategories");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityCode");

                    b.Property<string>("CityName");

                    b.Property<int>("CountryId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode");

                    b.Property<string>("CountryName");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Region");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.FlightSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineScheduleID");

                    b.Property<int>("Airport_DesitinationID");

                    b.Property<int>("Airport_OriginID");

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Days");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<DateTime>("FlightDate");

                    b.Property<string>("FlightNumber");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AirlineScheduleID");

                    b.HasIndex("Airport_DesitinationID");

                    b.HasIndex("Airport_OriginID");

                    b.ToTable("FlightSchedules");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Destination");

                    b.Property<double>("FlightHours");

                    b.Property<int>("Origin");

                    b.Property<double>("TripHours");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("Destination");

                    b.HasIndex("Origin");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Schedule_AircraftType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftTypeId");

                    b.Property<int?>("AirlineScheduleId");

                    b.Property<int>("Airline_ScheduleID");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Quantity");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AircraftTypeId");

                    b.HasIndex("AirlineScheduleId");

                    b.HasIndex("Airline_ScheduleID");

                    b.ToTable("Schedule_AircraftTypes");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsLockedOut");

                    b.Property<string>("LastName");

                    b.Property<int>("PasswordAttempt");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Username");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Aircraft", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.AircraftType", "AircraftType")
                        .WithMany()
                        .HasForeignKey("AircraftTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.AirportCategory", "AirportCategory")
                        .WithMany()
                        .HasForeignKey("AirportCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryOfRegistration")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Airport", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.AirportCategory", "AirportCategory")
                        .WithMany()
                        .HasForeignKey("AirportCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.City", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.FlightSchedule", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.AirlineSchedule", "AirlineSchedule")
                        .WithMany()
                        .HasForeignKey("AirlineScheduleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.Airport", "Airport_Desitination")
                        .WithMany()
                        .HasForeignKey("Airport_DesitinationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.Airport", "Airport_Origin")
                        .WithMany()
                        .HasForeignKey("Airport_OriginID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Route", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.Airport", "DestinationAirport")
                        .WithMany()
                        .HasForeignKey("Destination")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.Airport", "OriginAirport")
                        .WithMany()
                        .HasForeignKey("Origin")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Schedule_AircraftType", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.AircraftType", "AircraftType")
                        .WithMany()
                        .HasForeignKey("AircraftTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.AirlineSchedule")
                        .WithMany("AircraftTypes")
                        .HasForeignKey("AirlineScheduleId");

                    b.HasOne("FlightOperations.Model.Entity.AirlineSchedule", "AirlineSchedule")
                        .WithMany()
                        .HasForeignKey("Airline_ScheduleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
