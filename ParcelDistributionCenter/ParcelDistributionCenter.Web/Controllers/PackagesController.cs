using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Context.Memory;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.ViewModels;
using System.Diagnostics.Metrics;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IAddNewPackageService _addNewPackageService;
        private readonly IMapper _mapper;
        private readonly IPackageService _packageService;

        public PackagesController(IMemoryRepository memoryRepository, IAddNewPackageService addNewPackageHandler, IPackageService packageService, IMapper mapper)
        {
            _addNewPackageService = addNewPackageHandler;
            _packageService = packageService;
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
                bool added = _addNewPackageService.AddNewPackage(ref package);
                if (added)
                {
                    return RedirectToAction("AddPackageConfirm", package);
                }
                TempData["Message"] = "Something went wrong. Please ensure that provided data is correct.";
                TempData["MessageClass"] = "alert-danger";
                return View(packageViewModel);
            }
            return View(packageViewModel);
        }

        // GET: PackagesController/DisplayPackages
        public ActionResult DisplayPackages()
        {
            var packages = _packageService.GetAllPackages();
            IEnumerable<PackageViewModel> packageViewModels= _mapper.Map<IEnumerable<Package>, IEnumerable<PackageViewModel>>(packages);
            return View(packageViewModels);
        }

        // GET: PackagesController/DisplayPackages
        public ActionResult DisplaySinglePackage(int packageNumber)
        {
            var package = _packageService.FindPackageByPackageNumber(packageNumber);
            PackageViewModel packageViewModel = _mapper.Map<Package,PackageViewModel>(package);

            return View(packageViewModel);
        }

        /*
        // GET: PackagesController/AddPackage
        public ActionResult DeletePackage(string id)
        {
            bool deleted = _packageService.DeletePackageByNumber(id);
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


        // GET: PackagesController/Edit/5
        public ActionResult Edit(string packageNumber)
        {
            var model = _packageService.FindPackageByPackageNumber(int.Parse(packageNumber));
            return View(model);
        }

        // POST: PackagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Package package)
        {
            try
            {
                _packageService.Update(package);
                return RedirectToAction(nameof(DisplayPackages));
            }
            catch
            {
                return View(nameof(DisplayPackages));
            }
        }

        public ActionResult FindByPackageID(string packageID)
        {
            var model = _packageService.FindPackageById(packageID);

            if (model == null)
            {
                return RedirectToAction("InsertPackageID", "Packages");
            }
            return View(model);
        }

        public ActionResult FindPackageByCourierID(string CourierId)
        {
            var model = _packageService.FindPackagesByCourierID(CourierId);

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
        */
    }
}