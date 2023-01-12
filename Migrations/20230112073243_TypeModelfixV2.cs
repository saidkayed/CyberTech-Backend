using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberTechBackend.Migrations
{
    /// <inheritdoc />
    public partial class TypeModelfixV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Type",
                newName: "TypeEnum");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Type",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TypeType",
                columns: table => new
                {
                    StrongAgainstId = table.Column<int>(type: "int", nullable: false),
                    WeakAgainstId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeType", x => new { x.StrongAgainstId, x.WeakAgainstId });
                    table.ForeignKey(
                        name: "FK_TypeType_Type_StrongAgainstId",
                        column: x => x.StrongAgainstId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeType_Type_WeakAgainstId",
                        column: x => x.WeakAgainstId,
                        principalTable: "Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeType_WeakAgainstId",
                table: "TypeType",
                column: "WeakAgainstId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeType");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Type");

            migrationBuilder.RenameColumn(
                name: "TypeEnum",
                table: "Type",
                newName: "Type");
        }
    }
}
