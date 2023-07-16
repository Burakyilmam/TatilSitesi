using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TatilSitesi.Migrations
{
    public partial class m12345678 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HotelRoomFinishDate",
                table: "HotelRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HotelRoomStartDate",
                table: "HotelRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelRoomFinishDate",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "HotelRoomStartDate",
                table: "HotelRooms");
        }
    }
}
