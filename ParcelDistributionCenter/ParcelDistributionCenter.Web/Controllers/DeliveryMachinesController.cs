using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Logic.ViewModels;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DeliveryMachinesController : Controller
    {
        private readonly IDeliveryMachinesService _deliveryMachinesService;
        private readonly IMapper _mapper;

        public DeliveryMachinesController(IDeliveryMachinesService deliveryMachinesService, IMapper mapper)
        {
            _deliveryMachinesService = deliveryMachinesService;
            _mapper = mapper;
        }

        // GET: DeliveryMachinesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryMachinesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirmed(DeliveryMachineViewModel deliveryMachineViewModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryMachine? deliveryMachine = _mapper.Map<DeliveryMachine>(deliveryMachineViewModel);
                _deliveryMachinesService.CreateNewDeliveryMachine(deliveryMachine);
                return RedirectToAction(nameof(Details));
            }
            return View(nameof(Create));
        }

        // GET: DeliveryMachinesController/DeleteDeliveryMachine
        public ActionResult DeleteDeliveryMachine(string id)
        {
            try
            {
                bool deleted = _deliveryMachinesService.DeleteDeliveryMachineById(id);
                if (deleted)
                {
                    TempData["Message"] = "Delivery Machine successfully deleted";
                    TempData["MessageClass"] = "alert-success";
                    return RedirectToAction(nameof(Details));
                }
                TempData["Message"] = "Package not deleted! Something went wrong";
                TempData["MessageClass"] = "alert-danger";
                return RedirectToAction(nameof(Details));
            }
            catch
            {
                TempData["Message"] = "Unable to delete the selected delivery machine because it is associated with one or more packages.";
                TempData["MessageClass"] = "alert-danger";
                return RedirectToAction(nameof(Details));
            }
        }

        // GET: DeliveryMachinesController/Details
        public ActionResult Details()
        {
            IEnumerable<DeliveryMachine> deliveryMachines = _deliveryMachinesService.GetAll();
            IEnumerable<DeliveryMachineViewModel> deliveryMachinesViewModel = _mapper.Map<IEnumerable<DeliveryMachineViewModel>>(deliveryMachines);
            return View(deliveryMachinesViewModel);
        }

        // GET: DeliveryMachinesController/DeleteDeliveryMachine
        public ActionResult DMPackagesList(string id)
        {
            DeliveryMachine deliveryMachine = _deliveryMachinesService.GetDeliveryMachineById(id);
            IEnumerable<PackageViewModel> packages = _mapper.Map<IEnumerable<PackageViewModel>>(deliveryMachine.Packages);
            return View(packages);
        }

        // TODO: ZABEZPIECZYĆ PRZED NULLEM
        // GET: DeliveryMachinesController/EditDeliveryMachine
        public ActionResult EditDeliveryMachine(string id)
        {
            DeliveryMachine deliveryMachine = _deliveryMachinesService.GetDeliveryMachineById(id);
            DeliveryMachineViewModel viewModel = _mapper.Map<DeliveryMachineViewModel>(deliveryMachine);
            return View(viewModel);
        }

        // POST: DeliveryMachinesController/EditDeliveryMachineConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDeliveryMachineConfirmed(DeliveryMachineViewModel deliveryMachineViewModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryMachine deliveryMachine = _mapper.Map<DeliveryMachine>(deliveryMachineViewModel);
                _deliveryMachinesService.UpdateDeliveryMachine(deliveryMachine);
                return RedirectToAction(nameof(Details));
            }
            return View(nameof(EditDeliveryMachine));
        }

        public ActionResult UnassignPackage(string packageNumber, string deliveryMachineId)
        {
            _deliveryMachinesService.UnassignPackage(packageNumber, deliveryMachineId);
            return RedirectToAction("DMPackagesList", new { id = deliveryMachineId });
        }
    }
}