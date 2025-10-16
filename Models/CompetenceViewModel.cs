namespace PortfolioMVC.Models;

public class CompetenceViewModel
{
    public string? Nom{get;set;} = string.Empty;
    public int IdUser { get; set; }
    public UtilisateurViewModel? Utilisateur { get; set; }
}
