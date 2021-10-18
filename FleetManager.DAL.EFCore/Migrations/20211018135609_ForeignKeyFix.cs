using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManager.EFCore.Migrations
{
    public partial class ForeignKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "RepareId",
                table: "Appeals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "Appeals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_MaintenanceId",
                table: "Appeals",
                column: "MaintenanceId",
                unique: true,
                filter: "[MaintenanceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_RepareId",
                table: "Appeals",
                column: "RepareId",
                unique: true,
                filter: "[RepareId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Administration_MaintenanceId",
                table: "Appeals",
                column: "MaintenanceId",
                principalTable: "Administration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Administration_RepareId",
                table: "Appeals",
                column: "RepareId",
                principalTable: "Administration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.AlterColumn<int>(
                name: "RepareId",
                table: "Appeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "Appeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Administration_RepareId",
                table: "Appeals",
                column: "RepareId",
                principalTable: "Administration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
