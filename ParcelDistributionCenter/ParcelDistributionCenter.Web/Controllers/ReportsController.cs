using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Logic.ViewModels;
using ParcelDistributionCenter.Model.DTOs;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService, IMapper mapper, IEmailService emailService)
        {
            _reportService = reportService;
            _mapper = mapper;
            _emailService = emailService;
        }

        // GET: ReportsController/GetPackagesReport
        [HttpGet]
        public async Task<IActionResult> GetPackagesReport()
        {
            IEnumerable<ReportPackage> reportPackages = await _reportService.GetReportPackages();
            IEnumerable<ReportPackageDto> reportPackagesDto = _mapper.Map<IEnumerable<ReportPackageDto>>(reportPackages);
            return View(reportPackagesDto);
        }

        [HttpGet]
        public IActionResult ReportMailing()
        {
            EmailViewModel emailViewModel = new()
            {
                HourToSendEmail = _emailService.HourToSendEmail
            };
            return View(emailViewModel);
        }

        [HttpPost]
        public IActionResult ReportMailingConfirmed(EmailViewModel emailViewModel)
        {
            _emailService.HourToSendEmail = emailViewModel.HourToSendEmail;
            _emailService.SendEmail();
            TempData["Message"] = "Email successfully sent!";
            TempData["MessageClass"] = "alert-success";
            return RedirectToAction(nameof(ReportMailing));
        }
    }
}