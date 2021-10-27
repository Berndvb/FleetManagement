using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManager.EFCore.Migrations
{
    public partial class _14oktMinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhoneNumber",
                table: "ContactInfo");

            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "ContactInfo",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ContactInfo",
                newName: "TelephoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "CellPhoneNumber",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
