using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vetKado.Migrations
{
    /// <inheritdoc />
    public partial class vaccine1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccine_Pets_PetId",
                table: "Vaccine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccine",
                table: "Vaccine");

            migrationBuilder.RenameTable(
                name: "Vaccine",
                newName: "Vaccines");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccine_PetId",
                table: "Vaccines",
                newName: "IX_Vaccines_PetId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VaccineTime",
                table: "Vaccines",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccines",
                table: "Vaccines",
                column: "VaccineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Pets_PetId",
                table: "Vaccines",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Pets_PetId",
                table: "Vaccines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccines",
                table: "Vaccines");

            migrationBuilder.RenameTable(
                name: "Vaccines",
                newName: "Vaccine");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccines_PetId",
                table: "Vaccine",
                newName: "IX_Vaccine_PetId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VaccineTime",
                table: "Vaccine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccine",
                table: "Vaccine",
                column: "VaccineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccine_Pets_PetId",
                table: "Vaccine",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
