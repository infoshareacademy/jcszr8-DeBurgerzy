using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Models;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Context.Memory;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IAddNewPackageService _addNewPackageHandler;
        private readonly IMapper _mapper;
        private readonly IMemoryRepository _memoryRepository;
        private readonly IPackageService _packageHandler;

        public PackagesController(IMemoryRepository memoryRepository, IAddNewPackageService addNewPackageHandler, IPackageService packageHandler, IMapper mapper)
        {
            _memoryRepository = memoryRepository;
            _addNewPackageHandler = addNewPackageHandler;
            _packageHandler = packageHandler;
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
                Package package = _mapper.Map<Package>(packageViewModel);
                bool added = _addNewPackageHandler.AddNewPackage(ref package);
                if (added)
                {
                    return RedirectToAction(nameof(DisplaySinglePackage), package);
                }
                TempData["Message"] = "Something went wrong. Please ensure that provided data is correct.";
                TempData["MessageClass"] = "alert-danger";
                return View(packageViewModel);
            }
            return View(packageViewModel);
        }

        // GET: PackagesController/AddPackage
        public ActionResult DeletePackage(string id)
        {
            bool deleted = _packageHandler.DeletePackageByNumber(id);
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
        public ActionResult Edit(string id)
        {
            var model = _packageHandler.FindPackageById(id);
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

        public ActionResult FindByPackageID(string packageID)
        {
            var model = _packageHandler.FindPackageById(packageID);

            if (model == null)
            {
                return RedirectToAction("InsertPackageID", "Packages");
            }
            return View(model);
        }

        public ActionResult FindPackageByCourierID(string CourierId)
        {
            var model = _packageHandler.FindPackagesByCourierID(CourierId);

            if (model == null)
            {
                return RedirectToAction("InsertCourierID", "Packages");
            }
            return View(model);
        }

        // GET: PackagesController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertCourierID()
        {
            return View();
        }

        public ActionResult InsertPackageID(int packageID)
        {
            return View();
        }
    }
}