

using Blogy.Business.DTOs.GeminiDtos;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Blogy.Business.Services.AiServices
{
    public class GeminiAiService : IGeminiAiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string Model = "gemini-2.5-flash";
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models/";
        public GeminiAiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Gemini:ApiKey"];
        }
        public async Task<bool> IsCommentSafeAsync(string comment)
        {

            var url = $"{BaseUrl}{Model}:generateContent?key={_apiKey}";

            var prompt = $"Sen bir blog yorum moderatörüsün. Aşağıdaki yorumu analiz et. " +
                         $"Eğer yorum küfür, hakaret, nefret söylemi veya spam içeriyorsa sadece 'HARMFUL' yaz. " +
                         $"Eğer yorum temizse veya sadece eleştiri içeriyorsa sadece 'SAFE' yaz. " +
                         $"Yorum: {comment}";

            var requestBody = new GeminiRequest
            {
                contents = new List<Content>
        {
            new Content { parts = new List<Part> { new Part { text = prompt } } }
        }
            };

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Google API Hatası: {response.StatusCode} - {errorContent}");
            }

            var responseData = await response.Content.ReadFromJsonAsync<GeminiResponse>();
            var aiDecision = responseData?.candidates?.FirstOrDefault()?.content?.parts?.FirstOrDefault()?.text?.Trim();

            return aiDecision != null && aiDecision.ToUpper().Contains("SAFE");
        }
    }
}
