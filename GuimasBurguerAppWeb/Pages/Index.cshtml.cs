using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Hamburguer> Hamburguers;

        private IHamburguerService _service;

        public IndexModel(IHamburguerService hamburguerService)
        {
            _service = hamburguerService;
        }

        public void OnGet()
        {
            //var service = new HamburguerService();
            Hamburguers = _service.ObterTodos();
        }
    }
}
