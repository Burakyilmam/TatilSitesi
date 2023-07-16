using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TatilSitesi.Migrations
{
    public partial class m123456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LobyBar",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LobyBar",
                table: "HotelDetails");
        }
    }
}
