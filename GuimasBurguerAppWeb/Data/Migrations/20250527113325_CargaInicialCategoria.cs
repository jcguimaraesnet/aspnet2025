using GuimasBurguerAppWeb.Services.Memory;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicialCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var service = new HamburguerService();
            var context = new HamburguerDbContext();
            context.Categoria.AddRange(service.ObterTodasCategorias());
            context.SaveChanges();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
