using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.Models;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IMemoryRepository _memoryRepository;

        public PackagesController(IMemoryRepository memoryRepository)
        {
            _memoryRepository = memoryRepository;
        }

        // POST: PackagesController/Create
        [HttpPost]
        public ActionResult Create(FindPackageByNumberVM findPackageByNumberVM)
        {
          
            // walidacja ze stringa do inta
            Package package = PackageHandler.FindPackageByNumber(int.Parse(findPackageByNumberVM.PackageNumber));
            try
            {
                return View("DisplayPackage", package);
            }
            catch
            {
                return View();
            }
        }

        // GET: PackagesController
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult DisplayPackages()
        {
            MemoryRepository.LoadData();
            var model = PackageHandler.FindAll();
            return View(model);
        }
        
        //// GET: PackagesController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: PackagesController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
        // GET: PackagesController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = PackageHandler.FindPackageByNumber(id);
            return View(model);
        }

        // POST: PackagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Package package)
        {
            try
            {
                PackageHandler.Update(package);
                return RedirectToAction(nameof(DisplayPackages));
            }
            catch
            {
                return View(nameof(DisplayPackages));
            }
        }

        //// GET: PackagesController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PackagesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}