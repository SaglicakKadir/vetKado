using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vetKado.Migrations
{
    /// <inheritdoc />
    public partial class vaccine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccine",
                columns: table => new
                {
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccineDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccineTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccine", x => x.VaccineId);
                    table.ForeignKey(
                        name: "FK_Vaccine_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_PetId",
                table: "Vaccine",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccine");
        }
    }
}
