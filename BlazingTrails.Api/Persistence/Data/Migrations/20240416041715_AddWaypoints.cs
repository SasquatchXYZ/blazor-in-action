using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingTrails.Api.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWaypoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage",
                table: "RouteInstructions");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "RouteInstructions",
                newName: "Longitude");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "RouteInstructions",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "RouteInstructions");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "RouteInstructions",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Stage",
                table: "RouteInstructions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
