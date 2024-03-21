using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class CrewSchedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewSchedules_AircraftSchedules_AircraftScheduleID",
                table: "CrewSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_CrewSchedules_AirlineSchedules_AirlineScheduleID",
                table: "CrewSchedules");

            migrationBuilder.DropIndex(
                name: "IX_CrewSchedules_AircraftScheduleID",
                table: "CrewSchedules");

            migrationBuilder.DropIndex(
                name: "IX_CrewSchedules_AirlineScheduleID",
                table: "CrewSchedules");

            migrationBuilder.DropColumn(
                name: "AircraftScheduleID",
                table: "CrewSchedules");

            migrationBuilder.DropColumn(
                name: "AirlineScheduleID",
                table: "CrewSchedules");

            migrationBuilder.DropColumn(
                name: "ResourceID",
                table: "CrewSchedules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AircraftScheduleID",
                table: "CrewSchedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AirlineScheduleID",
                table: "CrewSchedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResourceID",
                table: "CrewSchedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CrewSchedules_AircraftScheduleID",
                table: "CrewSchedules",
                column: "AircraftScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSchedules_AirlineScheduleID",
                table: "CrewSchedules",
                column: "AirlineScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewSchedules_AircraftSchedules_AircraftScheduleID",
                table: "CrewSchedules",
                column: "AircraftScheduleID",
                principalTable: "AircraftSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrewSchedules_AirlineSchedules_AirlineScheduleID",
                table: "CrewSchedules",
                column: "AirlineScheduleID",
                principalTable: "AirlineSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
