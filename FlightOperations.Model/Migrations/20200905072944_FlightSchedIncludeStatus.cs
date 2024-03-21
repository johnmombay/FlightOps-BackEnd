using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightOperations.Model.Migrations
{
    public partial class FlightSchedIncludeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assigned",
                table: "FlightSchedules");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "FlightSchedules");

            migrationBuilder.AddColumn<bool>(
                name: "Assigned",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: false);
        }
    }
}
