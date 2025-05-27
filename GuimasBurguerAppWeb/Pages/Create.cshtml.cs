using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GuimasBurguerAppWeb.Pages
{
    public class CreateModel : PageModel
    {
        private IHamburguerService _service;

        public CreateModel(IHamburguerService hamburguerService)
        {
            _service = hamburguerService;
        }

        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        public SelectList MarcaOptionItems { get; set; }

        public void OnGet()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Nome));

        }

        public IActionResult OnPost()
        {
            if (Hamburguer.Nome == Hamburguer.Descricao)
            {
                ModelState.AddModelError("Hamburguer.Nome", 
                    "Nome não pode ser igual a Descrição.");
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
