using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Logic.Models;
using ParcelDistributionCenter.Model.Models;
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
        public ActionResult AddPackage(PackageVM package)
        {
            if (ModelState.IsValid)
            {
                bool added = _addNewPackageHandler.AddNewPackage(package);
                if (added)
                {
                    return RedirectToAction(nameof(DisplaySinglePackage), package);
                }
                return View(package);
            }
            // To jest zakomentowane bo IsValid zwraca false caly czas
            //return View(package);
            return RedirectToAction(nameof(DisplaySinglePackage), package);
        }

        // GET: PackagesController/AddPackage
        public ActionResult DeletePackage(int packageNumber)
        {
            bool deleted = _packageHandler.DeletePackageByNumber(packageNumber);
            if (deleted)
            {
                return RedirectToAction(nameof(AddPackage));
            }
            // TUTAJ ZMIENIĆ, ŻEBY BYŁ JAKIŚ KOMUNIKAT, ŻE NIE USUNĄŁ
            return RedirectToAction("Index", "Home");
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
        public ActionResult FindByPackageID(int packageID)
        {                     
                var model = _packageHandler.FindPackageByNumber(packageID);

                if (model == null) 
                {
                  return  RedirectToAction("InsertPackageID", "Packages"); 
                }
                return View(model);                     
        }
        public ActionResult InsertPackageID(int packageID)
        {
            return View();
        }
     }
}