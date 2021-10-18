using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManager.EFCore.Migrations
{
    public partial class Extra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceId",
                table: "Appeals",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RepareId",
                table: "Appeals",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_MaintenanceId",
                table: "Appeals",
                column: "MaintenanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_RepareId",
                table: "Appeals",
                column: "RepareId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Administration_MaintenanceId",
                table: "Appeals",
                column: "MaintenanceId",
                principalTable: "Administration",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Administration_RepareId",
                table: "Appeals",
                column: "RepareId",
                principalTable: "Administration",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Administration_MaintenanceId",
                table: "Appeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Administration_RepareId",
                table: "Appeals");

            migrationBuilder.DropIndex(
                name: "IX_Appeals_MaintenanceId",
                table: "Appeals");

            migrationBuilder.DropIndex(
                name: "IX_Appeals_RepareId",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "MaintenanceId",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "RepareId",
                table: "Appeals");
        }
    }
}
