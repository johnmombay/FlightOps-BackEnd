﻿// <auto-generated />
using System;
using FlightOperations.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightOperations.Model.Migrations
{
    [DbContext(typeof(FlightOperationsContext))]
    partial class FlightOperationsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("AircraftScheduleID");

                    b.Property<int>("AircraftTypeId");

                    b.Property<int>("BusinessCapacity");

                    b.Property<int>("CargoCapacity");

                    b.Property<int>("CountryOfRegistration");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DateOfRegistration");

                    b.Property<int>("EconomyCapacity");

                    b.Property<int>("FirstCapacity");

                    b.Property<int>("FlightScheduleID");

                    b.Property<int>("PeconomyCapacity");

                    b.Property<string>("Registration");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AircraftTypeId");

                    b.HasIndex("CountryOfRegistration");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.AircraftMaintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftTypeID");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<double>("Duration");

                    b.Property<int>("Frequency");

                    b.Property<string>("MaintenanceCode");

                    b.Property<string>("MaintenanceName");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AircraftTypeID");

                    b.ToTable("AircraftMaintenances");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.AircraftSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ASTA");

                    b.Property<DateTime>("ASTD");

                    b.Property<DateTime?>("ATA");

                    b.Property<DateTime?>("ATD");

                    b.Property<int>("AdultPAX");

                    b.Property<DateTime>("AircraftFlightDate");

                    b.Property<int>("AircraftID");

                    b.Property<int>("Cargo");

                    b.Property<int>("ChildPAX");

                    b.Property<string>("Comments");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("FlightScheduleId");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AircraftID");

                    b.HasIndex("FlightScheduleId");

                    b.ToTable("AircraftSchedules");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.AircraftType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ACN");

                    b.Property<string>("AircraftTypeName");

                    b.Property<int>("CategoryNumber");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Make");

                    b.Property<double>("MaximumFlightHours");

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

                    b.Property<bool>("isPublished");

                    b.HasKey("Id");

                    b.ToTable("AirlineSchedules");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("AirportCategory");

                    b.Property<string>("AirportName");

                    b.Property<int>("CityId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("IATA_Code");

                    b.Property<string>("ICAO_Code");

                    b.Property<double>("MinimumGroundTime");

                    b.Property<DateTime>("OperationFrom");

                    b.Property<DateTime>("OperationTo");

                    b.Property<string>("PCN");

                    b.Property<double>("StandardGroundTime");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.AirportCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<int>("CategoryNumber");

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

            modelBuilder.Entity("FlightOperations.Model.Entity.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CrewPositionID");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<DateTime>("PassportExpiryDate");

                    b.Property<string>("PassportNo");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("CrewPositionID");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.CrewPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("PositionName");

                    b.Property<int>("PositionType");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("CrewPositions");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.CrewSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CrewID");

                    b.Property<int>("FlightScheduleID");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("CrewID");

                    b.HasIndex("FlightScheduleID");

                    b.ToTable("CrewSchedules");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.FlightSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftTypeID");

                    b.Property<int>("AirlineScheduleID");

                    b.Property<int>("Airport_DestinationID");

                    b.Property<int>("Airport_OriginID");

                    b.Property<double>("BlockTime");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Days");

                    b.Property<DateTime>("FlightDate");

                    b.Property<string>("FlightNo");

                    b.Property<double>("FlyingHours");

                    b.Property<string>("InboundFlightNo");

                    b.Property<string>("OutboundFlightNo");

                    b.Property<DateTime>("PeriodFrom");

                    b.Property<DateTime>("PeriodTo");

                    b.Property<DateTime>("STA");

                    b.Property<DateTime>("STD");

                    b.Property<int>("Status");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.Property<bool>("isReturn");

                    b.Property<int>("resourceId");

                    b.HasKey("Id");

                    b.HasIndex("AirlineScheduleID");

                    b.HasIndex("Airport_DestinationID");

                    b.HasIndex("Airport_OriginID");

                    b.ToTable("FlightSchedules");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.MaintenanceSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftID");

                    b.Property<int>("AircraftMaintenanceID");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<double>("Duration");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("MaintenanceDate");

                    b.Property<string>("ResourceID");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.Property<DateTime>("scheduleFrom");

                    b.Property<DateTime>("scheduleTo");

                    b.HasKey("Id");

                    b.HasIndex("AircraftID");

                    b.HasIndex("AircraftMaintenanceID");

                    b.ToTable("MaintenanceSchedules");
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

                    b.Property<int>("Airline_ScheduleID");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Quantity");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AircraftTypeId");

                    b.HasIndex("Airline_ScheduleID");

                    b.ToTable("Schedule_AircraftTypes");
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.ScheduleResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineScheduleID");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AirlineScheduleID");

                    b.ToTable("ScheduleResources");
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

                    b.Property<string>("UserRole");

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

                    b.HasOne("FlightOperations.Model.Entity.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryOfRegistration")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.AircraftMaintenance", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.AircraftType", "AircraftType")
                        .WithMany()
                        .HasForeignKey("AircraftTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.AircraftSchedule", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.FlightSchedule", "FlightSchedule")
                        .WithMany()
                        .HasForeignKey("FlightScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.Airport", b =>
                {
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

            modelBuilder.Entity("FlightOperations.Model.Entity.Crew", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.CrewPosition", "CrewPosition")
                        .WithMany()
                        .HasForeignKey("CrewPositionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.CrewSchedule", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.FlightSchedule", "FlightSchedule")
                        .WithMany()
                        .HasForeignKey("FlightScheduleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.FlightSchedule", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.AirlineSchedule", "AirlineSchedule")
                        .WithMany()
                        .HasForeignKey("AirlineScheduleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.Airport", "Airport_Destination")
                        .WithMany()
                        .HasForeignKey("Airport_DestinationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.Airport", "Airport_Origin")
                        .WithMany()
                        .HasForeignKey("Airport_OriginID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.MaintenanceSchedule", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightOperations.Model.Entity.AircraftMaintenance", "AircraftMaintenance")
                        .WithMany()
                        .HasForeignKey("AircraftMaintenanceID")
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

                    b.HasOne("FlightOperations.Model.Entity.AirlineSchedule", "AirlineSchedule")
                        .WithMany("AircraftTypes")
                        .HasForeignKey("Airline_ScheduleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightOperations.Model.Entity.ScheduleResource", b =>
                {
                    b.HasOne("FlightOperations.Model.Entity.AirlineSchedule", "AirlineSchedule")
                        .WithMany("ScheduleResources")
                        .HasForeignKey("AirlineScheduleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
