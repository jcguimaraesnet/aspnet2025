using GuimasBurguerAppWeb.Services.Memory;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicialMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var service = new HamburguerService();
            var context = new HamburguerDbContext();
            context.Marca.AddRange(service.ObterTodasMarcas());
            context.SaveChanges();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
