using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.Models;

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
        public ActionResult AddPackage(Package package)
        {
            if (ModelState.IsValid)
            {
                bool added = _addNewPackageHandler.AddNewPackage(package);
                if (added)
                {
                    return RedirectToAction(nameof(DisplaySinglePackage), package);
                }
                else
                {
                    return View(package);
                }
            }
            //return View(package);
            return RedirectToAction(nameof(DisplaySinglePackage), package);
        }

        // POST: PackagesController/Create
        [HttpPost]
        public ActionResult Create(FindPackageByNumberVM findPackageByNumberVM)
        {
            // walidacja ze stringa do inta
            Package package = _packageHandler.FindPackageByNumber(int.Parse(findPackageByNumberVM.PackageNumber));
            try
            {
                return View("DisplayPackage", package);
            }
            catch
            {
                return View();
            }
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
        public ActionResult Edit(int id)
        {
            var model = _packageHandler.FindPackageByNumber(id);
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
    }
}