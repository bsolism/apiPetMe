using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class Relation_RequestAdoption_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "RequestAdoptions",
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
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    ProfileHouseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeAlone = table.Column<int>(type: "int", nullable: false),
                    WhatPet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Why = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAdoptions", x => x.RequestAdoptionId);
                    table.ForeignKey(
                        name: "FK_RequestAdoptions_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId");
                    table.ForeignKey(
                        name: "FK_RequestAdoptions_ProfileHouses_ProfileHouseId",
                        column: x => x.ProfileHouseId,
                        principalTable: "ProfileHouses",
                        principalColumn: "ProfileHouseId");
                    table.ForeignKey(
                        name: "FK_RequestAdoptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestAdoptions_PetId",
                schema: "dbo",
                table: "RequestAdoptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestAdoptions_ProfileHouseId",
                schema: "dbo",
                table: "RequestAdoptions",
                column: "ProfileHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestAdoptions_UserId",
                schema: "dbo",
                table: "RequestAdoptions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestAdoptions",
                schema: "dbo");
        }
    }
}
