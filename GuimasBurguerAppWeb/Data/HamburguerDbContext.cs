using GuimasBurguerAppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GuimasBurguerAppWeb.Data;

public class HamburguerDbContext : DbContext
{
    public DbSet<Hamburguer> Hamburguer { get; set; }
    //public DbSet<Ingrediente> Ingrediente { get; set; }

    protected override void OnConfiguring
    (
        DbContextOptionsBuilder optionsBuilder
    )
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string conn = config.GetConnectionString("MyConn");

        optionsBuilder.UseSqlServer(conn);
    }

}
