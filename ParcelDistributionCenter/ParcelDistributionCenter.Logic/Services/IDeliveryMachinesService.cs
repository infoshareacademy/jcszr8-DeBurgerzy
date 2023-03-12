using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services
{
    public interface IDeliveryMachinesService
    {
        IEnumerable<DeliveryMachine> GetAll();
    }
}