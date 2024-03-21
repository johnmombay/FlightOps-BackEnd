using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class MaintenanceChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_AirportCategories_AirportCategoryId",
                table: "Aircrafts");

            migrationBuilder.DropIndex(
                name: "IX_Aircrafts_AirportCategoryId",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "AirportCategoryId",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "MaximumFlightHours",
                table: "Aircrafts");

            migrationBuilder.RenameColumn(
                name: "Frequency",
                table: "MaintenanceSchedules",
                newName: "ResourceID");

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "MaintenanceSchedules",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "MaintenanceSchedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MaintenanceDate",
                table: "MaintenanceSchedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "MaintenanceSchedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryNumber",
                table: "AirportCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaximumFlightHours",
                table: "AircraftTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "AircraftMaintenances",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "MaintenanceDate",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "MaximumFlightHours",
                table: "AircraftTypes");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "AircraftMaintenances");

            migrationBuilder.RenameColumn(
                name: "ResourceID",
                table: "MaintenanceSchedules",
                newName: "Frequency");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryNumber",
                table: "AirportCategories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AirportCategoryId",
                table: "Aircrafts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaximumFlightHours",
                table: "Aircrafts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AirportCategoryId",
                table: "Aircrafts",
                column: "AirportCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_AirportCategories_AirportCategoryId",
                table: "Aircrafts",
                column: "AirportCategoryId",
                principalTable: "AirportCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
