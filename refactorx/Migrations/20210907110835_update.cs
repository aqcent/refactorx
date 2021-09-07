using Microsoft.EntityFrameworkCore.Migrations;

namespace refactorx.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_CreditManagers_CreditManagerID",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CreditManagerID",
                table: "Applications");

            migrationBuilder.AlterColumn<int>(
                name: "CreditManagerID",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreditManagerID",
                table: "Applications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CreditManagerID",
                table: "Applications",
                column: "CreditManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_CreditManagers_CreditManagerID",
                table: "Applications",
                column: "CreditManagerID",
                principalTable: "CreditManagers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
