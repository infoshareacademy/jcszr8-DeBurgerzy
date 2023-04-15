using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Context.Memory;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.ViewModels;
using System.Diagnostics.Metrics;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class CouriersController : Controller
    {
        private readonly IAddNewCourierService _addNewCourierService;
        private readonly ICourierService _courierService;
        private readonly IMapper _mapper;

        public CouriersController(ICourierService courierService, IAddNewCourierService addNewCourierService, IMapper mapper)
        {
            _courierService = courierService;
            _mapper = mapper;
            _addNewCourierService = addNewCourierService;
        }

        public ActionResult Index()
        {
            var courier = _courierService.GetAll().ToList();
            List<CourierViewModel> model = _mapper.Map<List<Courier>, List<CourierViewModel>>(courier);
                        
            return View(model);
        }
        public ActionResult CourierPackages(string id)
         {
            List<Package> model = _courierService.GetCourierPackages(id);
             return View(model);
         }
        // GET: CouriersController/Delete/5
        public ActionResult Delete(string id)
        {
            var model = _courierService.DeleteCourier(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: CouriersController/Edit/5
        public ActionResult Edit(string id)
        {
            var model = _courierService.FindById(id);
            return View(model);
        }

        // POST: CouriersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Courier courier)
        {
            try
            {
                _courierService.Update(courier);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
        // GET: CouriersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CouriersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Courier courier)
        {
                bool added = _addNewCourierService.AddNewCourier(courier);
                if (added)
                {
                    return RedirectToAction(nameof(Index));
                }
            return View();
        }
        public ActionResult UnassignedPackages()
        {
            var package= _courierService.GetUnassignedPackages().ToList();
            List<PackageViewModel> packageVM = _mapper.Map<List<Package>, List<PackageViewModel>>(package);
            return View(packageVM);
        }
        public ActionResult Assign(string packageNumber, string CourierId, string From)
        {
            if (CourierId != null)
            {
                _courierService.AssignPackage(packageNumber, CourierId);
                return From == "UnassignedPackages" ? RedirectToAction(From) : RedirectToAction("CourierPackages", new { id = CourierId });
            }
            else
            {
                var model = _courierService.GetAll();
                return View(model);
            }
        }
        public ActionResult UnassignPackage(string packageNumber, string CourierId)
        {
            _courierService.UnassignPackage(packageNumber);
            var model = _courierService.GetCourierPackages(CourierId);
            return RedirectToAction("CourierPackages", new { id = CourierId });
        }
    }
}