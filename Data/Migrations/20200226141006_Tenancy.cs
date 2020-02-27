using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Data.Migrations
{
    public partial class Tenancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenancy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(nullable: false),
                    PartyId = table.Column<int>(nullable: false),
                    UnitPriceId = table.Column<int>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(15 ,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenancy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenancy_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tenancy_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tenancy_UnitPrices_UnitPriceId",
                        column: x => x.UnitPriceId,
                        principalTable: "UnitPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenancy_PartyId",
                table: "Tenancy",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenancy_UnitId",
                table: "Tenancy",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenancy_UnitPriceId",
                table: "Tenancy",
                column: "UnitPriceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenancy");
        }
    }
}
