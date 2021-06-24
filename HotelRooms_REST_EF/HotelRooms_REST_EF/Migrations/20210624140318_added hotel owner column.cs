using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRooms_REST_EF.Migrations
{
    public partial class addedhotelownercolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Hotels");
        }
    }
}
