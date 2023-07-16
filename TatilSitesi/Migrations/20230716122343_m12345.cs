using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TatilSitesi.Migrations
{
    public partial class m12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelAddres",
                table: "Hotels",
                newName: "HotelAddress");

            migrationBuilder.AlterColumn<bool>(
                name: "GameRoom",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Disco",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Animation",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "AirConditioning",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AquaPark",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Balcony",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Bath",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Beach",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IndoorPool",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IndoorRestaurant",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Internet",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Massage",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Minibar",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OutdoorPool",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OutdoorRestaurant",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RoomService",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sauna",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shower",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sunbed",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TV",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TableTennis",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Volleyball",
                table: "HotelDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirConditioning",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "AquaPark",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Balcony",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Bath",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Beach",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "IndoorPool",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "IndoorRestaurant",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Internet",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Massage",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Minibar",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "OutdoorPool",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "OutdoorRestaurant",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "RoomService",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Sauna",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Shower",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Sunbed",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "TV",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "TableTennis",
                table: "HotelDetails");

            migrationBuilder.DropColumn(
                name: "Volleyball",
                table: "HotelDetails");

            migrationBuilder.RenameColumn(
                name: "HotelAddress",
                table: "Hotels",
                newName: "HotelAddres");

            migrationBuilder.AlterColumn<string>(
                name: "GameRoom",
                table: "HotelDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Disco",
                table: "HotelDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Animation",
                table: "HotelDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
