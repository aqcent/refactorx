using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace refactorx.Migrations
{
    public partial class scoring_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationNum",
                table: "Applications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScoringDate",
                table: "Applications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ScoringStatus",
                table: "Applications",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationNum",
                table: "Applications",
                column: "ApplicationNum",
                unique: true,
                filter: "[ApplicationNum] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationNum",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ScoringDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ScoringStatus",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationNum",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
