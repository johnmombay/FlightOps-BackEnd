using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class CrewsAndPlanning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrewPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    PositionName = table.Column<string>(nullable: true),
                    PositionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    PassportNo = table.Column<string>(nullable: true),
                    PassportExpiryDate = table.Column<DateTime>(nullable: false),
                    CrewPositionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crews_CrewPositions_CrewPositionID",
                        column: x => x.CrewPositionID,
                        principalTable: "CrewPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrewSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    FlightScheduleID = table.Column<int>(nullable: false),
                    AircraftScheduleID = table.Column<int>(nullable: false),
                    ResourceID = table.Column<int>(nullable: false),
                    AirlineScheduleID = table.Column<int>(nullable: false),
                    CrewID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewSchedules_AircraftSchedules_AircraftScheduleID",
                        column: x => x.AircraftScheduleID,
                        principalTable: "AircraftSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrewSchedules_AirlineSchedules_AirlineScheduleID",
                        column: x => x.AirlineScheduleID,
                        principalTable: "AirlineSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrewSchedules_Crews_CrewID",
                        column: x => x.CrewID,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrewSchedules_FlightSchedules_FlightScheduleID",
                        column: x => x.FlightScheduleID,
                        principalTable: "FlightSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CrewPositionID",
                table: "Crews",
                column: "CrewPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSchedules_AircraftScheduleID",
                table: "CrewSchedules",
                column: "AircraftScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSchedules_AirlineScheduleID",
                table: "CrewSchedules",
                column: "AirlineScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSchedules_CrewID",
                table: "CrewSchedules",
                column: "CrewID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSchedules_FlightScheduleID",
                table: "CrewSchedules",
                column: "FlightScheduleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrewSchedules");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "CrewPositions");
        }
    }
}
