using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class newFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OperationFrom",
                table: "Airports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OperationTo",
                table: "Airports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PCN",
                table: "Airports",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPublished",
                table: "AirlineSchedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ACN",
                table: "AircraftTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryNumber",
                table: "AircraftTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationFrom",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "OperationTo",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "PCN",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "isPublished",
                table: "AirlineSchedules");

            migrationBuilder.DropColumn(
                name: "ACN",
                table: "AircraftTypes");

            migrationBuilder.DropColumn(
                name: "CategoryNumber",
                table: "AircraftTypes");
        }
    }
}
