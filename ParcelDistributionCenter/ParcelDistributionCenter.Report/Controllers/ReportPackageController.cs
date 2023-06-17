using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Report.Controllers
{
    [ApiController]
    [Route("reports/[controller]")]
    public class ReportPackageController : ControllerBase
    {
        private readonly IRepository<ReportPackage> _reportPackageRepository;

        public ReportPackageController(IRepository<ReportPackage> reportPackageRepository)
        {
            _reportPackageRepository = reportPackageRepository;
        }

        [HttpPost]
        public IActionResult AddReportPackage(ReportPackage reportPackage)
        {
            _reportPackageRepository.Insert(reportPackage);
            return Ok(reportPackage);
        }

        // TODO: To be changed
        [HttpGet]
        public IEnumerable<ReportPackage> GetReportPackages() => _reportPackageRepository.GetAll();
    }
}