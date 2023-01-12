using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberTechBackend.Migrations
{
    /// <inheritdoc />
    public partial class TypeModelFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bug",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Dark",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Dragon",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Electric",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Fairy",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Fighting",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Fire",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Flying",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Ghost",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Grass",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Ground",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Ice",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Poison",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Psychic",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Rock",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Steel",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Water",
                table: "Type");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Type",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Type");

            migrationBuilder.AddColumn<double>(
                name: "Bug",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Dark",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Dragon",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Electric",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fairy",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fighting",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fire",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Flying",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Ghost",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Grass",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Ground",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Ice",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Type",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Poison",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Psychic",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rock",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Steel",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Water",
                table: "Type",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
