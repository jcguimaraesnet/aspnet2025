﻿using GuimasBurguerAppWeb.Models;

namespace GuimasBurguerAppWeb.Services.Memory;

public class HamburguerService : IHamburguerService
{
    private IList<Hamburguer> _hamburguers;

    public HamburguerService()
        => CarregarListaInicial();

    private void CarregarListaInicial()
    {
        _hamburguers = new List<Hamburguer>()
        {
            new Hamburguer
            {
                HamburguerId = 1,
                Nome = "Beef Burger",
                Descricao = "Hambúrguer simples: suculento, saboroso e delicioso.",
                ImagemUri = "/imagens/beef-burger.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = true,
                Preco = 19.00,
            },
            new Hamburguer
            {
                HamburguerId = 2,
                Nome = "Canoe Burger",
                Descricao = "Delicioso hambúrguer com batata canoa crocante. Uma explosão de sabores em cada mordida!",
                ImagemUri = "/imagens/beef-burger-canoe-potatoes.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = false,
                Preco = 29.00,
            },
            new Hamburguer
            {
                HamburguerId = 3,
                Nome = "Pepper Burger",
                Descricao = "Hambúrguer irresistível com pimentão: sabor picante e suculento em cada pedaço!",
                ImagemUri = "/imagens/beef-burger-peppers.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = true,
                Preco = 39.00,
            },
            new Hamburguer
            {
                HamburguerId = 4,
                Nome = "Chickpea Burger",
                Descricao = "Saboroso hambúrguer de grão de bico: uma opção saudável e incrivelmente saborosa!",
                ImagemUri = "/imagens/chickpea-burger.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = true,
                Preco = 49.00,
            },
        };
    }

    public IList<Hamburguer> ObterTodos()
    => _hamburguers;

    public Hamburguer Obter(int id)
    {
        return _hamburguers.SingleOrDefault(item => item.HamburguerId == id);
    }

    public void Incluir(Hamburguer hamburguer)
    {
        var proximoNumero = _hamburguers.Max(item => item.HamburguerId) + 1;
        hamburguer.HamburguerId = proximoNumero;
        _hamburguers.Add(hamburguer);
    }

    public void Alterar(Hamburguer hamburguer)
    {
        var hamburguerEncontrado = Obter(hamburguer.HamburguerId);
        hamburguerEncontrado.Nome = hamburguer.Nome;
        hamburguerEncontrado.Descricao = hamburguer.Descricao;
        hamburguerEncontrado.Preco = hamburguer.Preco;
        hamburguerEncontrado.EntregaExpressa = hamburguer.EntregaExpressa;
        hamburguerEncontrado.DataCadastro = hamburguer.DataCadastro;
        hamburguerEncontrado.ImagemUri = hamburguer.ImagemUri;
        hamburguerEncontrado.MarcaId = hamburguer.MarcaId;
    }

    public void Excluir(int id)
    {
        var hamburguerEncontrado = Obter(id);
        _hamburguers.Remove(hamburguerEncontrado);
    }

    public IList<Marca> ObterTodasMarcas()
    {
        var marcas = new List<Marca>()
        {
            new Marca() { Nome = "Sadia" },
            new Marca() { Nome = "Perdigão" },
            new Marca() { Nome = "Baby beef" },
        };
        return marcas;
    }

    public IList<Categoria> ObterTodasCategorias()
    {
        return new List<Categoria>() {
            new Categoria() { Descricao = "Vegano" },
            new Categoria() { Descricao = "Clássico" },
            new Categoria() { Descricao = "Vegetariano" },
            new Categoria() { Descricao = "Super Calórico" }
        };
    }
}
