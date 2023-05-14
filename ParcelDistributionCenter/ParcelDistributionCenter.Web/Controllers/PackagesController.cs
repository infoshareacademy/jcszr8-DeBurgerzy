using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Logic.ViewModels;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Web.Controllers
{
    [Obsolete("TEMPDATA ATTRIBUTE INTO SEPARATE CLASS")]
    public class PackagesController : Controller
    {
        private readonly IAddNewPackageService _addNewPackageService;
        private readonly ICourierService _courierService;
        private readonly IDeliveryMachinesService _deliveryMachinesService;
        private readonly IMapper _mapper;
        private readonly IPackageService _packageService;

        public PackagesController(IAddNewPackageService addNewPackageHandler, IPackageService packageService, ICourierService courierService, IDeliveryMachinesService deliveryMachinesService, IMapper mapper)
        {
            _addNewPackageService = addNewPackageHandler;
            _packageService = packageService;
            _courierService = courierService;
            _deliveryMachinesService = deliveryMachinesService;
            _mapper = mapper;
        }

        // GET: PackagesController/AddPackage
        public ActionResult AddPackage()
        {
            return View();
        }

        // POST: PackagesController/AddPackage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPackage(PackageViewModel packageViewModel)
        {
            if (ModelState.IsValid)
            {
                packageViewModel = _addNewPackageService.AddNewPackage(packageViewModel);
                //TODO: TempData do przeniesienia do widoku
                TempData["Message"] = "Package successfully added!";
                TempData["MessageClass"] = "alert-success";

                return RedirectToAction(nameof(DisplaySinglePackage), packageViewModel);
            }
            return View(packageViewModel);
        }

        public ActionResult AssignCourier(string packageNumber, string courierId, string from)
        {
            if (courierId != null)
            {
                _packageService.AssignCourier(packageNumber, courierId);
                return from == "UnassignedPackages" ? RedirectToAction(from) : RedirectToAction("CourierPackages", "Couriers", new { id = courierId });
            }
            else
            {
                IEnumerable<Courier> courier = _courierService.GetAll();
                IEnumerable<CourierViewModel> model = _mapper.Map<IEnumerable<Courier>, IEnumerable<CourierViewModel>>(courier);
                return View(model);
            }
        }

        public ActionResult AssignDeliveryMachine(string packageNumber, string deliveryMachineId, string from)
        {
            if (deliveryMachineId != null)
            {
                _packageService.AssignDeliveryMachine(packageNumber, deliveryMachineId);
                return from == "UnassignedPackages" ? RedirectToAction(from) : RedirectToAction("Details", "DeliveryMachines", new { id = deliveryMachineId });
            }
            else
            {
                IEnumerable<DeliveryMachine> deliveryMachine = _deliveryMachinesService.GetAll();
                IEnumerable<DeliveryMachineViewModel> model = _mapper.Map<IEnumerable<DeliveryMachine>, IEnumerable<DeliveryMachineViewModel>>(deliveryMachine);
                return View(model);
            }
        }

        // GET: PackagesController/DeletePackage/5
        public ActionResult DeletePackage(int packageNumber)
        {
            bool deleted = _packageService.DeletePackageByNumber(packageNumber);
            if (deleted)
            {
                TempData["Message"] = "Package successfully deleted";
                TempData["MessageClass"] = "alert-success";
                return RedirectToAction(nameof(DisplayPackages));
            }
            TempData["Message"] = "Package not deleted! Something went wrong";
            TempData["MessageClass"] = "alert-danger";
            return RedirectToAction(nameof(DisplayPackages));
        }

        // GET: PackagesController/DisplayPackages
        public ActionResult DisplayPackages()
        {
            var packages = _packageService.GetAllPackages();
            IEnumerable<PackageViewModel> packageViewModels = _mapper.Map<IEnumerable<Package>, IEnumerable<PackageViewModel>>(packages);
            return View(packageViewModels);
        }

        // GET: PackagesController/DisplayPackages
        public ActionResult DisplaySinglePackage(int packageNumber)
        {
            var package = _packageService.FindPackageByPackageNumber(packageNumber);
            PackageViewModel packageViewModel = _mapper.Map<Package, PackageViewModel>(package);
            return View(packageViewModel);
        }

        // GET: PackagesController/Edit/5
        public ActionResult Edit(int packageNumber)
        {
            var package = _packageService.FindPackageByPackageNumber(packageNumber);
            PackageViewModel packageViewModel = _mapper.Map<Package, PackageViewModel>(package);
            return View(packageViewModel);
        }

        // POST: PackagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PackageViewModel packageViewModel)
        {
            if (!ModelState.IsValid) return View(packageViewModel);
            Package package = _mapper.Map<PackageViewModel, Package>(packageViewModel);
            bool edited = _packageService.Update(package);
            if (edited)
            {
                TempData["Message"] = "Package successfully edited";
                TempData["MessageClass"] = "alert-success";
                return RedirectToAction(nameof(DisplayPackages));
            }
            TempData["Message"] = "Package not edited! Something went wrong";
            TempData["MessageClass"] = "alert-danger";
            return View();
        }

        // GET: PackagesController/FindPackageByNumber
        public ActionResult FindPackageByNumber()
        {
            var packagesNumbers = _packageService.GetAllPackagesNumber();
            PackageNumberViewModel packageNumberViewModel = new() { PackageNumbers = packagesNumbers, PackageNumber = 0 };
            return View(packageNumberViewModel);
        }

        // POST: PackagesController/FindPackageBuNumber/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindPackageByNumber(PackageNumberViewModel pVM)
        {
            return RedirectToAction("DisplaySinglePackage", new { packageNumber = pVM.PackageNumber });
        }

        public ActionResult UnassignedPackages()
        {
            IEnumerable<Package> package = _packageService.GetUnassignedPackages();
            IEnumerable<PackageViewModel> packageVM = _mapper.Map<IEnumerable<Package>, IEnumerable<PackageViewModel>>(package);
            return View(packageVM);
        }
    }
}