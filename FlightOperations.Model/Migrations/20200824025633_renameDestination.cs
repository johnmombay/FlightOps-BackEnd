using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class renameDestination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightSchedules_Airports_Airport_DesitinationID",
                table: "FlightSchedules");

            migrationBuilder.DropIndex(
                name: "IX_FlightSchedules_Airport_DesitinationID",
                table: "FlightSchedules");

            migrationBuilder.RenameColumn(
                name: "Airport_DesitinationID",
                table: "FlightSchedules",
                newName: "resourceId");

            migrationBuilder.AddColumn<int>(
                name: "Airport_DestinationID",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "FlightHours",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ReturnFlightNumber",
                table: "FlightSchedules",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TripHours",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "groundTime",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "isReturn",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_FlightSchedules_Airport_DestinationID",
                table: "FlightSchedules",
                column: "Airport_DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightSchedules_Airports_Airport_DestinationID",
                table: "FlightSchedules",
                column: "Airport_DestinationID",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightSchedules_Airports_Airport_DestinationID",
                table: "FlightSchedules");

            migrationBuilder.DropIndex(
                name: "IX_FlightSchedules_Airport_DestinationID",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "Airport_DestinationID",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "FlightHours",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "ReturnFlightNumber",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "TripHours",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "groundTime",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "isReturn",
                table: "FlightSchedules");

            migrationBuilder.RenameColumn(
                name: "resourceId",
                table: "FlightSchedules",
                newName: "Airport_DesitinationID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSchedules_Airport_DesitinationID",
                table: "FlightSchedules",
                column: "Airport_DesitinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightSchedules_Airports_Airport_DesitinationID",
                table: "FlightSchedules",
                column: "Airport_DesitinationID",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
