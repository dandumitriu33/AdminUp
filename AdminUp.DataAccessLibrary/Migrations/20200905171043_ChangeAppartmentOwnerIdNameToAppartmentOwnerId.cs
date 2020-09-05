using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminUp.DataAccessLibrary.Migrations
{
    public partial class ChangeAppartmentOwnerIdNameToAppartmentOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Appartments");

            migrationBuilder.AddColumn<string>(
                name: "AppartmentOwnerId",
                table: "Appartments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppartmentOwnerId",
                table: "Appartments");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
