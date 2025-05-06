using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages
{
    public class DetailsModel : PageModel
    {
        public Hamburguer Hamburguer {  get; set; }

        public void OnGet(int id)
        {
            var service = new HamburguerService();
            Hamburguer = service.Obter(id);
        }
    }
}
