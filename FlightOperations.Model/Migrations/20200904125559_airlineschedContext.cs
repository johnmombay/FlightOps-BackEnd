using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class airlineschedContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_AircraftTypes_AirlineSchedules_AirlineScheduleId",
                table: "Schedule_AircraftTypes");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_AircraftTypes_AirlineScheduleId",
                table: "Schedule_AircraftTypes");

            migrationBuilder.DropColumn(
                name: "AirlineScheduleId",
                table: "Schedule_AircraftTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirlineScheduleId",
                table: "Schedule_AircraftTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_AircraftTypes_AirlineScheduleId",
                table: "Schedule_AircraftTypes",
                column: "AirlineScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_AircraftTypes_AirlineSchedules_AirlineScheduleId",
                table: "Schedule_AircraftTypes",
                column: "AirlineScheduleId",
                principalTable: "AirlineSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
