using Microsoft.Extensions.Configuration;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Enums;
using System.Net.Http.Json;

namespace ParcelDistributionCenter.Logic.Services
{
    public class ReportService : IReportService
    {
        private readonly AuthorizationHelper _authorizationHelper;
        private readonly HttpClient _httpClient;

        public ReportService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _authorizationHelper = new AuthorizationHelper(httpClient, configuration);
        }

        // Czy to powinno coś zwracać?
        public async Task AddPackageCreatingDuration(DateTime packageAddingStartTime, DateTime packageAddingEndTime, PackageSize size)
        {
            TimeSpan packageAddingDuration = packageAddingEndTime - packageAddingStartTime;
            ReportPackage reportPackage = new()
            {
                // Czemu tutaj to musi być? Powinno się generować samo w bazie. Inaczej nie działa i jest 400 Bad Request
                Id = Guid.NewGuid().ToString(),
                AddingDurationInSeconds = Math.Round(packageAddingDuration.TotalSeconds, 0),
                Size = size
            };
            _authorizationHelper.AddAuthorizationHeader();
            await _httpClient.PostAsJsonAsync("reports/users", reportPackage);
        }
    }
}