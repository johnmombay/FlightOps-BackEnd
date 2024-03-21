using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class FlightOps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    AircraftTypeName = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirlineSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    ScheduleName = table.Column<string>(nullable: true),
                    PeriodFrom = table.Column<DateTime>(nullable: false),
                    PeriodTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    CategoryNumber = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PasswordAttempt = table.Column<int>(nullable: false),
                    IsLockedOut = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule_AircraftTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    Airline_ScheduleID = table.Column<int>(nullable: false),
                    AircraftTypeId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    AirlineScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule_AircraftTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_AircraftTypes_AircraftTypes_AircraftTypeId",
                        column: x => x.AircraftTypeId,
                        principalTable: "AircraftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_AircraftTypes_AirlineSchedules_AirlineScheduleId",
                        column: x => x.AirlineScheduleId,
                        principalTable: "AirlineSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_AircraftTypes_AirlineSchedules_Airline_ScheduleID",
                        column: x => x.Airline_ScheduleID,
                        principalTable: "AirlineSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    AircraftTypeId = table.Column<int>(nullable: false),
                    FirstCapacity = table.Column<int>(nullable: false),
                    BusinessCapacity = table.Column<int>(nullable: false),
                    PeconomyCapacity = table.Column<int>(nullable: false),
                    EconomyCapacity = table.Column<int>(nullable: false),
                    CargoCapacity = table.Column<int>(nullable: false),
                    Registration = table.Column<string>(nullable: true),
                    CountryOfRegistration = table.Column<int>(nullable: false),
                    DateOfRegistration = table.Column<DateTime>(nullable: false),
                    AirportCategoryId = table.Column<int>(nullable: false),
                    MaximumFlightHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircrafts_AircraftTypes_AircraftTypeId",
                        column: x => x.AircraftTypeId,
                        principalTable: "AircraftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aircrafts_AirportCategories_AirportCategoryId",
                        column: x => x.AirportCategoryId,
                        principalTable: "AirportCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aircrafts_Countries_CountryOfRegistration",
                        column: x => x.CountryOfRegistration,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    CityCode = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    AirportName = table.Column<string>(nullable: true),
                    ICAO_Code = table.Column<string>(nullable: true),
                    IATA_Code = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AirportCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airports_AirportCategories_AirportCategoryId",
                        column: x => x.AirportCategoryId,
                        principalTable: "AirportCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Airports_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    FlightNumber = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    AirlineScheduleID = table.Column<int>(nullable: false),
                    FlightDate = table.Column<DateTime>(nullable: false),
                    Airport_OriginID = table.Column<int>(nullable: false),
                    Airport_DesitinationID = table.Column<int>(nullable: false),
                    Days = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSchedules_AirlineSchedules_AirlineScheduleID",
                        column: x => x.AirlineScheduleID,
                        principalTable: "AirlineSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FlightSchedules_Airports_Airport_DesitinationID",
                        column: x => x.Airport_DesitinationID,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FlightSchedules_Airports_Airport_OriginID",
                        column: x => x.Airport_OriginID,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Origin = table.Column<int>(nullable: false),
                    Destination = table.Column<int>(nullable: false),
                    TripHours = table.Column<double>(nullable: false),
                    FlightHours = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Airports_Destination",
                        column: x => x.Destination,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Routes_Airports_Origin",
                        column: x => x.Origin,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AircraftTypeId",
                table: "Aircrafts",
                column: "AircraftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AirportCategoryId",
                table: "Aircrafts",
                column: "AirportCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_CountryOfRegistration",
                table: "Aircrafts",
                column: "CountryOfRegistration");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_AirportCategoryId",
                table: "Airports",
                column: "AirportCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CityId",
                table: "Airports",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSchedules_AirlineScheduleID",
                table: "FlightSchedules",
                column: "AirlineScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSchedules_Airport_DesitinationID",
                table: "FlightSchedules",
                column: "Airport_DesitinationID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSchedules_Airport_OriginID",
                table: "FlightSchedules",
                column: "Airport_OriginID");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Destination",
                table: "Routes",
                column: "Destination");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Origin",
                table: "Routes",
                column: "Origin");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_AircraftTypes_AircraftTypeId",
                table: "Schedule_AircraftTypes",
                column: "AircraftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_AircraftTypes_AirlineScheduleId",
                table: "Schedule_AircraftTypes",
                column: "AirlineScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_AircraftTypes_Airline_ScheduleID",
                table: "Schedule_AircraftTypes",
                column: "Airline_ScheduleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "FlightSchedules");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Schedule_AircraftTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "AircraftTypes");

            migrationBuilder.DropTable(
                name: "AirlineSchedules");

            migrationBuilder.DropTable(
                name: "AirportCategories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
