using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class flightOpsAndMaintenance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Assigned",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MinimumGroundTime",
                table: "Airports",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StandardGroundTime",
                table: "Airports",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "AircraftScheduleID",
                table: "Aircrafts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlightScheduleID",
                table: "Aircrafts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AircraftMaintenances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    MaintenanceCode = table.Column<string>(nullable: true),
                    MaintenanceName = table.Column<string>(nullable: true),
                    Duration = table.Column<double>(nullable: false),
                    AircraftTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftMaintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AircraftMaintenances_AircraftTypes_AircraftTypeID",
                        column: x => x.AircraftTypeID,
                        principalTable: "AircraftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AircraftSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    FlightScheduleId = table.Column<int>(nullable: false),
                    AircraftID = table.Column<int>(nullable: false),
                    ASTD = table.Column<DateTime>(nullable: false),
                    ASTA = table.Column<DateTime>(nullable: false),
                    ATD = table.Column<DateTime>(nullable: true),
                    ATA = table.Column<DateTime>(nullable: true),
                    AdultPAX = table.Column<int>(nullable: false),
                    ChildPAX = table.Column<int>(nullable: false),
                    Cargo = table.Column<int>(nullable: false),
                    AircraftFlightDate = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AircraftSchedules_Aircrafts_AircraftID",
                        column: x => x.AircraftID,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AircraftSchedules_FlightSchedules_FlightScheduleId",
                        column: x => x.FlightScheduleId,
                        principalTable: "FlightSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    AircraftMaintenanceID = table.Column<int>(nullable: false),
                    AircraftID = table.Column<int>(nullable: false),
                    scheduleFrom = table.Column<DateTime>(nullable: false),
                    scheduleTo = table.Column<DateTime>(nullable: false),
                    Frequency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceSchedules_Aircrafts_AircraftID",
                        column: x => x.AircraftID,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceSchedules_AircraftMaintenances_AircraftMaintenanceID",
                        column: x => x.AircraftMaintenanceID,
                        principalTable: "AircraftMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AircraftMaintenances_AircraftTypeID",
                table: "AircraftMaintenances",
                column: "AircraftTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftSchedules_AircraftID",
                table: "AircraftSchedules",
                column: "AircraftID");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftSchedules_FlightScheduleId",
                table: "AircraftSchedules",
                column: "FlightScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_AircraftID",
                table: "MaintenanceSchedules",
                column: "AircraftID");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_AircraftMaintenanceID",
                table: "MaintenanceSchedules",
                column: "AircraftMaintenanceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftSchedules");

            migrationBuilder.DropTable(
                name: "MaintenanceSchedules");

            migrationBuilder.DropTable(
                name: "AircraftMaintenances");

            migrationBuilder.DropColumn(
                name: "Assigned",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "MinimumGroundTime",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "StandardGroundTime",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "AircraftScheduleID",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "FlightScheduleID",
                table: "Aircrafts");
        }
    }
}
