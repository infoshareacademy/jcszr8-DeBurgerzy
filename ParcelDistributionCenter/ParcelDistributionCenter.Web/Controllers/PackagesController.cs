using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Logic.Models;
using ParcelDistributionCenter.Model.Models;
using System.Drawing;
using System.Reflection;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IAddNewPackageHandler _addNewPackageHandler;
        private readonly IMemoryRepository _memoryRepository;
        private readonly IPackageHandler _packageHandler;

        public PackagesController(IMemoryRepository memoryRepository, IAddNewPackageHandler addNewPackageHandler, IPackageHandler packageHandler)
        {
            _memoryRepository = memoryRepository;
            _addNewPackageHandler = addNewPackageHandler;
            _packageHandler = packageHandler;
            _memoryRepository.LoadData();
        }

        // GET: PackagesController/AddPackage
        public ActionResult AddPackage()
        {
            return View();
        }

        // POST: PackagesController/AddPackage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPackage(PackageVM packageVM)
        {
            if (ModelState.IsValid)
            {

                bool added = _addNewPackageHandler.AddNewPackage(packageVM, out Package package);
                if (added)
                {
                    return RedirectToAction(nameof(DisplaySinglePackage), package);
                }
                TempData["Message"] = "Something went wrong. Please ensure that provided data is correct.";
                TempData["MessageClass"] = "alert-danger";
                return View(packageVM);
            }
            return View(packageVM);
        }

        // GET: PackagesController/AddPackage
        public ActionResult DeletePackage(int packageNumber)
        {
            bool deleted = _packageHandler.DeletePackageByNumber(packageNumber);
            if (deleted)
            {
                TempData["Message"] = "Package successfully deleted";
                TempData["MessageClass"] = "alert-success";
                return RedirectToAction(nameof(AddPackage));
            }
            TempData["Message"] = "Package not deleted! Something went wrong";
            TempData["MessageClass"] = "alert-danger";
            return RedirectToAction(nameof(DisplayPackages));
        }

        // GET: PackagesController/DisplayPackages
        public ActionResult DisplayPackages()
        {
            var model = _packageHandler.FindAll();
            return View(model);
        }

        // GET: PackagesController/DisplayPackages
        public ActionResult DisplaySinglePackage(Package package)
        {
            return View(package);
        }

        // GET: PackagesController/Edit/5
        public ActionResult Edit(int packageNumber)
        {
            var model = _packageHandler.FindPackageByNumber(packageNumber);
            return View(model);
        }

        // POST: PackagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Package package)
        {
            try
            {
                _packageHandler.Update(package);
                return RedirectToAction(nameof(DisplayPackages));
            }
            catch
            {
                return View(nameof(DisplayPackages));
            }
        }

        // GET: PackagesController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FindPackageByCourierID(string CourierId)
        {
            var model = _packageHandler.FindPackagesByCourierID(CourierId);

            if (model == null)
            {
                TempData["Message"] = "Package not found.";
                TempData["MessageClass"] = "alert-danger";
                return RedirectToAction("InsertCourierID", "Packages");
            }
            return View(model);
        }
        public ActionResult InsertCourierID()
        {
            return View();
        }
          public ActionResult FindPackageByPackageID(int packageID)
        {                     
                var model = _packageHandler.FindPackageByNumber(packageID);

                if (model == null) 
                {
                TempData["Message"] = "Package not found.";
                TempData["MessageClass"] = "alert-danger";
                return  RedirectToAction("InsertPackageID", "Packages"); 
                }
                return View(model);                     
        }
        public ActionResult InsertPackageID(int packageID)
        {
            return View();
        }
        //FindPackagesByDeliveryMachineID
        public ActionResult FindPackageByDeliveryMachineID(string DeliveryMachineId)
        {
            var model = _packageHandler.FindPackagesByDeliveryMachineID(DeliveryMachineId);

            if (model == null)
            {
                TempData["Message"] = "Package not found.";
                TempData["MessageClass"] = "alert-danger";
                return RedirectToAction("InsertDeliveryMachineID", "Packages");
            }
            return View(model);
        }
        public ActionResult InsertDeliveryMachineID()
        {
            return View();
        }
    }
}