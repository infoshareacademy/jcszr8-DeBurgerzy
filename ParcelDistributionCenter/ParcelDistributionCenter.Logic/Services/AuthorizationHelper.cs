using Microsoft.Extensions.Configuration;

namespace ParcelDistributionCenter.Logic.Services
{
    public class AuthorizationHelper
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AuthorizationHelper(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public void AddAuthorizationHeader()
        {
            string apiKey = _configuration["Authentication:ApiKey"];
            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }
    }
}