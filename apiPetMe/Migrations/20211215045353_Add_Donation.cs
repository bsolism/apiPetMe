using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class Add_Donation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donation",
                schema: "dbo",
                columns: table => new
                {
                    DonationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfileHouseId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.DonationId);
                    table.ForeignKey(
                        name: "FK_Donation_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId");
                    table.ForeignKey(
                        name: "FK_Donation_ProfileHouses_ProfileHouseId",
                        column: x => x.ProfileHouseId,
                        principalTable: "ProfileHouses",
                        principalColumn: "ProfileHouseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donation_PetId",
                schema: "dbo",
                table: "Donation",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_ProfileHouseId",
                schema: "dbo",
                table: "Donation",
                column: "ProfileHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donation",
                schema: "dbo");
        }
    }
}
