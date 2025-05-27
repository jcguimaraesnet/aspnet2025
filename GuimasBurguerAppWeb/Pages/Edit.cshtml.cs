using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GuimasBurguerAppWeb.Pages
{
    public class EditModel : PageModel
    {
        private IHamburguerService _service;
        public SelectList MarcaOptionItems { get; set; }
        public SelectList CategoriaOptionItems { get; set; }

        public EditModel(IHamburguerService hamburguerService)
        {
            _service = hamburguerService;
        }

        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        [BindProperty]
        public IList<int> CategoriaIds { get; set; }


        public void OnGet(int id)
        {
            Hamburguer = _service.Obter(id);

            CategoriaIds = Hamburguer.Categorias.Select(item => item.CategoriaId).ToList();

            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Nome));

            CategoriaOptionItems = new SelectList(_service.ObterTodasCategorias(),
                                                nameof(Categoria.CategoriaId),
                                                nameof(Categoria.Descricao));

        }

        public IActionResult OnPost()
        {

            Hamburguer.Categorias = _service.ObterTodasCategorias()
                                            .Where(item => CategoriaIds.Contains(item.CategoriaId))
                                            .ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Alterar(Hamburguer);

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete()
        {
            _service.Excluir(Hamburguer.HamburguerId);

            return RedirectToPage("/Index");
        }
    }
}
