using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManager.EFCore.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Administration",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administration_DriverId",
                table: "Administration",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administration_Drivers_DriverId",
                table: "Administration",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administration_Drivers_DriverId",
                table: "Administration");

            migrationBuilder.DropIndex(
                name: "IX_Administration_DriverId",
                table: "Administration");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Administration");
        }
    }
}
