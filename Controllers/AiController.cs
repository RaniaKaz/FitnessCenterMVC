using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Text;
using System.Text.Json;

namespace webProject.Controllers
{
    [Authorize]
    public class AiController : Controller
    {

        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public AiController(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        // FORM
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // AI ÇAĞRISI
        [HttpPost]
        public async Task<IActionResult> EgzersizOner(string prompt)
        {
            var apiKey = _config["Gemini:ApiKey"];

            //var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}";
            // "gemini-1.5-flash" yerine "gemini-1.5-flash-latest" kullanıyoruz
            // var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key={apiKey}";
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}";
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync(url, content);
            var json = await response.Content.ReadAsStringAsync();

            ViewBag.Sonuc = json;
            return View("AiSonuc");
        }

        // SONUÇ
        [HttpGet]
        public IActionResult AiSonuc()
        {
            return View();
        }
    }
}
