using GuimasBurguerAppWeb.Data;
using GuimasBurguerAppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GuimasBurguerAppWeb.Services.Database;

public class HamburguerService : IHamburguerService
{
    private HamburguerDbContext _context;

    public HamburguerService(HamburguerDbContext context)
    {
        _context = context;
    }

    public void Alterar(Hamburguer hamburguer)
    {
        var hamburguerOriginal = Obter(hamburguer.HamburguerId);
        hamburguerOriginal.Nome = hamburguer.Nome;
        hamburguerOriginal.Descricao = hamburguer.Descricao;
        hamburguerOriginal.Preco = hamburguer.Preco;
        hamburguerOriginal.EntregaExpressa = hamburguer.EntregaExpressa;
        hamburguerOriginal.DataCadastro = hamburguer.DataCadastro;
        hamburguerOriginal.ImagemUri = hamburguer.ImagemUri;

        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var hamburguerEncontrado = Obter(id);
        
        _context.Hamburguer.Remove(hamburguerEncontrado);
        //_context.Ingrediente.Remove(Ingrediente);
        //_context.Marca.Remove(Marca);

        _context.SaveChanges();
    }

    public void Incluir(Hamburguer hamburguer)
    {
        _context.Hamburguer.Add(hamburguer);
        _context.SaveChanges();
    }

    public Hamburguer Obter(int id)
    {
        return _context.Hamburguer
            .SingleOrDefault(item => item.HamburguerId == id);
    }

    public IList<Hamburguer> ObterTodos()
    {
        return _context.Hamburguer.ToList();
    }
}
