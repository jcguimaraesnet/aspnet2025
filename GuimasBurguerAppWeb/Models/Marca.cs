using System.ComponentModel.DataAnnotations;

namespace GuimasBurguerAppWeb.Models;

public class Marca
{
    [Display(Name="Marca")]
    public int MarcaId { get; set; }
    public string Nome { get; set; }
}
