using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.Models;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class PackagesController : Controller
    {
        // GET: PackagesController
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult DisplayPackage(Package package)
        //{
        //    return View(package);
        //}
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

        // POST: PackagesController/Create
        [HttpPost]
        public ActionResult Create(FindPackageByNumberVM findPackageByNumberVM)
        {
            MemoryRepository.LoadData();
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

        //// GET: PackagesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: PackagesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
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
