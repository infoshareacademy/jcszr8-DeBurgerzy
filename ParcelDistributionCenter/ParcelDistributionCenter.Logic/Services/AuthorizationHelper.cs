using Microsoft.Extensions.Configuration;

namespace ParcelDistributionCenter.Logic.Services
{
    public class AuthorizationHelper
    {
        public static void AddAuthorizationHeader(HttpClient httpClient, IConfiguration configuration)
        {
            string apiKey = configuration["Authentication:ApiKey"];
            httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }
    }
}