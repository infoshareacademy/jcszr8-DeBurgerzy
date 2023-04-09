using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.DTOs;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class DeliveryMachinesController : Controller
    {
        private readonly IDeliveryMachinesService _deliveryMachinesService;
        private readonly IMapper _mapper;

        public DeliveryMachinesController(IDeliveryMachinesService deliveryMachinesService, IMapper mapper)
        {
            _deliveryMachinesService = deliveryMachinesService;
            _mapper = mapper;
        }

        // GET: DeliveryMachinesController/DeleteDeliveryMachine
        public ActionResult DeleteDeliveryMachine(string deliveryMachineId)
        {
            bool deleted = _deliveryMachinesService.DeleteDeliveryMachineById(deliveryMachineId);
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

        // GET: DeliveryMachinesController/Details
        public ActionResult Details()
        {
            IEnumerable<DeliveryMachine> deliveryMachines = _deliveryMachinesService.GetAll();
            return View(deliveryMachines);
        }

        // GET: DeliveryMachinesController/EditDeliveryMachine
        public ActionResult EditDeliveryMachine()
        {
            return View();
        }

        // POST: DeliveryMachinesController/EditDeliveryMachineConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDeliveryMachineConfirmed(DeliveryMachineDTO deliveryMachineDTO)
        {
            DeliveryMachine deliveryMachine = _mapper.Map<DeliveryMachine>(deliveryMachineDTO);
            _deliveryMachinesService.CreateNewDeliveryMachine(deliveryMachine);
            return RedirectToAction(nameof(Details));
        }
    }
}