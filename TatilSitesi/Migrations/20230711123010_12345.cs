using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TatilSitesi.Migrations
{
    public partial class _12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelRating",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotelStar",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelRating",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelStar",
                table: "Hotels");
        }
    }
}
