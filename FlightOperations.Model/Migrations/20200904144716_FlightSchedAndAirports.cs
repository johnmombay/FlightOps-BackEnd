using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class FlightSchedAndAirports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports_AirportCategories_AirportCategoryId",
                table: "Airports");

            migrationBuilder.DropIndex(
                name: "IX_Airports_AirportCategoryId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "FlightHours",
                table: "FlightSchedules");

            migrationBuilder.RenameColumn(
                name: "groundTime",
                table: "FlightSchedules",
                newName: "FlyingHours");

            migrationBuilder.RenameColumn(
                name: "ValidTo",
                table: "FlightSchedules",
                newName: "STD");

            migrationBuilder.RenameColumn(
                name: "ValidFrom",
                table: "FlightSchedules",
                newName: "STA");

            migrationBuilder.RenameColumn(
                name: "TripHours",
                table: "FlightSchedules",
                newName: "BlockTime");

            migrationBuilder.RenameColumn(
                name: "ReturnFlightNumber",
                table: "FlightSchedules",
                newName: "OutboundFlightNo");

            migrationBuilder.RenameColumn(
                name: "FlightNumber",
                table: "FlightSchedules",
                newName: "InboundFlightNo");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "FlightSchedules",
                newName: "PeriodTo");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "FlightSchedules",
                newName: "PeriodFrom");

            migrationBuilder.RenameColumn(
                name: "AirportCategoryId",
                table: "Airports",
                newName: "AirportCategory");

            migrationBuilder.AddColumn<int>(
                name: "AircraftTypeID",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FlightNo",
                table: "FlightSchedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleResources_AirlineScheduleID",
                table: "ScheduleResources",
                column: "AirlineScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleResources_AirlineSchedules_AirlineScheduleID",
                table: "ScheduleResources",
                column: "AirlineScheduleID",
                principalTable: "AirlineSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleResources_AirlineSchedules_AirlineScheduleID",
                table: "ScheduleResources");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleResources_AirlineScheduleID",
                table: "ScheduleResources");

            migrationBuilder.DropColumn(
                name: "AircraftTypeID",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "FlightNo",
                table: "FlightSchedules");

            migrationBuilder.RenameColumn(
                name: "STD",
                table: "FlightSchedules",
                newName: "ValidTo");

            migrationBuilder.RenameColumn(
                name: "STA",
                table: "FlightSchedules",
                newName: "ValidFrom");

            migrationBuilder.RenameColumn(
                name: "PeriodTo",
                table: "FlightSchedules",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "PeriodFrom",
                table: "FlightSchedules",
                newName: "ArrivalTime");

            migrationBuilder.RenameColumn(
                name: "OutboundFlightNo",
                table: "FlightSchedules",
                newName: "ReturnFlightNumber");

            migrationBuilder.RenameColumn(
                name: "InboundFlightNo",
                table: "FlightSchedules",
                newName: "FlightNumber");

            migrationBuilder.RenameColumn(
                name: "FlyingHours",
                table: "FlightSchedules",
                newName: "groundTime");

            migrationBuilder.RenameColumn(
                name: "BlockTime",
                table: "FlightSchedules",
                newName: "TripHours");

            migrationBuilder.RenameColumn(
                name: "AirportCategory",
                table: "Airports",
                newName: "AirportCategoryId");

            migrationBuilder.AddColumn<double>(
                name: "FlightHours",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Airports_AirportCategoryId",
                table: "Airports",
                column: "AirportCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_AirportCategories_AirportCategoryId",
                table: "Airports",
                column: "AirportCategoryId",
                principalTable: "AirportCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
