using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP24Test.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Reference = table.Column<Guid>(type: "TEXT", nullable: false),
                    CurrencyCode = table.Column<string>(type: "TEXT", nullable: false),
                    IssueDate = table.Column<string>(type: "TEXT", nullable: false),
                    OpeningValue = table.Column<double>(type: "REAL", nullable: false),
                    PaidValue = table.Column<double>(type: "REAL", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Cancelled = table.Column<bool>(type: "INTEGER", nullable: false),
                    DebtorName = table.Column<string>(type: "TEXT", nullable: false),
                    DebtorReference = table.Column<string>(type: "TEXT", nullable: false),
                    DebtorAddress1 = table.Column<string>(type: "TEXT", nullable: true),
                    DebtorAddress2 = table.Column<string>(type: "TEXT", nullable: true),
                    DebtorTown = table.Column<string>(type: "TEXT", nullable: true),
                    DebtorState = table.Column<string>(type: "TEXT", nullable: true),
                    DebtorZip = table.Column<string>(type: "TEXT", nullable: true),
                    DebtorCountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    DebtorRegistrationNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Reference);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
