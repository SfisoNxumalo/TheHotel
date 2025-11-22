using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using TheHotel.Domain.Interfaces.Integrations;

namespace TheHotel.Infrastructure.Integration.GeminiService
{
    public class GeminiService : IAIContentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeminiService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["Gemini:ApiKey"] ?? throw new Exception("Gemini API key not found");
        }
        public Task<string> RewriteAsync(string text, string style)
        {
            throw new NotImplementedException();
        }

        public Task<string> SummarizeAsync(string text)
        {
            throw new NotImplementedException();
        }

        public async Task<string> VerifyContentAsync(string prompt)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={_apiKey}";

            var requestBody = new
            {
                system_instruction = new
                {
                    parts = new[]
                    {
                        new { text = Constants.Constants.ContentSafetySystemPrompt }
                    }
                },
                contents = new[]
                {
                    new {
                        role = "user",
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseString);

            // Extract the generated text
            var generated = doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return generated ?? "";
        }
    }
}
