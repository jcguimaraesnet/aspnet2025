﻿using GuimasBurguerAppWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuimasBurguerAppWeb.Data;

public class HamburguerDbContext : IdentityDbContext
{
    public DbSet<Hamburguer> Hamburguer { get; set; }
    public DbSet<Marca> Marca { get; set; }
    public DbSet<Categoria> Categoria { get; set; }

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
