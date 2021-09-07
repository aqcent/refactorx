using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace refactorx.Migrations
{
    public partial class enable_applications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchBankID = table.Column<int>(type: "int", nullable: false),
                    CreditManagerID = table.Column<int>(type: "int", nullable: true),
                    ApplicantID = table.Column<int>(type: "int", nullable: false),
                    CreditType = table.Column<int>(type: "int", nullable: false),
                    RequestedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestedCurrencyID = table.Column<int>(type: "int", nullable: false),
                    AnnualSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Applications_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_BranchBanks_BranchBankID",
                        column: x => x.BranchBankID,
                        principalTable: "BranchBanks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_CreditManagers_CreditManagerID",
                        column: x => x.CreditManagerID,
                        principalTable: "CreditManagers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Currencies_RequestedCurrencyID",
                        column: x => x.RequestedCurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantID",
                table: "Applications",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_BranchBankID",
                table: "Applications",
                column: "BranchBankID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CreditManagerID",
                table: "Applications",
                column: "CreditManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_RequestedCurrencyID",
                table: "Applications",
                column: "RequestedCurrencyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
