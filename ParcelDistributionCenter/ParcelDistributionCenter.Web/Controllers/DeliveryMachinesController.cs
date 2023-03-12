using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Web.Controllers
{
    public class DeliveryMachinesController : Controller
    {
        private readonly IDeliveryMachinesService _deliveryMachinesService;

        public DeliveryMachinesController(IDeliveryMachinesService deliveryMachinesService)
        {
            _deliveryMachinesService = deliveryMachinesService;
        }

        // GET: DeliveryMachinesController/Details
        public ActionResult Details()
        {
            IEnumerable<DeliveryMachine> deliveryMachines = _deliveryMachinesService.GetAll();
            return View(deliveryMachines);
        }
    }
}