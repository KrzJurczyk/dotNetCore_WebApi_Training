using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRooms_REST_EF.Migrations
{
    public partial class modelrefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Rooms");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CheckIn",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckOut",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
