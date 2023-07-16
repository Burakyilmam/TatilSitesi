using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TatilSitesi.Migrations
{
    public partial class m1234567 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Basketball",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CarPark",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChildPark",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Football",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Basketball",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "CarPark",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "ChildPark",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Football",
                table: "HotelDetails");
        }
    }
}
