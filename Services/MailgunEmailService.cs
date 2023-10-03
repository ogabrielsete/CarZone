using FluentEmail.Core;
using System.Text;

namespace CarZone.Services
{
    public class MailgunEmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public MailgunEmailService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var apiKey = _configuration["SecretsStuff:codeA"];
            var domain = _configuration["SecretsStuff:codeD"];
            var from = "biel-sr@hotmail.com"; // Defina o e-mail do remetente

            var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("from", from),
            new KeyValuePair<string, string>("to", to),
            new KeyValuePair<string, string>("subject", subject),
            new KeyValuePair<string, string>("text", body)
        });

            var requestUri = $"https://api.mailgun.net/v3/{domain}/messages";
            var byteArray = Encoding.ASCII.GetBytes($"api:{apiKey}");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await _httpClient.PostAsync(requestUri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao enviar e-mail");
            }
        }
    }
}
