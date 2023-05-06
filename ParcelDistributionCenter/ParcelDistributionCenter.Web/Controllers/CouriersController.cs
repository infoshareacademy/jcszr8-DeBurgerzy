using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Web.ViewModels;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class CouriersController : Controller
    {
        private readonly ICourierService _courierService;
        private readonly IMapper _mapper;

        public CouriersController(ICourierService courierService, IMapper mapper)
        {
            _courierService = courierService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var courier = _courierService.GetAll();
            IEnumerable<CourierViewModel> model = _mapper.Map<IEnumerable<Courier>, IEnumerable<CourierViewModel>>(courier);
            return View(model);
        }

        public ActionResult CourierPackages(string id)
        {
            IEnumerable<Package> packages = _courierService.GetCourierPackages(id);
            IEnumerable<PackageViewModel> model = _mapper.Map<IEnumerable<Package>, IEnumerable<PackageViewModel>>(packages);
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
            var courier = _courierService.FindById(id);
            CourierViewModel model = _mapper.Map<Courier, CourierViewModel>(courier);

            return View(model);
        }

        // POST: CouriersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourierViewModel courierViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(courierViewModel);
            }

            Courier courier = _mapper.Map<CourierViewModel, Courier>(courierViewModel);
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
        public ActionResult Create(CourierViewModel courierViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(courierViewModel);
            }
            Courier courier = _mapper.Map<CourierViewModel, Courier>(courierViewModel);
            bool added = _courierService.AddNewCourier(courier);
            if (added)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult UnassignedPackages()
        {
            var package = _courierService.GetUnassignedPackages().ToList();
            List<PackageViewModel> packageVM = _mapper.Map<List<Package>, List<PackageViewModel>>(package);
            return View(packageVM);
        }

        public ActionResult Assign(string packageNumber, string courierId, string from)
        {
            if (courierId != null)
            {
                _courierService.AssignPackage(packageNumber, courierId);
                return from == "UnassignedPackages" ? RedirectToAction(from) : RedirectToAction("CourierPackages", new { id = courierId });
            }
            else
            {
                var courier = _courierService.GetAll().ToList();
                List<CourierViewModel> model = _mapper.Map<List<Courier>, List<CourierViewModel>>(courier);

                return View(model);
            }
        }

        public ActionResult UnassignPackage(string packageNumber, string courierId)
        {
            _courierService.UnassignPackage(packageNumber);
            var model = _courierService.GetCourierPackages(courierId);
            return RedirectToAction("CourierPackages", new { id = courierId });
        }
    }
}