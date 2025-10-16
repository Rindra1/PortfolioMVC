namespace PortfolioMVC.Models;

public class PortfolioModel
{
    public int? IdUserLogin { get; set; }
    public string resume { get; set; } = string.Empty;
    public string? Nom { get; set; }
    public string? Prenom { get; set; }
    public string? APropos { get; set; }
    public string? UserImage { get; set; }
    public virtual UserLoginViewModel? UserLogin {get;set;}
    public List<ProjetViewModel> Projets { get; set; } = new List<ProjetViewModel>();
    public List<ContactViewModel> Contacts { get; set; } = new List<ContactViewModel>();
    public List<ExperienceViewModel> Experiences { get; set; } = new List<ExperienceViewModel>();
    public List<CompetenceViewModel> Competences { get; set; } = new List<CompetenceViewModel>();
    public MailViewModel EmailRequest { get; set; } = new MailViewModel();
    public List<LienViewModel> Liens {get;set;} = new List<LienViewModel>();
    public List<ChatViewModel> ChatResponses { get; set; } = new List<ChatViewModel>();
}
