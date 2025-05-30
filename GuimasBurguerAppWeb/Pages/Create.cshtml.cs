using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GuimasBurguerAppWeb.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private IHamburguerService _service;

        public CreateModel(IHamburguerService hamburguerService)
        {
            _service = hamburguerService;
        }

        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        [BindProperty]
        public IList<int> CategoriaIds { get; set; }


        public SelectList MarcaOptionItems { get; set; }

        public SelectList CategoriaOptionItems { get; set; }

        public void OnGet()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Nome));

            CategoriaOptionItems = new SelectList(_service.ObterTodasCategorias(),
                                    nameof(Categoria.CategoriaId),
                                    nameof(Categoria.Descricao));
        }

        public IActionResult OnPost()
        {
            if (Hamburguer.Nome == Hamburguer.Descricao)
            {
                ModelState.AddModelError("Hamburguer.Nome", 
                    "Nome n�o pode ser igual a Descri��o.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            //var service = new HamburguerService();
            _service.Incluir(Hamburguer);

            return RedirectToPage("/Index");
        }
    }
}
