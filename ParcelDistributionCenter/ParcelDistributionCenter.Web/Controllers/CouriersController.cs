using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Logic.Services;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.Models;
using System.Diagnostics.Metrics;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class CouriersController : Controller
    {
        private readonly IMemoryRepository _memoryRepository;
        private readonly ICourierHandler _courierHandler;
        private readonly IPackageServices _packageServices;
        private readonly IAddNewCourierHandler _addNewCourierHandler;

        public CouriersController(IMemoryRepository memoryRepository, ICourierHandler courierHandler, IPackageServices packageServices, IAddNewCourierHandler addNewCourierHandler)
        {
            _memoryRepository = memoryRepository;
            _courierHandler = courierHandler;
            _packageServices = packageServices;
            _addNewCourierHandler = addNewCourierHandler;
        }

        // GET: CouriersController
        public ActionResult Index()
        {
            _memoryRepository.LoadData();
            var model = _courierHandler.FindAll();
            return View(model);
        }

        // GET: CouriersController/Details/5
        public ActionResult Details(string id)
        {
            _memoryRepository.LoadData();
            var model = _courierHandler.FindById(id);
            return View(model);
        }

        // GET: CouriersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CouriersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Courier courier)
        {
            bool added = _addNewCourierHandler.AddNewCourier(courier);
            if (added)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CouriersController/Edit/5
        public ActionResult Edit(string id)
        {
            _memoryRepository.LoadData();
            var model = _courierHandler.FindById(id);
            return View(model);
        }

        // POST: CouriersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Courier courier)
        {
            try
            {
                _courierHandler.Update(courier);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }

        // GET: CouriersController/Delete/5
        public ActionResult Delete(string id)
        {
            var model =_courierHandler.FindById(id);
            _courierHandler.Delete(model);
            return RedirectToAction(nameof(Index));
        }

   
        public ActionResult CourierPackages(string id)
        {
            _memoryRepository.LoadData();
            var model = _packageServices.GetCourierPackages(id);
            return View(model);
        }
        public ActionResult UnassignedPackages()
        {
            _memoryRepository.LoadData();
            var model = _packageServices.GetUnassignedPackages();
            return View(model);
        }

        public ActionResult Assign(string packageNumber, string CourierId)
        {
            _memoryRepository.LoadData();
            if (CourierId != null)
            {
                _packageServices.AssignPackage(packageNumber, CourierId);
                return RedirectToAction("CourierPackages", new {id = CourierId});
            }
            else
            {
            var model = _courierHandler.FindAll();
            return View(model);
            }
        }
      }
}
