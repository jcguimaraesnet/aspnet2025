using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacaoHamburguerCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaHamburguer",
                columns: table => new
                {
                    CategoriasCategoriaId = table.Column<int>(type: "int", nullable: false),
                    HamburguersHamburguerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaHamburguer", x => new { x.CategoriasCategoriaId, x.HamburguersHamburguerId });
                    table.ForeignKey(
                        name: "FK_CategoriaHamburguer_Categoria_CategoriasCategoriaId",
                        column: x => x.CategoriasCategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaHamburguer_Hamburguer_HamburguersHamburguerId",
                        column: x => x.HamburguersHamburguerId,
                        principalTable: "Hamburguer",
                        principalColumn: "HamburguerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaHamburguer_HamburguersHamburguerId",
                table: "CategoriaHamburguer",
                column: "HamburguersHamburguerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaHamburguer");
        }
    }
}
