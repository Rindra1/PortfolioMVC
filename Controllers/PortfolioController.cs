using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioMVC.Models;
using System.Net.Http.Json;

namespace PortfolioMVC.Controllers;

public class PortfolioController : Controller
{
    private readonly ILogger<PortfolioController> _logger;
    private HttpClient _http { get; set; }

    public PortfolioController(ILogger<PortfolioController> logger, HttpClient http)
    {
        _logger = logger;
        _http = http;
        //_http.HttpClientFactory.CreateClient("API");
    }

    public async Task<IActionResult> Home()
    {
        try
        {
            await _http.GetAsync("https://rindra-dotnet-developer.onrender.com/health");
            ViewData["Title"] = "Accueil - Mon Portfolio";
            ViewData["Description"] = "Découvrez mon portfolio en tant que développeur .NET et mes projets avec API.";
            ViewData["Canonical"] = "https://rindra-dotnet-portfolio.onrender.com/";
            var portfolio = await _http.GetFromJsonAsync<PortfolioModel>("api/portfolio");


            Console.WriteLine(portfolio.Nom);

            return View(portfolio ?? new PortfolioModel());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EnvoyerMail([FromBody] MailViewModel portfolio)
    {
        if (portfolio == null || string.IsNullOrWhiteSpace(portfolio.To))
            return BadRequest("Les champs sont vides");

        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(portfolio));

        var response = await _http.PostAsJsonAsync("api/mail/sendgrid", portfolio);

        if (response.IsSuccessStatusCode)
            return Ok("Message envoyé avec succès");
        else
            return StatusCode(500, "Erreur lors de l'envoi du message");
    }


        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequest Message)
        {
            Console.WriteLine("Tonga ato " + Message.Message);
            //if (string.IsNullOrWhiteSpace(message))
                //return BadRequest("Message vide");
           
            // 🔹 Ici, tu peux appeler ton IA ou une logique quelconque
            var chatRequest= new {Message = Message.Message};
            var botResponse = await _http.PostAsJsonAsync("api/chat", chatRequest);
            //string botResponse = $"Je répète : {userMessage}";
             Console.WriteLine("Tonga ato 1");
            var chatBot = await botResponse.Content.ReadFromJsonAsync<ChatResponse>();
            return Content(chatBot.Message);
        }
}
