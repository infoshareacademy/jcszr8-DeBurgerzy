using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.DTOs;
using System.Net.Http.Json;

namespace ParcelDistributionCenter.Logic.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;

        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // TODO: To be changed
        public async Task AddingPackageDuration(DateTime timeCreated)
        {
            var packageAddingDurationDto = new PackageAddingDurationDto()
            {
                Duration = timeCreated
            };
            HttpResponseMessage result = await _httpClient.PostAsJsonAsync("reports/users", packageAddingDurationDto);
        }
    }
}