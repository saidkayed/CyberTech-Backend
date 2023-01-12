using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberTechBackend.Migrations
{
    /// <inheritdoc />
    public partial class initModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fire = table.Column<double>(type: "float", nullable: false),
                    Water = table.Column<double>(type: "float", nullable: false),
                    Grass = table.Column<double>(type: "float", nullable: false),
                    Electric = table.Column<double>(type: "float", nullable: false),
                    Ice = table.Column<double>(type: "float", nullable: false),
                    Fighting = table.Column<double>(type: "float", nullable: false),
                    Poison = table.Column<double>(type: "float", nullable: false),
                    Ground = table.Column<double>(type: "float", nullable: false),
                    Flying = table.Column<double>(type: "float", nullable: false),
                    Psychic = table.Column<double>(type: "float", nullable: false),
                    Bug = table.Column<double>(type: "float", nullable: false),
                    Rock = table.Column<double>(type: "float", nullable: false),
                    Ghost = table.Column<double>(type: "float", nullable: false),
                    Dragon = table.Column<double>(type: "float", nullable: false),
                    Dark = table.Column<double>(type: "float", nullable: false),
                    Steel = table.Column<double>(type: "float", nullable: false),
                    Fairy = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CyberTech",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    SpecialAttack = table.Column<int>(type: "int", nullable: false),
                    SpecialDefense = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyberTech", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CyberTech_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Move",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    PP = table.Column<int>(type: "int", nullable: false),
                    Physical = table.Column<bool>(type: "bit", nullable: false),
                    Special = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CyberTechId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Move", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Move_CyberTech_CyberTechId",
                        column: x => x.CyberTechId,
                        principalTable: "CyberTech",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Move_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CyberTech_TypeId",
                table: "CyberTech",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Move_CyberTechId",
                table: "Move",
                column: "CyberTechId");

            migrationBuilder.CreateIndex(
                name: "IX_Move_TypeId",
                table: "Move",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Move");

            migrationBuilder.DropTable(
                name: "CyberTech");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
