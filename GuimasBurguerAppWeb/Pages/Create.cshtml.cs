using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
