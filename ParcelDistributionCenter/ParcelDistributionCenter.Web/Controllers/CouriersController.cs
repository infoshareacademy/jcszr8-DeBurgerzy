using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class CouriersController : Controller
    {
        private readonly IMemoryRepository _memoryRepository;
        private readonly ICourierHandler _courierHandler;

        public CouriersController(IMemoryRepository memoryRepository, ICourierHandler courierHandler)
        {
            _memoryRepository = memoryRepository;
            _courierHandler = courierHandler;
        }

        // GET: CouriersController
        public ActionResult DisplayCouriers()
        {
            _memoryRepository.LoadData();
            var model = _courierHandler.FindAll();
            return View(model);
        }

        // GET: CouriersController/Details/5
        public ActionResult Details(int id)
        {
            return View();

        }

        // GET: CouriersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CouriersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouriersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CouriersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouriersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CouriersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetCourierPackages(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}
