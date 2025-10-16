namespace PortfolioMVC.Models;

public class ProjetViewModel
{
    public int? IdProjet { get; set; }
    public string? ResumerProjet { get; set; }
    public string TitreProjet { get; set; }
    public string DetailProjet { get; set; }
    public string ImageProjet { get; set; }
    public List<LienViewModel>? LienDTOs {get;set;} = new List<LienViewModel>();
}
