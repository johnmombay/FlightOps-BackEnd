using FlightOperations.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model
{
    public class FlightOperationsContext : DbContext
    {
        public FlightOperationsContext(DbContextOptions<FlightOperationsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>()
                .HasOne(a => a.AircraftType)
                .WithMany()
                .HasForeignKey(f => f.AircraftTypeId);
            
            modelBuilder.Entity<Aircraft>()
                .HasOne(a => a.Country)
                .WithMany()
                .HasForeignKey(f => f.CountryOfRegistration);

            modelBuilder.Entity<Airport>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(f => f.CityId);


            modelBuilder.Entity<City>()
                .HasOne(a => a.Country)
                .WithMany()
                .HasForeignKey(f => f.CountryId);

            modelBuilder.Entity<Country>()
                .HasMany(a => a.Cities)
                .WithOne(c => c.Country);
            /*
            modelBuilder.Entity<FlightSchedule>()
                .HasOne(a => a.Route)
                .WithMany()
                .HasForeignKey(f => f.RouteId);
             
            modelBuilder.Entity<Route>()
                .HasOne(a => a.OriginAirport)
                .WithMany()
                .HasForeignKey(f => f.Origin);

            modelBuilder.Entity<Route>()
               .HasOne(a => a.DestinationAirport)
               .WithMany()
               .HasForeignKey(f => f.Destination);
            */
            modelBuilder.Entity<AirlineSchedule>()
                .HasMany(p => p.AircraftTypes)
                .WithOne(s => s.AirlineSchedule);
                /*
            modelBuilder.Entity<Schedule_AircraftType>()
                .HasOne(s => s.AirlineSchedule)
                .WithMany()
                .HasForeignKey(f => f.Airline_ScheduleID);
                */
            modelBuilder.Entity<Schedule_AircraftType>()
                .HasOne(s => s.AircraftType)
                .WithMany()
                .HasForeignKey(f => f.AircraftTypeId);

            modelBuilder.Entity<FlightSchedule>()
               .HasOne(a => a.Airport_Origin)
               .WithMany()
               .HasForeignKey(f => f.Airport_OriginID);

            modelBuilder.Entity<FlightSchedule>()
               .HasOne(a => a.Airport_Destination)
               .WithMany()
               .HasForeignKey(f => f.Airport_DestinationID);

            modelBuilder.Entity<FlightSchedule>()
                .HasOne(a => a.AirlineSchedule)
                .WithMany()
                .HasForeignKey(f => f.AirlineScheduleID);

            modelBuilder.Entity<AircraftMaintenance>()
                .HasOne(a => a.AircraftType)
                .WithMany()
                .HasForeignKey(f => f.AircraftTypeID);

            modelBuilder.Entity<MaintenanceSchedule>()
                .HasOne(a => a.AircraftMaintenance)
                .WithMany()
                .HasForeignKey(f => f.AircraftMaintenanceID);

            modelBuilder.Entity<MaintenanceSchedule>()
               .HasOne(a => a.Aircraft)
               .WithMany()
               .HasForeignKey(f => f.AircraftID);

            modelBuilder.Entity<AircraftSchedule>()
                .HasOne(a => a.Aircraft)
                .WithMany()
                .HasForeignKey(f => f.AircraftID);

            modelBuilder.Entity<AirlineSchedule>()
                .HasMany(s => s.ScheduleResources)
                .WithOne(a => a.AirlineSchedule);

            modelBuilder.Entity<Crew>()
                .HasOne(c => c.CrewPosition)
                .WithMany()
                .HasForeignKey(a => a.CrewPositionID);

            modelBuilder.Entity<CrewSchedule>()
                .HasOne(c => c.Crew)
                .WithMany()
                .HasForeignKey(a => a.CrewID);
        }
        #region context
        public DbSet<Aircraft> Aircrafts {get;set;}
        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<AirportCategory> AirportCategories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FlightSchedule> FlightSchedules { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AirlineSchedule> AirlineSchedules { get; set; }
        public DbSet<Schedule_AircraftType> Schedule_AircraftTypes { get; set; }
        public DbSet<AircraftMaintenance> AircraftMaintenances { get; set; }
        public DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public DbSet<AircraftSchedule> AircraftSchedules { get; set; }
        public DbSet<ScheduleResource> ScheduleResources { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<CrewPosition> CrewPositions { get; set; }
        public DbSet<CrewSchedule> CrewSchedules { get; set; }
        #endregion 
    }
}
