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
        private readonly IMapper _mapper;
        private readonly IPackageService _packageService;

        public PackagesController(IAddNewPackageService addNewPackageHandler, IPackageService packageService, IMapper mapper)
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
                packageViewModel = _addNewPackageService.AddNewPackage(packageViewModel);
                //TODO: TempData do przeniesienia do widoku
                TempData["Message"] = "Package successfully added!";
                TempData["MessageClass"] = "alert-success";

                return RedirectToAction(nameof(DisplaySinglePackage), packageViewModel);
            }
            return View(packageViewModel);
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
    }
}