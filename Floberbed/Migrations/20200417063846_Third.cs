using Microsoft.EntityFrameworkCore.Migrations;

namespace Floberbed.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plantationFlowers_Flowers_FlowerId",
                table: "plantationFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_plantationFlowers_Plantations_PlantationId",
                table: "plantationFlowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plantationFlowers",
                table: "plantationFlowers");

            migrationBuilder.RenameTable(
                name: "plantationFlowers",
                newName: "PlantationFlowers");

            migrationBuilder.RenameIndex(
                name: "IX_plantationFlowers_PlantationId",
                table: "PlantationFlowers",
                newName: "IX_PlantationFlowers_PlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_plantationFlowers_FlowerId",
                table: "PlantationFlowers",
                newName: "IX_PlantationFlowers_FlowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantationFlowers",
                table: "PlantationFlowers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantationFlowers_Flowers_FlowerId",
                table: "PlantationFlowers",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantationFlowers_Plantations_PlantationId",
                table: "PlantationFlowers",
                column: "PlantationId",
                principalTable: "Plantations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantationFlowers_Flowers_FlowerId",
                table: "PlantationFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantationFlowers_Plantations_PlantationId",
                table: "PlantationFlowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantationFlowers",
                table: "PlantationFlowers");

            migrationBuilder.RenameTable(
                name: "PlantationFlowers",
                newName: "plantationFlowers");

            migrationBuilder.RenameIndex(
                name: "IX_PlantationFlowers_PlantationId",
                table: "plantationFlowers",
                newName: "IX_plantationFlowers_PlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantationFlowers_FlowerId",
                table: "plantationFlowers",
                newName: "IX_plantationFlowers_FlowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plantationFlowers",
                table: "plantationFlowers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_plantationFlowers_Flowers_FlowerId",
                table: "plantationFlowers",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plantationFlowers_Plantations_PlantationId",
                table: "plantationFlowers",
                column: "PlantationId",
                principalTable: "Plantations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
