using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class RequestAdoption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "RequestAdoption",
                schema: "dbo",
                columns: table => new
                {
                    RequestAdoptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPets = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    ProfileHouseId = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeAlone = table.Column<int>(type: "int", nullable: false),
                    WhatPet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Why = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAdoption", x => x.RequestAdoptionId);
                    table.ForeignKey(
                        name: "FK_RequestAdoption_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId");
                    table.ForeignKey(
                        name: "FK_RequestAdoption_ProfileHouses_ProfileHouseId",
                        column: x => x.ProfileHouseId,
                        principalTable: "ProfileHouses",
                        principalColumn: "ProfileHouseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestAdoption_PetId",
                schema: "dbo",
                table: "RequestAdoption",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestAdoption_ProfileHouseId",
                schema: "dbo",
                table: "RequestAdoption",
                column: "ProfileHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestAdoption",
                schema: "dbo");
        }
    }
}
