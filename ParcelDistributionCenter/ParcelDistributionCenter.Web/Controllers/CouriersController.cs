using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Context.Memory;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.ViewModels;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class CouriersController : Controller
    {
        //private readonly IAddNewCourierService _addNewCourierHandler;
        private readonly ICourierService _courierService;
        //private readonly IPackageServices _packageServices;
        private readonly IMapper _mapper;

        public CouriersController(ICourierService courierService, IPackageServices packageServices, IAddNewCourierService addNewCourierHandler, IMapper mapper)
        {
            _courierService = courierService;
            //_packageServices = packageServices;
            _mapper = mapper;
            //_addNewCourierHandler = addNewCourierHandler;
        }

        public ActionResult Index()
        {
            var courier = _courierService.GetAll().ToList();
            List<CourierViewModel> model = _mapper.Map<List<Courier>, List<CourierViewModel>>(courier);
                        
            return View(model);
        }

           public ActionResult CourierPackages(string id)
         {
            List<Package> model = _courierService.GetCourierPackages(id);

             //var model = _packageServices.GetCourierPackages(id);
             return View(model);
         }

        /* public ActionResult Assign(string packageNumber, string CourierId, string From)
         {
             if (CourierId != null)
             {
                 _packageServices.AssignPackage(packageNumber, CourierId);
                 return From == "UnassignedPackages" ? RedirectToAction(From) : RedirectToAction("CourierPackages", new { id = CourierId });
             }
             else
             {
                 var model = _courierHandler.FindAll();
                 return View(model);
             }
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
             if (ModelState.IsValid)
             {
                 bool added = _addNewCourierHandler.AddNewCourier(courier);
                 if (added)
                 {
                     return RedirectToAction(nameof(Index));
                 }
             }
             return View();
         }

         // GET: CouriersController/Delete/5
         public ActionResult Delete(string id)
         {
             var model = _courierHandler.FindById(id);

             _courierHandler.Delete(model);
             return RedirectToAction(nameof(Index));
         }

         // GET: CouriersController/Edit/5
         public ActionResult Edit(string id)
         {
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


         public ActionResult UnassignedPackages()
         {
             var model = _packageServices.GetUnassignedPackages();
             return View(model);
         }
         public ActionResult UnassignPackage(string packageNumber, string CourierId)
         {
             _packageServices.UnassignPackage(packageNumber);
             var model = _packageServices.GetCourierPackages(CourierId);
             return RedirectToAction("CourierPackages", new { id = CourierId });
         }
     }
        */

        // GET: CouriersController

    }
}