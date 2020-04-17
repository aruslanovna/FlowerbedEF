using Microsoft.EntityFrameworkCore.Migrations;

namespace Floberbed.Migrations
{
    public partial class FlowerFamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Plantations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plantations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flowers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlowerFamily",
                table: "Flowers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowerFamily",
                table: "Flowers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Plantations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plantations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
