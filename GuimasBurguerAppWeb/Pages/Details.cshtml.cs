using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages
{
    public class DetailsModel : PageModel
    {
        private IHamburguerService _service;
        public Hamburguer Hamburguer { get; set; }

        public DetailsModel(IHamburguerService hamburguerService)
        {
            _service = hamburguerService;
        }

        public void OnGet(int id)
        {
            //var service = new HamburguerService();
            Hamburguer = _service.Obter(id);
        }
    }
}
