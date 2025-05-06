using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Hamburguer> Hamburguers;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var service = new HamburguerService();
            Hamburguers = service.ObterTodos();
        }

        public void OnPost()
        {
        }
    }
}
