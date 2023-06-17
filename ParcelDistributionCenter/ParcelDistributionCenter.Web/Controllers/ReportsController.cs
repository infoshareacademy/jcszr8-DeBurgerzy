using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.DTOs;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        // GET: ReportsController/GetPackagesReport
        [HttpGet]
        public async Task<IActionResult> GetPackagesReport()
        {
            IEnumerable<ReportPackage> reportPackages = await _reportService.GetReportPackages();
            IEnumerable<ReportPackageDto> reportPackagesDto = _mapper.Map<IEnumerable<ReportPackageDto>>(reportPackages);
            return View(reportPackagesDto);
        }
    }
}