using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Floberbed.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "WarehouseFlowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlowerId",
                table: "WarehouseFlowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "WarehouseFlowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "SupplyFlowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlowerId",
                table: "SupplyFlowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplyId",
                table: "SupplyFlowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "Supplies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PlantationId",
                table: "Supplies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "Supplies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Supplies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Supplies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlowerId",
                table: "plantationFlowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlantationId",
                table: "plantationFlowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseFlowers_FlowerId",
                table: "WarehouseFlowers",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseFlowers_WarehouseId",
                table: "WarehouseFlowers",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyFlowers_FlowerId",
                table: "SupplyFlowers",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyFlowers_SupplyId",
                table: "SupplyFlowers",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_PlantationId",
                table: "Supplies",
                column: "PlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_WarehouseId",
                table: "Supplies",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_plantationFlowers_FlowerId",
                table: "plantationFlowers",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_plantationFlowers_PlantationId",
                table: "plantationFlowers",
                column: "PlantationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Plantations_PlantationId",
                table: "Supplies",
                column: "PlantationId",
                principalTable: "Plantations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Warehouses_WarehouseId",
                table: "Supplies",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyFlowers_Flowers_FlowerId",
                table: "SupplyFlowers",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyFlowers_Supplies_SupplyId",
                table: "SupplyFlowers",
                column: "SupplyId",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseFlowers_Flowers_FlowerId",
                table: "WarehouseFlowers",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseFlowers_Warehouses_WarehouseId",
                table: "WarehouseFlowers",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plantationFlowers_Flowers_FlowerId",
                table: "plantationFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_plantationFlowers_Plantations_PlantationId",
                table: "plantationFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Plantations_PlantationId",
                table: "Supplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Warehouses_WarehouseId",
                table: "Supplies");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyFlowers_Flowers_FlowerId",
                table: "SupplyFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyFlowers_Supplies_SupplyId",
                table: "SupplyFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseFlowers_Flowers_FlowerId",
                table: "WarehouseFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseFlowers_Warehouses_WarehouseId",
                table: "WarehouseFlowers");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseFlowers_FlowerId",
                table: "WarehouseFlowers");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseFlowers_WarehouseId",
                table: "WarehouseFlowers");

            migrationBuilder.DropIndex(
                name: "IX_SupplyFlowers_FlowerId",
                table: "SupplyFlowers");

            migrationBuilder.DropIndex(
                name: "IX_SupplyFlowers_SupplyId",
                table: "SupplyFlowers");

            migrationBuilder.DropIndex(
                name: "IX_Supplies_PlantationId",
                table: "Supplies");

            migrationBuilder.DropIndex(
                name: "IX_Supplies_WarehouseId",
                table: "Supplies");

            migrationBuilder.DropIndex(
                name: "IX_plantationFlowers_FlowerId",
                table: "plantationFlowers");

            migrationBuilder.DropIndex(
                name: "IX_plantationFlowers_PlantationId",
                table: "plantationFlowers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "WarehouseFlowers");

            migrationBuilder.DropColumn(
                name: "FlowerId",
                table: "WarehouseFlowers");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "WarehouseFlowers");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SupplyFlowers");

            migrationBuilder.DropColumn(
                name: "FlowerId",
                table: "SupplyFlowers");

            migrationBuilder.DropColumn(
                name: "SupplyId",
                table: "SupplyFlowers");

            migrationBuilder.DropColumn(
                name: "ClosedDate",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "PlantationId",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "FlowerId",
                table: "plantationFlowers");

            migrationBuilder.DropColumn(
                name: "PlantationId",
                table: "plantationFlowers");
        }
    }
}
